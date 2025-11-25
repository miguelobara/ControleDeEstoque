using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using ControleDeEstoque.Data.Repositories;

namespace ControleDeEstoque.Forms
{
    /// <summary>
    /// Formulário de produtos CORRIGIDO e OTIMIZADO
    /// </summary>
    public partial class ProdutoForm : Form
    {
        private readonly ProdutoRepository _repo;
        private readonly FornecedorRepository _fornecedorRepo;

        // Controles principais
        private DataGridView _grid;
        private Panel _panelForm;
        private Panel _panelButtons;

        // Controles de formulário
        private TextBox _tbNome, _tbPrecoCompra, _tbPrecoVenda, _tbDescricao, _tbBusca;
        private ComboBox _cbCategoria, _cbUnidade, _cbFornecedor;
        private NumericUpDown _nudQuantidade, _nudJuros;
        private DateTimePicker _dtpValidade;
        private Label _lblLucroEstimado, _lblMargemLucro, _lblTotal;

        // Botões
        private Button _btnSalvar, _btnEditar, _btnDeletar, _btnNovo, _btnRefresh, _btnVoltar;

        // Controle de estado
        private bool _editMode = false;
        private Produto _currentItem;

        public ProdutoForm()
        {
            _repo = new ProdutoRepository();
            _fornecedorRepo = new FornecedorRepository();

            this.Text = "Gerenciamento de Produtos";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            // Header
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.RoyalBlue
            };

            var lblTitle = new Label
            {
                Text = "GERENCIAMENTO DE PRODUTOS",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            _btnVoltar = new Button
            {
                Text = "← Voltar",
                Location = new Point(10, 15),
                Size = new Size(90, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnVoltar.Click += (s, e) => this.Close();

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(_btnVoltar);
            this.Controls.Add(panelHeader);

            // Panel Formulário (Esquerda)
            _panelForm = new Panel
            {
                Dock = DockStyle.Left,
                Width = 400,
                Padding = new Padding(10),
                BackColor = Color.White,
                AutoScroll = true
            };

            SetupFormControls();
            this.Controls.Add(_panelForm);

            // Grid (Centro)
            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            _grid.SelectionChanged += Grid_SelectionChanged;
            this.Controls.Add(_grid);

            // Panel Botões (Inferior)
            _panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.Gainsboro
            };

            CreateButtons();
            this.Controls.Add(_panelButtons);
        }

        private void SetupFormControls()
        {
            int y = 10;
            int spacing = 70;

            // Busca
            var gbBusca = new GroupBox
            {
                Text = "Buscar Produto",
                Location = new Point(10, y),
                Size = new Size(360, 60),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            _tbBusca = new TextBox { Location = new Point(10, 25), Size = new Size(340, 25) };
            _tbBusca.TextChanged += (s, e) => FilterProducts();
            gbBusca.Controls.Add(_tbBusca);
            _panelForm.Controls.Add(gbBusca);
            y += 70;

            // Nome
            _panelForm.Controls.Add(CreateLabel("Nome:", y));
            _tbNome = new TextBox { Location = new Point(10, y + 20), Size = new Size(360, 25) };
            _panelForm.Controls.Add(_tbNome);
            y += spacing;

            // Categoria
            _panelForm.Controls.Add(CreateLabel("Categoria:", y));
            _cbCategoria = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(280, 25),
                DropDownStyle = ComboBoxStyle.DropDown
            };
            _cbCategoria.Items.AddRange(new[] { "Limpeza", "Bebida", "Comida", "Higiene", "Bazar" });

            var btnAddCat = CreateSmallButton("+", 295, y + 20);
            btnAddCat.Click += (s, e) => AddNewCategory();

            _panelForm.Controls.Add(_cbCategoria);
            _panelForm.Controls.Add(btnAddCat);
            y += spacing;

            // Unidade
            _panelForm.Controls.Add(CreateLabel("Unidade:", y));
            _cbUnidade = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cbUnidade.Items.AddRange(new[] { "Kg", "g", "L", "ml", "Un", "Cx", "Pct" });
            _panelForm.Controls.Add(_cbUnidade);
            y += spacing;

            // Preço Compra
            _panelForm.Controls.Add(CreateLabel("Preço Compra:", y));
            _tbPrecoCompra = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoCompra.TextChanged += (s, e) => CalculateLucro();
            _panelForm.Controls.Add(_tbPrecoCompra);
            y += spacing;

            // Margem Lucro
            _panelForm.Controls.Add(CreateLabel("Margem Lucro (%):", y));
            _nudJuros = new NumericUpDown
            {
                Location = new Point(10, y + 20),
                Size = new Size(100, 25),
                Minimum = 0,
                Maximum = 500,
                DecimalPlaces = 2,
                Value = 30
            };
            _nudJuros.ValueChanged += (s, e) => RecalculatePrecoVenda();
            _panelForm.Controls.Add(_nudJuros);
            y += spacing;

            // Preço Venda
            _panelForm.Controls.Add(CreateLabel("Preço Venda:", y));
            _tbPrecoVenda = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoVenda.TextChanged += (s, e) => CalculateLucro();
            _panelForm.Controls.Add(_tbPrecoVenda);
            y += spacing;

            // Labels de Lucro
            _lblLucroEstimado = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Lucro: R$ 0,00",
                ForeColor = Color.Green,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            _panelForm.Controls.Add(_lblLucroEstimado);

            _lblMargemLucro = new Label
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 20),
                Text = "Margem: 0%",
                ForeColor = Color.Blue,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            _panelForm.Controls.Add(_lblMargemLucro);
            y += 50;

            // Quantidade
            _panelForm.Controls.Add(CreateLabel("Quantidade:", y));
            _nudQuantidade = new NumericUpDown
            {
                Location = new Point(10, y + 20),
                Size = new Size(100, 25),
                Maximum = 100000
            };
            _nudQuantidade.ValueChanged += (s, e) => CalculateLucro();
            _panelForm.Controls.Add(_nudQuantidade);
            y += spacing;

            // Total
            _lblTotal = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Total Estoque: R$ 0,00",
                ForeColor = Color.DarkBlue,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            _panelForm.Controls.Add(_lblTotal);
            y += 30;

            // Fornecedor
            _panelForm.Controls.Add(CreateLabel("Fornecedor:", y));
            _cbFornecedor = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadFornecedores();
            _panelForm.Controls.Add(_cbFornecedor);
            y += spacing;

            // Validade
            _panelForm.Controls.Add(CreateLabel("Validade:", y));
            _dtpValidade = new DateTimePicker
            {
                Location = new Point(10, y + 20),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };
            _panelForm.Controls.Add(_dtpValidade);
            y += spacing;

            // Descrição
            _panelForm.Controls.Add(CreateLabel("Descrição:", y));
            _tbDescricao = new TextBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 80),
                Multiline = true
            };
            _panelForm.Controls.Add(_tbDescricao);
        }

        private void CreateButtons()
        {
            _btnNovo = CreateButton("Novo", 10, Color.Green);
            _btnNovo.Click += (s, e) => NewMode();

            _btnSalvar = CreateButton("Salvar", 120, Color.RoyalBlue);
            _btnSalvar.Click += (s, e) => Save();

            _btnEditar = CreateButton("Editar", 230, Color.SteelBlue);
            _btnEditar.Click += (s, e) => EditMode();

            _btnDeletar = CreateButton("Deletar", 340, Color.Crimson);
            _btnDeletar.Click += (s, e) => Delete();

            _btnRefresh = CreateButton("Atualizar", 450, Color.Gray);
            _btnRefresh.Click += (s, e) => LoadData();

            _panelButtons.Controls.AddRange(new[] { _btnNovo, _btnSalvar, _btnEditar, _btnDeletar, _btnRefresh });
        }

        private Button CreateButton(string text, int x, Color color)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, 15),
                Size = new Size(100, 30),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private Button CreateSmallButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(30, 25),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private Label CreateLabel(string text, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
        }

        private void LoadData()
        {
            try
            {
                var produtos = _repo.GetAll();
                _grid.DataSource = produtos;
                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            if (_grid.Columns.Count == 0) return;

            _grid.Columns["Id"].Visible = false;
            _grid.Columns["Nome"].HeaderText = "Produto";
            _grid.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";
            _grid.Columns["PrecoCompra"].DefaultCellStyle.Format = "C2";
            _grid.Columns["LucroUnitario"].DefaultCellStyle.Format = "C2";
            _grid.Columns["MargemLucro"].DefaultCellStyle.Format = "F2";
        }

        private void FilterProducts()
        {
            if (string.IsNullOrWhiteSpace(_tbBusca.Text))
            {
                LoadData();
                return;
            }

            var produtos = _repo.Search(_tbBusca.Text, new SearchOptions
            {
                SearchName = true,
                SearchCategory = true
            });

            _grid.DataSource = produtos;
            ConfigureGrid();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_grid.SelectedRows.Count > 0 && !_editMode)
            {
                _currentItem = _grid.SelectedRows[0].DataBoundItem as Produto;
                if (_currentItem != null)
                    LoadToForm(_currentItem);
            }
        }

        private void LoadToForm(Produto p)
        {
            _tbNome.Text = p.Nome;
            _cbCategoria.Text = p.Categoria;
            _cbUnidade.Text = p.UnidadeMedida;
            _tbPrecoCompra.Text = p.PrecoCompra.ToString("F2");
            _tbPrecoVenda.Text = p.PrecoVenda.ToString("F2");
            _nudQuantidade.Value = p.Quantidade;
            _nudJuros.Value = p.Juros;
            _dtpValidade.Value = p.Validade;
            _tbDescricao.Text = p.Descricao;

            if (p.IdFornecedor.HasValue)
            {
                for (int i = 0; i < _cbFornecedor.Items.Count; i++)
                {
                    if (_cbFornecedor.Items[i] is ComboItem ci && ci.Value == p.IdFornecedor.Value)
                    {
                        _cbFornecedor.SelectedIndex = i;
                        break;
                    }
                }
            }

            CalculateLucro();
        }

        private void CalculateLucro()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) &&
                decimal.TryParse(_tbPrecoVenda.Text, out decimal venda))
            {
                decimal lucro = venda - compra;
                decimal margem = compra > 0 ? (lucro / compra) * 100 : 0;
                decimal total = compra * _nudQuantidade.Value;

                _lblLucroEstimado.Text = $"Lucro: {lucro:C2}";
                _lblLucroEstimado.ForeColor = lucro >= 0 ? Color.Green : Color.Red;
                _lblMargemLucro.Text = $"Margem: {margem:F2}%";
                _lblTotal.Text = $"Total Estoque: {total:C2}";
            }
        }

        private void RecalculatePrecoVenda()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) && compra > 0)
            {
                decimal margem = _nudJuros.Value / 100m;
                decimal venda = compra * (1 + margem);
                _tbPrecoVenda.Text = venda.ToString("F2");
            }
        }

        private void LoadFornecedores()
        {
            _cbFornecedor.Items.Clear();
            _cbFornecedor.Items.Add(new ComboItem { Text = "Sem Fornecedor", Value = 0 });

            var fornecedores = _fornecedorRepo.GetForCombo();
            foreach (var f in fornecedores)
                _cbFornecedor.Items.Add(new ComboItem { Text = f.Value, Value = f.Key });

            _cbFornecedor.SelectedIndex = 0;
        }

        private void AddNewCategory()
        {
            string nova = PromptInput("Nome da nova categoria:", "Nova Categoria");
            if (!string.IsNullOrWhiteSpace(nova))
            {
                _cbCategoria.Items.Add(nova);
                _cbCategoria.Text = nova;
            }
        }

        private void NewMode()
        {
            _editMode = false;
            _currentItem = new Produto();
            ClearForm();
            _btnSalvar.Text = "Salvar Novo";
        }

        private void EditMode()
        {
            if (_currentItem == null)
            {
                MessageBox.Show("Selecione um produto", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _editMode = true;
            _btnSalvar.Text = "Salvar Edição";
            this.BackColor = Color.LightYellow;
        }

        private void Save()
        {
            if (!Validate()) return;

            try
            {
                var produto = GetFormData();
                bool success = _editMode ? _repo.Update(produto) : _repo.Insert(produto);

                if (success)
                {
                    MessageBox.Show("Salvo com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExitEditMode();
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            if (_currentItem == null)
            {
                MessageBox.Show("Selecione um produto", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deletar {_currentItem.Nome}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_repo.Delete(_currentItem.Id))
                {
                    MessageBox.Show("Deletado!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_tbNome.Text))
            {
                MessageBox.Show("Nome é obrigatório", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbNome.Focus();
                return false;
            }

            if (!decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) || compra <= 0)
            {
                MessageBox.Show("Preço de compra inválido", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbPrecoCompra.Focus();
                return false;
            }

            if (!decimal.TryParse(_tbPrecoVenda.Text, out decimal venda) || venda <= 0)
            {
                MessageBox.Show("Preço de venda inválido", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tbPrecoVenda.Focus();
                return false;
            }

            return true;
        }

        private Produto GetFormData()
        {
            int? idFornecedor = null;
            if (_cbFornecedor.SelectedItem is ComboItem ci && ci.Value > 0)
                idFornecedor = ci.Value;

            return new Produto
            {
                Id = _currentItem?.Id ?? 0,
                Nome = _tbNome.Text.Trim(),
                Categoria = _cbCategoria.Text,
                UnidadeMedida = _cbUnidade.Text,
                PrecoCompra = decimal.Parse(_tbPrecoCompra.Text),
                PrecoVenda = decimal.Parse(_tbPrecoVenda.Text),
                Quantidade = (int)_nudQuantidade.Value,
                Juros = _nudJuros.Value,
                Validade = _dtpValidade.Value,
                Descricao = _tbDescricao.Text.Trim(),
                IdFornecedor = idFornecedor
            };
        }

        private void ClearForm()
        {
            _tbNome.Clear();
            _cbCategoria.SelectedIndex = -1;
            _cbUnidade.SelectedIndex = -1;
            _tbPrecoCompra.Clear();
            _tbPrecoVenda.Clear();
            _nudQuantidade.Value = 0;
            _nudJuros.Value = 30;
            _tbDescricao.Clear();
            _cbFornecedor.SelectedIndex = 0;
            _dtpValidade.Value = DateTime.Now;
            _lblLucroEstimado.Text = "Lucro: R$ 0,00";
            _lblMargemLucro.Text = "Margem: 0%";
            _lblTotal.Text = "Total: R$ 0,00";
        }

        private void ExitEditMode()
        {
            _editMode = false;
            _btnSalvar.Text = "Salvar";
            this.BackColor = SystemColors.Control;
        }

        private string PromptInput(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "OK", Left = 250, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (s, e) => { prompt.Close(); };
            prompt.Controls.AddRange(new Control[] { textLabel, textBox, confirmation });
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
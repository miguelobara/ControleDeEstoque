using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using ControleDeEstoque.Data.Repositories;

namespace ControleDeEstoque.Forms
{
    public partial class ProdutoForm : Form
    {
        private readonly ProdutoRepository _repo;
        private readonly FornecedorRepository _fornecedorRepo;
        private DataGridView _grid;
        private Panel _panelForm;
        private TextBox _tbNome, _tbPrecoCompra, _tbPrecoVenda, _tbBusca;
        private ComboBox _cbCategoria, _cbUnidade, _cbFornecedor;
        private NumericUpDown _nudQuantidade, _nudJuros;
        private DateTimePicker _dtpValidade;
        private Label _lblLucro, _lblMargem, _lblTotal;
        private Button _btnSalvar, _btnEditar, _btnDeletar, _btnNovo, _btnVoltar;
        private bool _editMode = false;
        private Produto _currentItem;

        public ProdutoForm()
        {
            _repo = new ProdutoRepository();
            _fornecedorRepo = new FornecedorRepository();

            this.Text = "Produtos";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitUI();
            LoadData();
        }

        private void InitUI()
        {
            // Header
            var header = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.RoyalBlue };
            var title = new Label
            {
                Text = "PRODUTOS",
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
            _btnVoltar.Click += (s, e) => Close();
            header.Controls.AddRange(new Control[] { title, _btnVoltar });
            Controls.Add(header);

            // Form Panel (Esquerda)
            _panelForm = new Panel
            {
                Dock = DockStyle.Left,
                Width = 400,
                Padding = new Padding(10),
                BackColor = Color.White,
                AutoScroll = true
            };
            SetupFormControls();
            Controls.Add(_panelForm);

            // Grid (Centro)
            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };
            _grid.SelectionChanged += (s, e) => {
                if (_grid.SelectedRows.Count > 0 && !_editMode)
                    LoadToForm(_grid.SelectedRows[0].DataBoundItem as Produto);
            };
            Controls.Add(_grid);

            // Botões (Inferior)
            var panelBtns = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.Gainsboro };
            _btnNovo = CreateBtn("Novo", 10, Color.Green, (s, e) => NewMode());
            _btnSalvar = CreateBtn("Salvar", 120, Color.RoyalBlue, (s, e) => Save());
            _btnEditar = CreateBtn("Editar", 230, Color.SteelBlue, (s, e) => EditMode());
            _btnDeletar = CreateBtn("Deletar", 340, Color.Crimson, (s, e) => Delete());
            panelBtns.Controls.AddRange(new[] { _btnNovo, _btnSalvar, _btnEditar, _btnDeletar });
            Controls.Add(panelBtns);
        }

        private void SetupFormControls()
        {
            int y = 10;

            // Busca
            var gbBusca = new GroupBox { Text = "Buscar", Location = new Point(10, y), Size = new Size(360, 60) };
            _tbBusca = new TextBox { Location = new Point(10, 25), Size = new Size(340, 25) };
            _tbBusca.TextChanged += (s, e) => FilterProducts();
            gbBusca.Controls.Add(_tbBusca);
            _panelForm.Controls.Add(gbBusca);
            y += 70;

            // Nome
            _panelForm.Controls.Add(Lbl("Nome:", y));
            _tbNome = new TextBox { Location = new Point(10, y + 20), Size = new Size(360, 25) };
            _panelForm.Controls.Add(_tbNome);
            y += 70;

            // Categoria + Botão
            _panelForm.Controls.Add(Lbl("Categoria:", y));
            _cbCategoria = new ComboBox { Location = new Point(10, y + 20), Size = new Size(280, 25) };
            _cbCategoria.Items.AddRange(new[] { "Limpeza", "Bebida", "Comida", "Higiene", "Bazar" });
            var btnCat = new Button
            {
                Text = "+",
                Location = new Point(295, y + 20),
                Size = new Size(30, 25),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCat.Click += (s, e) => AddCategory();
            _panelForm.Controls.AddRange(new Control[] { _cbCategoria, btnCat });
            y += 70;

            // Unidade
            _panelForm.Controls.Add(Lbl("Unidade:", y));
            _cbUnidade = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cbUnidade.Items.AddRange(new[] { "Kg", "g", "L", "ml", "Un", "Cx", "Pct" });
            _panelForm.Controls.Add(_cbUnidade);
            y += 70;

            // Preço Compra
            _panelForm.Controls.Add(Lbl("Preço Compra:", y));
            _tbPrecoCompra = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoCompra.TextChanged += (s, e) => CalcLucro();
            _panelForm.Controls.Add(_tbPrecoCompra);
            y += 70;

            // Margem
            _panelForm.Controls.Add(Lbl("Margem (%):", y));
            _nudJuros = new NumericUpDown
            {
                Location = new Point(10, y + 20),
                Size = new Size(100, 25),
                Minimum = 0,
                Maximum = 500,
                DecimalPlaces = 2,
                Value = 30
            };
            _nudJuros.ValueChanged += (s, e) => RecalcVenda();
            _panelForm.Controls.Add(_nudJuros);
            y += 70;

            // Preço Venda
            _panelForm.Controls.Add(Lbl("Preço Venda:", y));
            _tbPrecoVenda = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoVenda.TextChanged += (s, e) => CalcLucro();
            _panelForm.Controls.Add(_tbPrecoVenda);
            y += 70;

            // Labels Lucro
            _lblLucro = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Lucro: R$ 0,00",
                ForeColor = Color.Green,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            _lblMargem = new Label
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 20),
                Text = "Margem: 0%",
                ForeColor = Color.Blue,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            _panelForm.Controls.AddRange(new[] { _lblLucro, _lblMargem });
            y += 50;

            // Quantidade
            _panelForm.Controls.Add(Lbl("Quantidade:", y));
            _nudQuantidade = new NumericUpDown { Location = new Point(10, y + 20), Size = new Size(100, 25), Maximum = 100000 };
            _nudQuantidade.ValueChanged += (s, e) => CalcLucro();
            _panelForm.Controls.Add(_nudQuantidade);
            y += 70;

            // Total
            _lblTotal = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Total: R$ 0,00",
                ForeColor = Color.DarkBlue,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            _panelForm.Controls.Add(_lblTotal);
            y += 30;

            // Fornecedor
            _panelForm.Controls.Add(Lbl("Fornecedor:", y));
            _cbFornecedor = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadFornecedores();
            _panelForm.Controls.Add(_cbFornecedor);
            y += 70;

            // Validade
            _panelForm.Controls.Add(Lbl("Validade:", y));
            _dtpValidade = new DateTimePicker
            {
                Location = new Point(10, y + 20),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };
            _panelForm.Controls.Add(_dtpValidade);
        }

        private Label Lbl(string text, int y) => new Label
        {
            Text = text,
            Location = new Point(10, y),
            Size = new Size(360, 20),
            Font = new Font("Segoe UI", 9F, FontStyle.Bold)
        };

        private Button CreateBtn(string text, int x, Color color, EventHandler click)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, 15),
                Size = new Size(100, 30),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.Click += click;
            return btn;
        }

        private void LoadData()
        {
            try
            {
                var produtos = _repo.GetAll();
                _grid.DataSource = produtos;
                if (_grid.Columns.Count > 0)
                {
                    _grid.Columns["Id"].Visible = false;
                    _grid.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";
                    _grid.Columns["PrecoCompra"].DefaultCellStyle.Format = "C2";
                    _grid.Columns["LucroUnitario"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFornecedores()
        {
            _cbFornecedor.Items.Clear();
            _cbFornecedor.Items.Add(new ComboItem { Text = "Sem Fornecedor", Value = 0 });

            // CORRIGIDO: Usa ObterFornecedoresParaCombo em vez de GetForCombo
            var fornecedores = _fornecedorRepo.ObterFornecedoresParaCombo();
            foreach (var f in fornecedores)
                _cbFornecedor.Items.Add(new ComboItem { Text = f.Value, Value = f.Key });

            _cbFornecedor.SelectedIndex = 0;
        }

        private void FilterProducts()
        {
            if (string.IsNullOrWhiteSpace(_tbBusca.Text)) { LoadData(); return; }
            var produtos = _repo.Search(_tbBusca.Text, new SearchOptions { SearchName = true, SearchCategory = true });
            _grid.DataSource = produtos;
        }

        private void LoadToForm(Produto p)
        {
            if (p == null) return;
            _tbNome.Text = p.Nome;
            _cbCategoria.Text = p.Categoria;
            _cbUnidade.Text = p.UnidadeMedida;
            _tbPrecoCompra.Text = p.PrecoCompra.ToString("F2");
            _tbPrecoVenda.Text = p.PrecoVenda.ToString("F2");
            _nudQuantidade.Value = p.Quantidade;
            _nudJuros.Value = p.Juros;
            _dtpValidade.Value = p.Validade;
            if (p.IdFornecedor.HasValue)
                for (int i = 0; i < _cbFornecedor.Items.Count; i++)
                    if (_cbFornecedor.Items[i] is ComboItem ci && ci.Value == p.IdFornecedor.Value)
                    { _cbFornecedor.SelectedIndex = i; break; }
            CalcLucro();
        }

        private void CalcLucro()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) &&
                decimal.TryParse(_tbPrecoVenda.Text, out decimal venda))
            {
                decimal lucro = venda - compra;
                decimal margem = compra > 0 ? (lucro / compra) * 100 : 0;
                decimal total = compra * _nudQuantidade.Value;
                _lblLucro.Text = $"Lucro: {lucro:C2}";
                _lblLucro.ForeColor = lucro >= 0 ? Color.Green : Color.Red;
                _lblMargem.Text = $"Margem: {margem:F2}%";
                _lblTotal.Text = $"Total: {total:C2}";
            }
        }

        private void RecalcVenda()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) && compra > 0)
                _tbPrecoVenda.Text = (compra * (1 + _nudJuros.Value / 100m)).ToString("F2");
        }

        private void AddCategory()
        {
            string nova = Prompt("Nome da categoria:", "Nova Categoria");
            if (!string.IsNullOrWhiteSpace(nova)) { _cbCategoria.Items.Add(nova); _cbCategoria.Text = nova; }
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
            if (_currentItem == null) { MessageBox.Show("Selecione um produto"); return; }
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
                bool ok = _editMode ? _repo.Update(produto) : _repo.Insert(produto);
                if (ok)
                {
                    MessageBox.Show("Salvo!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExitEditMode();
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex) { MessageBox.Show($"Erro: {ex.Message}"); }
        }

        private void Delete()
        {
            if (_currentItem == null) { MessageBox.Show("Selecione um produto"); return; }
            if (MessageBox.Show($"Deletar {_currentItem.Nome}?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_repo.Delete(_currentItem.Id))
                {
                    MessageBox.Show("Deletado!");
                    LoadData();
                    ClearForm();
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_tbNome.Text))
            { MessageBox.Show("Nome obrigatório"); _tbNome.Focus(); return false; }
            if (!decimal.TryParse(_tbPrecoCompra.Text, out decimal c) || c <= 0)
            { MessageBox.Show("Preço compra inválido"); _tbPrecoCompra.Focus(); return false; }
            if (!decimal.TryParse(_tbPrecoVenda.Text, out decimal v) || v <= 0)
            { MessageBox.Show("Preço venda inválido"); _tbPrecoVenda.Focus(); return false; }
            return true;
        }

        private Produto GetFormData()
        {
            int? idForn = null;
            if (_cbFornecedor.SelectedItem is ComboItem ci && ci.Value > 0) idForn = ci.Value;
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
                IdFornecedor = idForn
            };
        }

        private void ClearForm()
        {
            _tbNome.Clear(); _cbCategoria.SelectedIndex = -1; _cbUnidade.SelectedIndex = -1;
            _tbPrecoCompra.Clear(); _tbPrecoVenda.Clear(); _nudQuantidade.Value = 0;
            _nudJuros.Value = 30; _cbFornecedor.SelectedIndex = 0; _dtpValidade.Value = DateTime.Now;
            _lblLucro.Text = "Lucro: R$ 0,00"; _lblMargem.Text = "Margem: 0%"; _lblTotal.Text = "Total: R$ 0,00";
        }

        private void ExitEditMode()
        {
            _editMode = false;
            _btnSalvar.Text = "Salvar";
            this.BackColor = SystemColors.Control;
        }

        private string Prompt(string text, string caption)
        {
            var prompt = new Form
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            var tb = new TextBox { Left = 20, Top = 50, Width = 340 };
            var btn = new Button { Text = "OK", Left = 250, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            btn.Click += (s, e) => prompt.Close();
            prompt.Controls.AddRange(new Control[] {
                new Label { Left = 20, Top = 20, Text = text, Width = 350 }, tb, btn });
            prompt.AcceptButton = btn;
            return prompt.ShowDialog() == DialogResult.OK ? tb.Text : "";
        }

        private class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
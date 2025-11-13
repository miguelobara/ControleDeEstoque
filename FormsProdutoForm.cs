using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using ControleDeEstoque.Core;
using ControleDeEstoque.Data.Repositories;
using ControleDeEstoque.Services;
using System.IO;

namespace ControleDeEstoque.Forms
{
    /// <summary>
    /// Formulário de produtos completamente refatorado
    /// </summary>
    public class ProdutoForm : BaseCrudForm<Produto>
    {
        private readonly ProdutoRepository _repo;
        private readonly FornecedorRepository _fornecedorRepo;
        private readonly ValidationService _validator;

        // Controles
        private TextBox _tbNome, _tbPrecoCompra, _tbPrecoVenda, _tbDescricao;
        private ComboBox _cbCategoria, _cbUnidade, _cbFornecedor;
        private NumericUpDown _nudQuantidade, _nudJuros;
        private DateTimePicker _dtpValidade;
        private Label _lblLucroEstimado, _lblMargemLucro, _lblTotal;
        private TextBox _tbBusca;
        private GroupBox _gbFiltros;

        public ProdutoForm()
        {
            _repo = new ProdutoRepository();
            _fornecedorRepo = new FornecedorRepository();
            _validator = new ValidationService();

            this.Text = "Gerenciamento de Produtos";
            this.Size = new Size(1200, 700);
        }

        protected override void SetupFormControls()
        {
            PanelForm.AutoScroll = true;
            int y = 10;
            int spacing = 35;

            // Busca
            _gbFiltros = new GroupBox
            {
                Text = "Buscar Produto",
                Location = new Point(10, y),
                Size = new Size(360, 70),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            _tbBusca = new TextBox
            {
                Location = new Point(10, 25),
                Size = new Size(340, 25),
                PlaceholderText = "Digite para buscar..."
            };
            _tbBusca.TextChanged += (s, e) => FiltrarProdutos();

            _gbFiltros.Controls.Add(_tbBusca);
            PanelForm.Controls.Add(_gbFiltros);
            y += 80;

            // Nome
            PanelForm.Controls.Add(CreateLabel("Nome do Produto:", y));
            _tbNome = new TextBox { Location = new Point(10, y + 20), Size = new Size(360, 25) };
            PanelForm.Controls.Add(_tbNome);
            y += spacing + 15;

            // Categoria
            PanelForm.Controls.Add(CreateLabel("Categoria:", y));
            _cbCategoria = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cbCategoria.Items.AddRange(new[] { "Selecione...", "Limpeza", "Bebida", "Comida", "Higiene", "Bazar", "Outros" });
            _cbCategoria.SelectedIndex = 0;

            var btnNovaCategoria = new Button
            {
                Text = "+",
                Location = new Point(265, y + 20),
                Size = new Size(30, 25),
                BackColor = AppCore.PrimaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnNovaCategoria.Click += (s, e) => AdicionarCategoria();

            PanelForm.Controls.Add(_cbCategoria);
            PanelForm.Controls.Add(btnNovaCategoria);
            y += spacing + 15;

            // Unidade
            PanelForm.Controls.Add(CreateLabel("Unidade de Medida:", y));
            _cbUnidade = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cbUnidade.Items.AddRange(new[] { "Selecione...", "Kg", "g", "L", "ml", "Unidade", "Caixa", "Pacote" });
            _cbUnidade.SelectedIndex = 0;
            PanelForm.Controls.Add(_cbUnidade);
            y += spacing + 15;

            // Preço Compra
            PanelForm.Controls.Add(CreateLabel("Preço de Compra:", y));
            _tbPrecoCompra = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoCompra.TextChanged += (s, e) => CalcularLucro();
            PanelForm.Controls.Add(_tbPrecoCompra);
            y += spacing + 15;

            // Preço Venda
            PanelForm.Controls.Add(CreateLabel("Preço de Venda:", y));
            _tbPrecoVenda = new TextBox { Location = new Point(10, y + 20), Size = new Size(150, 25) };
            _tbPrecoVenda.TextChanged += (s, e) => CalcularLucro();
            PanelForm.Controls.Add(_tbPrecoVenda);
            y += spacing + 15;

            // Juros/Margem
            PanelForm.Controls.Add(CreateLabel("Margem de Lucro (%):", y));
            _nudJuros = new NumericUpDown
            {
                Location = new Point(10, y + 20),
                Size = new Size(100, 25),
                Minimum = 0,
                Maximum = 500,
                DecimalPlaces = 2,
                Value = 30
            };
            _nudJuros.ValueChanged += (s, e) => RecalcularPrecoVenda();
            PanelForm.Controls.Add(_nudJuros);
            y += spacing + 15;

            // Info Lucro
            _lblLucroEstimado = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Lucro Unitário: R$ 0,00",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = AppCore.SuccessColor
            };
            PanelForm.Controls.Add(_lblLucroEstimado);
            y += 25;

            _lblMargemLucro = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Margem Real: 0%",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = AppCore.InfoColor
            };
            PanelForm.Controls.Add(_lblMargemLucro);
            y += 30;

            // Quantidade
            PanelForm.Controls.Add(CreateLabel("Quantidade em Estoque:", y));
            _nudQuantidade = new NumericUpDown
            {
                Location = new Point(10, y + 20),
                Size = new Size(100, 25),
                Minimum = 0,
                Maximum = 100000
            };
            _nudQuantidade.ValueChanged += (s, e) => CalcularLucro();
            PanelForm.Controls.Add(_nudQuantidade);
            y += spacing + 15;

            // Total estoque
            _lblTotal = new Label
            {
                Location = new Point(10, y),
                Size = new Size(360, 20),
                Text = "Valor Total Estoque: R$ 0,00",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = AppCore.PrimaryColor
            };
            PanelForm.Controls.Add(_lblTotal);
            y += 30;

            // Fornecedor
            PanelForm.Controls.Add(CreateLabel("Fornecedor:", y));
            _cbFornecedor = new ComboBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CarregarFornecedores();
            PanelForm.Controls.Add(_cbFornecedor);
            y += spacing + 15;

            // Validade
            PanelForm.Controls.Add(CreateLabel("Data de Validade:", y));
            _dtpValidade = new DateTimePicker
            {
                Location = new Point(10, y + 20),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };
            PanelForm.Controls.Add(_dtpValidade);
            y += spacing + 15;

            // Descrição
            PanelForm.Controls.Add(CreateLabel("Descrição:", y));
            _tbDescricao = new TextBox
            {
                Location = new Point(10, y + 20),
                Size = new Size(360, 80),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            PanelForm.Controls.Add(_tbDescricao);
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

        private void CalcularLucro()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) &&
                decimal.TryParse(_tbPrecoVenda.Text, out decimal venda))
            {
                decimal lucroUnit = venda - compra;
                decimal margem = compra > 0 ? (lucroUnit / compra) * 100 : 0;
                decimal quantidade = _nudQuantidade.Value;

                _lblLucroEstimado.Text = $"Lucro Unitário: {AppCore.FormatCurrency(lucroUnit)}";
                _lblLucroEstimado.ForeColor = lucroUnit >= 0 ? AppCore.SuccessColor : AppCore.DangerColor;

                _lblMargemLucro.Text = $"Margem Real: {AppCore.FormatPercent(margem)}";

                decimal totalEstoque = compra * quantidade;
                decimal lucroTotal = lucroUnit * quantidade;
                _lblTotal.Text = $"Valor Total Estoque: {AppCore.FormatCurrency(totalEstoque)} | Lucro Potencial: {AppCore.FormatCurrency(lucroTotal)}";
            }
        }

        private void RecalcularPrecoVenda()
        {
            if (decimal.TryParse(_tbPrecoCompra.Text, out decimal compra) && compra > 0)
            {
                decimal margem = _nudJuros.Value / 100m;
                decimal venda = compra * (1 + margem);
                _tbPrecoVenda.Text = venda.ToString("F2");
            }
        }

        private void CarregarFornecedores()
        {
            _cbFornecedor.Items.Clear();
            _cbFornecedor.Items.Add("Sem Fornecedor");

            var fornecedores = _fornecedorRepo.GetForCombo();
            foreach (var f in fornecedores)
                _cbFornecedor.Items.Add(new ComboItem { Text = f.Value, Value = f.Key });

            _cbFornecedor.SelectedIndex = 0;
        }

        private void AdicionarCategoria()
        {
            string nova = Microsoft.VisualBasic.Interaction.InputBox("Nome da nova categoria:", "Nova Categoria");
            if (!string.IsNullOrWhiteSpace(nova))
            {
                _cbCategoria.Items.Add(nova);
                _cbCategoria.Text = nova;
            }
        }

        private void FiltrarProdutos()
        {
            if (string.IsNullOrWhiteSpace(_tbBusca.Text))
            {
                RefreshGrid();
                return;
            }

            var produtos = _repo.Search(_tbBusca.Text, new SearchOptions { SearchName = true, SearchCategory = true });
            Grid.DataSource = produtos;
            ConfigureGridColumns();
        }

        protected override object LoadData() => _repo.GetAll();

        protected override void ConfigureGridColumns()
        {
            if (Grid.Columns.Count == 0) return;

            Grid.Columns["Id"].Visible = false;
            Grid.Columns["Nome"].HeaderText = "Nome do Produto";
            Grid.Columns["Categoria"].HeaderText = "Categoria";
            Grid.Columns["PrecoVenda"].HeaderText = "Preço";
            Grid.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";
            Grid.Columns["Quantidade"].HeaderText = "Estoque";
            Grid.Columns["LucroUnitario"].HeaderText = "Lucro Unit.";
            Grid.Columns["LucroUnitario"].DefaultCellStyle.Format = "C2";
            Grid.Columns["MargemLucro"].HeaderText = "Margem %";
            Grid.Columns["MargemLucro"].DefaultCellStyle.Format = "F2";
        }

        protected override Produto GetSelectedItem()
        {
            if (Grid.SelectedRows.Count == 0) return null;
            return Grid.SelectedRows[0].DataBoundItem as Produto;
        }

        protected override void LoadItemToForm(Produto item)
        {
            _tbNome.Text = item.Nome;
            _cbCategoria.Text = item.Categoria;
            _cbUnidade.Text = item.UnidadeMedida;
            _tbPrecoCompra.Text = item.PrecoCompra.ToString("F2");
            _tbPrecoVenda.Text = item.PrecoVenda.ToString("F2");
            _nudQuantidade.Value = item.Quantidade;
            _nudJuros.Value = item.Juros;
            _dtpValidade.Value = item.Validade;
            _tbDescricao.Text = item.Descricao;

            if (item.IdFornecedor.HasValue)
            {
                for (int i = 1; i < _cbFornecedor.Items.Count; i++)
                {
                    if (_cbFornecedor.Items[i] is ComboItem ci && ci.Value == item.IdFornecedor.Value)
                    {
                        _cbFornecedor.SelectedIndex = i;
                        break;
                    }
                }
            }

            CalcularLucro();
        }

        protected override Produto GetFormData()
        {
            int? idFornecedor = null;
            if (_cbFornecedor.SelectedIndex > 0 && _cbFornecedor.SelectedItem is ComboItem ci)
                idFornecedor = ci.Value;

            return new Produto
            {
                Id = CurrentItem?.Id ?? 0,
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

        protected override bool ValidateForm()
        {
            var produto = GetFormData();
            var result = _validator.ValidateProduto(produto);

            if (!result.IsValid)
            {
                AppCore.ShowError(result.GetErrorsMessage());
                return false;
            }

            if (result.HasWarnings)
            {
                if (!AppCore.Confirm($"{result.GetWarningsMessage()}\n\nDeseja continuar?"))
                    return false;
            }

            return true;
        }

        protected override bool InsertItem(Produto item) => _repo.Insert(item);
        protected override bool UpdateItem(Produto item) => _repo.Update(item);
        protected override bool DeleteItemFromDb(Produto item) => _repo.Delete(item.Id);

        private class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
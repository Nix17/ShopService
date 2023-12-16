using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;
using ShopService.Enums;
using System.Windows.Forms;

namespace ShopService
{
    public partial class Form1 : Form
    {
        private IShopCommands _cmds;

        public List<ProductDTO> Products = new List<ProductDTO>();
        public List<StoreDTO> Stores = new List<StoreDTO>();
        public List<ProductBatchDTO> ProductBatches = new List<ProductBatchDTO>();

        public Form1(IShopCommands commands)
        {
            _cmds = commands;

            InitializeComponent();
        }

        private async void UpdateAllData()
        {
            var resProducts = await _cmds.GetAllProducts();
            var resStores = await _cmds.GetAllStores();
            var resBatches = await _cmds.GetAllProductBatches();

            if (!(resProducts.IsSuccess && resStores.IsSuccess && resBatches.IsSuccess))
            {
                this.Close();
            }

            Products = resProducts.Result;
            Stores = resStores.Result;
            ProductBatches = resBatches.Result;

            cmbBoxProviderStores.Items.Clear();
            cmbBoxProviderStores.Items.AddRange(Stores.ToArray());
            cmbBoxProviderStores.DisplayMember = "Name";
            cmbBoxProviderStores.ValueMember = "Id";
            cmbBoxProviderStores.SelectedIndex = 0;

            cmbBoxBuyerStores.Items.Clear();
            cmbBoxBuyerStores.Items.Add(new StoreDTO(ENUM_NAMES.EMPTY_STORE_NAME));
            cmbBoxBuyerStores.Items.AddRange(Stores.ToArray());
            cmbBoxBuyerStores.DisplayMember = "Name";
            cmbBoxBuyerStores.ValueMember = "Id";
            cmbBoxBuyerStores.SelectedIndex = 0;

            await FillDataGridProviderProducts();
            await FillDataGridBuyerBatches();
        }

        private async Task FillDataGridProviderProducts()
        {
            dtGridProviderProducts.Rows.Clear();
            int idxRow = 0;
            foreach (ProductDTO product in Products)
            {
                dtGridProviderProducts.Rows.Add();
                dtGridProviderProducts.Rows[idxRow].Cells[0].Value = product.Id;
                dtGridProviderProducts.Rows[idxRow].Cells[1].Value = product.Name;
                dtGridProviderProducts.Rows[idxRow].Cells[2].Value = "";
                dtGridProviderProducts.Rows[idxRow].Cells[3].Value = "";

                idxRow++;
            }
        }

        private async Task FillDataGridBuyerBatches()
        {
            var storeName = (cmbBoxBuyerStores.SelectedItem as StoreDTO).Name;
            if (storeName == ENUM_NAMES.EMPTY_STORE_NAME)
            {
                textBoxSearchCost.Enabled = false;
                btnSearchCost.Enabled = false;
                btnBuy.Enabled = false;
                btnSearchMinStore.Enabled = true;

                dtGridBuyerBatches.Columns[2].Visible = false;
                //dtGridBuyerBatches.Columns[3].Visible = false;
                dtGridBuyerBatches.Columns[4].Visible = false;


                dtGridBuyerBatches.Rows.Clear();
                int idxRow = 0;
                foreach (var item in Products)
                {
                    dtGridBuyerBatches.Rows.Add();
                    dtGridBuyerBatches.Rows[idxRow].Cells[0].Value = item.Id;
                    dtGridBuyerBatches.Rows[idxRow].Cells[1].Value = item.Name;
                    dtGridBuyerBatches.Rows[idxRow].Cells[2].Value = "";
                    dtGridBuyerBatches.Rows[idxRow].Cells[3].Value = "";
                    dtGridBuyerBatches.Rows[idxRow].Cells[4].Value = "";

                    idxRow++;
                }
            }
            else
            {
                textBoxSearchCost.Enabled = true;
                btnSearchCost.Enabled = true;
                btnBuy.Enabled = true;
                btnSearchMinStore.Enabled = false;


                dtGridBuyerBatches.Columns[2].Visible = true;
                //dtGridBuyerBatches.Columns[3].Visible = true;
                dtGridBuyerBatches.Columns[4].Visible = true;

                var selStoreId = (cmbBoxBuyerStores.SelectedItem as StoreDTO).Id;

                var batches = ProductBatches.FindAll(o => o.Store.Id == selStoreId);

                dtGridBuyerBatches.Rows.Clear();
                int idxRow = 0;
                foreach (var item in batches)
                {
                    dtGridBuyerBatches.Rows.Add();
                    dtGridBuyerBatches.Rows[idxRow].Cells[0].Value = item.Id;
                    dtGridBuyerBatches.Rows[idxRow].Cells[1].Value = item.Product.Name;
                    dtGridBuyerBatches.Rows[idxRow].Cells[2].Value = item.Price;
                    dtGridBuyerBatches.Rows[idxRow].Cells[3].Value = "";
                    dtGridBuyerBatches.Rows[idxRow].Cells[4].Value = "";

                    idxRow++;
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            UpdateAllData();
        }

        private async void btnAddProviderProduct_Click(object sender, EventArgs e)
        {
            if (txtBoxProviderProductName.Text.Count() == 0)
            {
                MessageBox.Show("Введите имя!", "Ошибка");
                return;
            }

            var name = txtBoxProviderProductName.Text;

            var res = await _cmds.AddProduct(new ProductForm(name));
            if (res.IsSuccess)
            {
                UpdateAllData();
                txtBoxProviderProductName.Text = "";
            }
        }

        private async void btnAddProviderStore_Click(object sender, EventArgs e)
        {
            var name = txtBoxProviderStoreName.Text;
            var address = txtBoxProviderStoreAddress.Text;

            if (name.Count() == 0)
            {
                MessageBox.Show("Введите имя!", "Ошибка");
                return;
            }

            var res = await _cmds.AddStore(new StoreForm(name, address));
            if (res.IsSuccess)
            {
                UpdateAllData();
                txtBoxProviderStoreAddress.Text = "";
                txtBoxProviderStoreName.Text = "";
            }
        }

        private async void btnProviderDelivery_Click(object sender, EventArgs e)
        {
            var listForm = MakeDelivery();

            var res = await _cmds.AddListProductBatch(listForm);
            if (res.IsSuccess)
            {
                UpdateAllData();
            }
            else
            {
                MessageBox.Show($"{res.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ProductBatchForm> MakeDelivery()
        {
            var list = new List<ProductBatchForm>();

            for (int i = 0; i < dtGridProviderProducts.Rows.Count; i++)
            {

                var cond1 = string.IsNullOrEmpty(dtGridProviderProducts.Rows[i].Cells[2].Value.ToString());
                var cond2 = string.IsNullOrEmpty(dtGridProviderProducts.Rows[i].Cells[3].Value.ToString());

                if (!(cond1 && cond2))
                {
                    int productId = Convert.ToInt32(dtGridProviderProducts.Rows[i].Cells[0].Value);
                    decimal price = Convert.ToDecimal(dtGridProviderProducts.Rows[i].Cells[2].Value);
                    int quantity = Convert.ToInt32(dtGridProviderProducts.Rows[i].Cells[3].Value);
                    var store = cmbBoxProviderStores.SelectedItem as StoreDTO;


                    list.Add(new ProductBatchForm(productId, store.Id, quantity, price));
                }


            }

            return list;
        }

        private async void cmbBoxBuyerStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAllCost.Text = string.Empty;
            await FillDataGridBuyerBatches();
        }

        private void cmbBoxProviderStores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtGridBuyerBatches_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbBoxBuyerStores.SelectedItem == null) return;

            var storeName = (cmbBoxBuyerStores.SelectedItem as StoreDTO).Name;
            if (storeName == ENUM_NAMES.EMPTY_STORE_NAME && e.ColumnIndex != 3) return;

            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[3].Value == null) return;
            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[3].Value.ToString() == "") return;

            int currentCount = Convert.ToInt32(dtGridBuyerBatches.Rows[e.RowIndex].Cells[3].Value);
            decimal currentPrice = Convert.ToDecimal(dtGridBuyerBatches.Rows[e.RowIndex].Cells[2].Value);

            dtGridBuyerBatches.Rows[e.RowIndex].Cells[4].Value = (currentCount * currentPrice);

            decimal allCost = 0;

            for (int i = 0; i < dtGridBuyerBatches.Rows.Count; i++)
            {
                if (dtGridBuyerBatches.Rows[i].Cells[3].Value.ToString() != "")
                {
                    int count = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[3].Value);
                    decimal price = Convert.ToDecimal(dtGridBuyerBatches.Rows[i].Cells[2].Value);

                    allCost = allCost + (count * price);
                }
            }

            textBoxAllCost.Text = allCost.ToString();
        }
    }
}
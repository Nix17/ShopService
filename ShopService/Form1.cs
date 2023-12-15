using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;

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

            FillDataGridProviderProducts();

            cmbBoxProviderStores.Items.Clear();
            cmbBoxProviderStores.Items.AddRange(Stores.ToArray());
            cmbBoxProviderStores.DisplayMember = "Name";
            cmbBoxProviderStores.ValueMember = "Id";
        }

        private void FillDataGridProviderProducts()
        {
            dtGridProviderProducts.Rows.Clear();
            int idxRow = 0;
            foreach (ProductDTO product in Products)
            {
                dtGridProviderProducts.Rows.Add();
                dtGridProviderProducts.Rows[idxRow].Cells[0].Value = product.Id;
                dtGridProviderProducts.Rows[idxRow].Cells[1].Value = product.Name;

                idxRow++;
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
    }
}
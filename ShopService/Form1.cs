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
        private bool isRefreshDtGVbyCmb = true;

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
            var selStoreId = (cmbBoxProviderStores.SelectedItem as StoreDTO).Id;

            var productIds = ProductBatches.Where(o => o.Store.Id == selStoreId).Select(o => o.Product.Id).ToList();

            var notAddedProducts = Products.FindAll(o => !productIds.Contains(o.Id));

            dtGridProviderProducts.Rows.Clear();
            int idxRow = 0;
            foreach (ProductDTO product in notAddedProducts)
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
            if (!isRefreshDtGVbyCmb)
            {
                isRefreshDtGVbyCmb = true;
                return;
            }

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

            foreach(var obj in listForm)
            {
                var res = await _cmds.AddProductBatch(obj);
                if (res.IsSuccess)
                {
                    UpdateAllData();
                }
                else
                {
                    MessageBox.Show($"{res.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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


        // TODO
        private async void cmbBoxProviderStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            await FillDataGridProviderProducts();
        }

        private void dtGridBuyerBatches_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbBoxBuyerStores.SelectedItem == null) return;

            var storeName = (cmbBoxBuyerStores.SelectedItem as StoreDTO).Name;
            if (storeName == ENUM_NAMES.EMPTY_STORE_NAME && e.ColumnIndex != 3) return;

            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[3].Value == null) return;
            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[3].Value.ToString() == "") return;
            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[2].Value == null) return;
            if (dtGridBuyerBatches.Rows[e.RowIndex].Cells[2].Value.ToString() == "") return;

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

        private void btnSearchMinStore_Click(object sender, EventArgs e)
        {
            // Словарь, в котором будут храниться - ИД товара (key) и количество (value)
            var dictProducts = new Dictionary<int, int>();

            for (int i = 0; i < dtGridBuyerBatches.Rows.Count; i++)
            {
                if (dtGridBuyerBatches.Rows[i].Cells[3].Value.ToString() != "")
                {
                    var key = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[0].Value);
                    var value = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[3].Value);
                    dictProducts.Add(key, value);
                }
            }

            // Словарь, в котором будут храниться - ИД магазина (key) и общая стоимость искомых товаров (количество * цена) (value)
            var dictStores = new Dictionary<int, decimal>();

            var storeIds = Stores.Select(x => x.Id);
            foreach (var storeId in storeIds)
            {
                var listProducts = ProductBatches.Where(o => o.Store.Id == storeId).ToList();

                var isPotentially = listProducts.FindAll(o => dictProducts.Keys.Contains(o.Product.Id));
                if (isPotentially.Count == dictProducts.Keys.Count)
                {
                    decimal totalCost = 0;
                    while (isPotentially.Count > 0)
                    {
                        bool isCanAdd = true;
                        var item = isPotentially.First();
                        var dictItem = dictProducts.FirstOrDefault(o => o.Key == item.Product.Id);
                        if (dictItem.Value > item.Quantity)
                        {
                            isCanAdd = false;
                            break;
                        }
                        totalCost = totalCost + (item.Price * dictItem.Value);
                        isPotentially.RemoveAt(0);
                    }

                    if (totalCost > 0) dictStores.Add(storeId, totalCost);
                }
            }

            if (dictStores.Count == 0)
            {
                MessageBox.Show("Нельзя найти товары в одном магазине!");
                return;
            }

            // Создаем список ключ-значение из словаря
            var sortedList = dictStores.ToList();

            // Сортируем список по значениям в убывающем порядке
            sortedList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            var findedId = sortedList[0].Key;



            for (int idx = 0; idx < cmbBoxBuyerStores.Items.Count; idx++)
            {
                if ((cmbBoxBuyerStores.Items[idx] as StoreDTO).Id == findedId)
                {
                    cmbBoxBuyerStores.SelectedIndex = idx;
                    isRefreshDtGVbyCmb = false;
                    break;
                }
            }

            foreach (var item in dictProducts)
            {
                var batch = ProductBatches.Find(o => o.Store.Id == findedId && o.Product.Id == item.Key);
                for (int idx = 0; idx < dtGridBuyerBatches.Rows.Count; idx++)
                {
                    var dtIdCol = Convert.ToInt32(dtGridBuyerBatches.Rows[idx].Cells[0].Value);
                    if (dtIdCol == batch.Id)
                    {
                        dtGridBuyerBatches.Rows[idx].Cells[3].Value = item.Value;
                        break;
                    }
                }
            }

        }

        private async void btnBuy_Click(object sender, EventArgs e)
        {
            // key - ключ ProductBatch, value - количество товара
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < dtGridBuyerBatches.Rows.Count; i++)
            {
                if (dtGridBuyerBatches.Rows[i].Cells[3].Value == null) continue;
                if (dtGridBuyerBatches.Rows[i].Cells[3].Value.ToString() == "") continue;

                int batchId = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[0].Value);
                int count = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[3].Value);

                dict.Add(batchId, count);
            }

            foreach (var item in dict)
            {
                var batchItem = ProductBatches.Find(o => o.Id == item.Key);
                if (batchItem.Quantity < item.Value)
                {
                    MessageBox.Show("Не хватает товаров на складе!");
                    return;
                }
            }

            var res = await _cmds.ReduceQuantityProductBatch(dict);
            if (res.IsSuccess)
            {
                UpdateAllData();
            }
            else
            {
                MessageBox.Show(res.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCost_Click(object sender, EventArgs e)
        {
            var store = (cmbBoxBuyerStores.SelectedItem as StoreDTO);
            if (store.Name == ENUM_NAMES.EMPTY_STORE_NAME) return;

            if (textBoxSearchCost.Text == "") return;

            int searchCost = Convert.ToInt32(textBoxSearchCost.Text);

            for(int i = 0; i < dtGridBuyerBatches.Rows.Count; i++)
            {
                if (dtGridBuyerBatches.Rows[i].Cells[2].Value == null) return;
                if (dtGridBuyerBatches.Rows[i].Cells[2].Value.ToString() == "") return;

                int price = Convert.ToInt32(dtGridBuyerBatches.Rows[i].Cells[2].Value);
                int count = searchCost / price;
                decimal cost = price * count;

                dtGridBuyerBatches.Rows[i].Cells[3].Value = count;
                dtGridBuyerBatches.Rows[i].Cells[4].Value = cost;
            }
        }
    }
}
using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.Services.Interfaces;

namespace ShopService
{
    public partial class Form1 : Form
    {
        private IShopCommands _cmds;

        private List<ProductDTO> _products = new List<ProductDTO>();

        public Form1(IShopCommands commands)
        {
            _cmds = commands;

            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var res = await _cmds.GetAllProducts();
            if (res.IsSuccess)
            {
                _products = res.Result;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.Product;

public class ProductForm
{
    public ProductForm()
    {
    }

    public ProductForm(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class ProductEntity : BaseEntity
{
    public ProductEntity()
    {
    }

    public ProductEntity(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class StoreEntity : BaseEntity
{
    public StoreEntity()
    {
    }

    public StoreEntity(string name, string address = "")
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }
    public string Address { get; set; }
}

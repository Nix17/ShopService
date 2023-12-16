using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.Store;

public class StoreDTO : BaseDTO
{
    public StoreDTO()
    {
    }

    public StoreDTO(string name, string address = "")
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }
    public string Address { get; set; }
}

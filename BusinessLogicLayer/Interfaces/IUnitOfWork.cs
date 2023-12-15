using BusinessLogicLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces;

public interface IUnitOfWork
{
    IProductRepo ProductRepo { get; }
    IStoreRepo StoreRepo { get; }
    IProductBatchRepo ProductBatchRepo { get; }

    Task<bool> SaveChangesAsync();
}

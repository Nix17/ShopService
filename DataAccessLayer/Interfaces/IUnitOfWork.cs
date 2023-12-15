using DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces;

public interface IUnitOfWork
{
    IProductRepo ProductRepo { get; }
    IStoreRepo StoreRepo { get; }
    IProductBatchRepo ProductBatchRepo { get; }

    Task<bool> SaveChangesAsync();
    void Dispose();
}

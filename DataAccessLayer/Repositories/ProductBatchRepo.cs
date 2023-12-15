using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class ProductBatchRepo : GenericRepository<ProductBatchEntity>, IProductBatchRepo
{
    public ProductBatchRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

﻿using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class ProductRepo : GenericRepository<ProductEntity>, IProductRepo
{
    public ProductRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

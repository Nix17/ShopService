using AutoMapper;
using DataAccessLayer.Contexts;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    private IProductRepo _productRepo;
    private IStoreRepo _storeRepo;
    private IProductBatchRepo _productBatchRepo;

    public UnitOfWork(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IProductRepo ProductRepo => _productRepo ?? new ProductRepo(_context);
    public IStoreRepo StoreRepo => _storeRepo ?? new StoreRepo(_context);
    public IProductBatchRepo ProductBatchRepo => _productBatchRepo ?? new ProductBatchRepo(_context);



    public async Task<bool> SaveChangesAsync() { return (await _context.SaveChangesAsync()) > 0; }
    public void Dispose() { _context.Dispose(); }
}

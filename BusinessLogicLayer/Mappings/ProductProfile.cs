using AutoMapper;
using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.Store;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductDTO>();
        CreateMap<ProductForm, ProductEntity>();
    }
}

using AutoMapper;
using BusinessLogicLayer.DTO.ProductBatch;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappings;

public class ProductBatchProfile : Profile
{
    public ProductBatchProfile()
    {
        CreateMap<ProductBatchEntity, ProductBatchDTO>();

        CreateMap<ProductBatchForm, ProductBatchEntity>()
            //.ForMember(dest => dest.)
            .AfterMap((f, e) => e.Price = Math.Round(f.Price, 2));
            ;
    }
}

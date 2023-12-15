using AutoMapper;
using BusinessLogicLayer.DTO.Store;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappings;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<StoreEntity, StoreDTO>();
        CreateMap<StoreForm, StoreEntity>();
    }
}

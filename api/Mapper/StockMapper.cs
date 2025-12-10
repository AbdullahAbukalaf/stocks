using api.DTO.Stock;
using api.Models;
using AutoMapper;

namespace api.Mapper
{
    public class StockMapper : Profile
    {
        public StockMapper()
        {
            CreateMap<Stock, StockDTO>(); // entity -> API
            CreateMap<CreateStockDTO, Stock>();               // API -> entity
            CreateMap<UpdateStockDTO, Stock>()               // optional: ignore nulls on patchy updates
                .ForAllMembers(o => o.Condition((src, dest, val) => val != null));
        }
    }
}

using AutoMapper;
using Panaderia.Api.DTOs;
using Panaderia.Api.Models;

namespace Panaderia.Api.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoCreateDto, Producto>();
        }
    }
}

using AutoMapper;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;

namespace DevIOApi.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
            CreateMap<Marca, MarcaCompletaViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloCompletoViewModel>().ReverseMap();
        }

    }
}

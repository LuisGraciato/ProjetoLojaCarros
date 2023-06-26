using AutoMapper;
using DevIOApi.ViewModels;
using DevIOApi.ViewModels.ViewModelsCompletas;
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
            CreateMap<Carro, CarroViewModel>().ReverseMap();
            CreateMap<Carro, CarroCompletoViewModel>().ReverseMap();
            CreateMap<Adicionais, AdicionaisViewModel>().ReverseMap();
            CreateMap<Adicionais, AdicionaisCompletoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteCompletoViewModel>().ReverseMap();
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Funcionario, FuncionarioCompletoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoCompletoViewModel>().ReverseMap();
            CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
            CreateMap<Telefone, TelefoneCompletoViewModel>().ReverseMap();
            CreateMap<NotaFiscal, NotaFiscalViewModel>().ReverseMap();
            CreateMap<NotaFiscal, NotaFiscalCompletaViewModel>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<CarroVendaViewModel, VendaCarro>().ReverseMap();
            CreateMap<VendaFormaPagamentoViewModel, VendaFormaPagamento>().ReverseMap();
            CreateMap<CarroAdicionaisViewModel, CarroAdicionais>().ReverseMap();

        }

    }
}

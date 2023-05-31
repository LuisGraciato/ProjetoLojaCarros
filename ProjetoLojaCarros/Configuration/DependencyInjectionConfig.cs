﻿using DevIoBusiness.Intefaces;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Services;
using DevIoData.Context;
using DevIoData.Repository;

namespace DevIOApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<ICarroAdicionaisRepository, CarroAdicionaisRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<ICarroAdicionaisService, CarroAdicionaisService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            return services;
        }
    }
}

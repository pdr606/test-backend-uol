using Microsoft.EntityFrameworkCore;
using uol_backend.API.Infraestrutura.BancoDeDados;
using uol_backend.API.Infraestrutura.Repositorio;
using uol_backend.API.Servicos.Factory;
using uol_backend.API.Servicos.Jogador;
using uol_backend.API.Servicos.LeitorArquivos;

namespace uol_backend.API.Config
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IJogadorRepositorio, JogadorRepositorio>();

            services.AddTransient<LerArquivoVingadoresJSON>();
            services.AddTransient<LerArquivoLigaDaJusticaXML>();

            services.AddSingleton<LeitorArquivosFactory>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<BancoDataContext>(opt =>
            {
                opt.UseInMemoryDatabase("uol_desafio_backend");
            });

            return services;
        }
    }
}

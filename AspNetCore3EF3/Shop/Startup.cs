using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Entity em memória
            services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("Database"));

            //Injeção de Dependência do Banco
            //Temos as opções AddSingleton, AddTransient, AddScoped.
            //AddSingleton abre uma única conexão (Se por algum motivo cair a conexão será prejudicial para o sistema)
            //AddTransient abre/fecha a conexão mas não busca da memória, ou seja, acaba gerando diversas conexões 
            //AddScoped para abre/fecha a conexão do banco e mantem na memória durante a requisição (evita o estouro no limite de conexões do banco)            
            services.AddScoped<DataContext, DataContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

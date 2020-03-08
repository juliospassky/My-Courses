using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            //Permite requisições localhost
            services.AddCors();
            
            //Zipa tudo que é application/json
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });
            
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Entity em memória
            services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("Database"));

            //Usando o SQLServer
            // services.AddDbContext<DataContext>(o => o.UseSqlServer(Configuration.GetConnectionString("connectionString")));


            //Injeção de Dependência do Banco
            //Temos as opções AddSingleton, AddTransient, AddScoped.
            //AddSingleton abre uma única conexão (Se por algum motivo cair a conexão será prejudicial para o sistema)
            //AddTransient abre/fecha a conexão mas não busca da memória, ou seja, acaba gerando diversas conexões 
            //AddScoped para abre/fecha a conexão do banco e mantem na memória durante a requisição (evita o estouro no limite de conexões do banco)            
            services.AddScoped<DataContext, DataContext>(); //Por default é AddScoped, não é necessáio essa linha

            //Documentação da API
            services.AddSwaggerGen( o =>
            o.SwaggerDoc("v1", new OpenApiInfo{Title = "Shop Api", Version = "v1"}));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop Api V1"));

            app.UseRouting();

            app.UseCors(o => o
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using KnockKnock.Api.Middleware;
using KnockKnock.Logic;
using KnockKnock.Logic.Concrete;
using KnockKnock.Service;
using KnockKnock.Service.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace KnockKnock.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Knock Knock", Version = "v1" }); });

            services.AddSingleton(Configuration);

            services.AddScoped<IFibonacciService, FibonacciService>();
            services.AddScoped<IReverseWordsService, ReverseWordsService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITriangleTypeService, TriangleTypeService>();
            services.AddScoped<IFibonacciLogic, FibonacciLogic>();
            services.AddScoped<IReverseWordsLogic, ReverseWordsLogic>();
            services.AddScoped<ITokenLogic, TokenLogic>();
            services.AddScoped<IShapeFinderLogic, ShapeFinderLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Knock Knock V1"); });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc(route => route.MapRoute("default","swagger/"));
        }
    }
}
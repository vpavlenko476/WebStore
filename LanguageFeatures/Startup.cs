using Store.DAL.Contracts;
using Store.Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.DAL.Implementation.Context;
using Store.DAL.Implementation.Repositories;
using Store.DAL.Implementation.DataInit;
using AutoMapper;

namespace LanguageFeatures
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(Configuration["Data:Store:ConnectionString"])); ;
			services.AddScoped<IBaseRepo<ProductEntity>, BaseRepo<ProductEntity>>();
			services.AddAutoMapper(typeof(Startup));
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();			
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "pagination",
					pattern: "products/page{productPage}",
					defaults: new { Controller = "Product", action = "List" });
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Product}/{action=List}/{id?}");
			});
		}
	}
}

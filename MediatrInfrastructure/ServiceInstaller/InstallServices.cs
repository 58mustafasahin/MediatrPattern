using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.Concrete;
using MediatrDal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MediatrInfrastructure.ServiceInstaller
{
    public static class InstallServices
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //DbInstall
            services.AddDbContextPool<IMediatrDbContext, MediatrDbContext>(options =>
                options.UseSqlServer("Server=.;Database=MediatrDB;Trusted_Connection=True;"));

            //MediatrInstall
            var assembly = AppDomain.CurrentDomain.Load("MediatrBusiness");
            services.AddMediatR(assembly);
            //SwaggerInstall
            services.AddSwaggerGen();
        }
    }
}

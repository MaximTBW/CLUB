using CLUB.API.Infrastructures;
using CLUB.CONTEXT;
using Microsoft.EntityFrameworkCore;

namespace CLUB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<AccessoriesExceptionFilter>();
            }).AddControllersAsServices();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.GetSwaggerDocument();

            builder.Services.AddDependences();

            var conString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContextFactory<ClubContext>(options => options.UseSqlServer(conString),
                ServiceLifetime.Scoped);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.GetSwaggerDocumentUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

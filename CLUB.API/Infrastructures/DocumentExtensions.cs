using Microsoft.OpenApi.Models;

namespace CLUB.API.Infrastructures
{
    /// <summary>
    /// Дефенишены, для поиска по сущностям
    /// </summary>
    public static class DocumentExtensions
    {
        /// <summary>
        /// Документ для создания страниц со сущностями и xml файлом с комментарием
        /// </summary>
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Clients", new OpenApiInfo { Title = "Сущность клиентов", Version = "v1" });
                c.SwaggerDoc("FreeMens", new OpenApiInfo { Title = "Сущность работника", Version = "v1" });
                c.SwaggerDoc("Orders", new OpenApiInfo { Title = "Сущность заказов", Version = "v1" });
                c.SwaggerDoc("Services", new OpenApiInfo { Title = "Сущность услуг", Version = "v1" });
                c.SwaggerDoc("WherePays", new OpenApiInfo { Title = "Сущность реквизитов", Version = "v1" });
                c.SwaggerDoc("WherePlases", new OpenApiInfo { Title = "Сущность мест", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "CLUB.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        /// <summary>
        /// Документы задающий путь по разным страницам
        /// </summary>
        public static void GetSwaggerDocumentUI(this WebApplication app)
        {
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Clients/swagger.json", "Клиенты");
                x.SwaggerEndpoint("FreeMens/swagger.json", "Работники");
                x.SwaggerEndpoint("Orders/swagger.json", "Заказы");
                x.SwaggerEndpoint("Services/swagger.json", "Услуги");
                x.SwaggerEndpoint("WherePays/swagger.json", "Реквизиты");
                x.SwaggerEndpoint("WherePlases/swagger.json", "Места");
            });
        }
    }
}

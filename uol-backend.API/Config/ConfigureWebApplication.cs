namespace uol_backend.API.Config
{
    public static class ConfigureWebApplication
    {
        public static WebApplication AddGlobalWebApplicationConfig(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            return app;
        }
    }
}

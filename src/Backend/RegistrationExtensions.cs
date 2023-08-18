namespace Backend;

static class RegistrationExtensions
{
    public static void UseCustomizedSwagger(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api-docs/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "api-docs/swagger";
            });
        }
    }

    public static void InitAndSeedBackendContest(this WebApplication app)
    {
        // Make sure, that the database exists
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<BackendContext>();
        context.Database.EnsureCreated();

        if (app.Environment.IsDevelopment())
            context.Seed();
    }
}

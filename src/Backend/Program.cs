var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddReactReverseProxy();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Setup Database
var connectionString = builder.Configuration.GetConnectionString("Backend") ?? throw new ArgumentNullException("Backend Connectionsting not set");
builder.Services.AddDbContext<BackendContext>(x => x.UseSqlite(connectionString));

var app = builder.Build();


app.InitAndSeedBackendContest();

// Register Swagger UI
app.UseCustomizedSwagger();

// Register all the routes for the api
app.UseApiRoutes();

// Register Reverse Proxy for React client
app.UseReactRevereseProxy();

// Run the application
app.Run();

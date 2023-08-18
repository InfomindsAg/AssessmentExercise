namespace Backend.Infrastructure.Database;

public class BackendContext : DbContext
{
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerCategory> CustomerCategories => Set<CustomerCategory>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();

    public BackendContext(DbContextOptions<BackendContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public void Seed()
    {
        new CustomerCategorySeeding(this).Seed();
        new DepartmentSeeding(this).Seed();

        new SupplierSeeding(this).Seed();
        new CustomerSeeding(this).Seed();
        new EmployeeSeeding(this).Seed();
    }
}
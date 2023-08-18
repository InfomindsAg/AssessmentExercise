namespace Backend.Infrastructure.Database;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
}

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Address).HasMaxLength(200);
        builder.Property(s => s.Email).HasMaxLength(50);
        builder.Property(s => s.Phone).HasMaxLength(20);
    }
}

class SupplierSeeding : SeedEntity<BackendContext, Supplier>
{
    public SupplierSeeding(BackendContext context) : base(context)
    {
    }

    protected override IEnumerable<Supplier> GetSeedItems()
    {
        for (var i = 0; i < 10; i++)
        {
            var faker = new Faker("it");
            yield return new Supplier
            {
                Name = faker.Company.CompanyName(),
                Address = faker.Address.FullAddress(),
                Email = faker.Internet.Email(),
                Phone = faker.Phone.PhoneNumber(),
            };
        }
    }

}
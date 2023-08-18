namespace Backend.Infrastructure.Database;

public class CustomerCategory
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Description { get; set; } = "";
}

public class CustomerCategoryConfiguration : IEntityTypeConfiguration<CustomerCategory>
{
    public void Configure(EntityTypeBuilder<CustomerCategory> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Code).IsRequired().HasMaxLength(25);
        builder.Property(s => s.Description).HasMaxLength(200);
    }
}

class CustomerCategorySeeding : SeedEntity<BackendContext, CustomerCategory>
{
    public CustomerCategorySeeding(BackendContext context) : base(context)
    {
    }

    protected override IEnumerable<CustomerCategory> GetSeedItems()
    {
        for (var i = 0; i < 7; i++)
        {
            var faker = new Faker("it");
            yield return new CustomerCategory
            {
                Code = faker.Random.AlphaNumeric(5).ToUpper(),
                Description = faker.Commerce.Department(1),
            };
        }
    }

}
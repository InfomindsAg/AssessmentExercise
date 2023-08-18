namespace Backend.Infrastructure.Database;

public class Department
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Description { get; set; } = "";
}

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Code).IsRequired().HasMaxLength(25);
        builder.Property(s => s.Description).HasMaxLength(200);
    }
}

class DepartmentSeeding : SeedEntity<BackendContext, Department>
{
    public DepartmentSeeding(BackendContext context) : base(context)
    {
    }

    protected override IEnumerable<Department> GetSeedItems()
    {
        for (var i = 0; i < 5; i++)
        {
            var faker = new Faker("it");
            yield return new Department
            {
                Code = faker.Random.AlphaNumeric(3).ToUpper(),
                Description = faker.Commerce.Department(1),
            };
        }
    }

}
namespace Backend.Infrastructure.Database;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Iban { get; set; } = "";

    public int? CustomerCategoryId { get; set; }
    public CustomerCategory? CustomerCategory { get; set; }
}

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Address).HasMaxLength(200);
        builder.Property(s => s.Email).HasMaxLength(50);
        builder.Property(s => s.Phone).HasMaxLength(20);
        builder.Property(s => s.Iban).HasMaxLength(34);
        builder.HasOne(q => q.CustomerCategory).WithMany().HasForeignKey(q => q.CustomerCategoryId);
    }
}

class CustomerSeeding : SeedEntity<BackendContext, Customer>
{
    List<int?> CustomerCategoryIdList;

    public CustomerSeeding(BackendContext context) : base(context)
    {
        CustomerCategoryIdList = context.CustomerCategories.Select(q => (int?)q.Id).ToList();
        CustomerCategoryIdList.Add(null);
    }

    protected override IEnumerable<Customer> GetSeedItems()
    {
        for (var i = 0; i < 50; i++)
        {
            var faker = new Faker("it");
            yield return new Customer
            {
                Name = faker.Company.CompanyName(),
                Address = faker.Address.FullAddress(),
                Email = faker.Internet.Email(),
                Phone = faker.Phone.PhoneNumber(),
                Iban = faker.Finance.Iban(),
                CustomerCategoryId = faker.PickRandom(CustomerCategoryIdList),
            };
        }
    }

}

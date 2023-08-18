namespace Backend.Infrastructure.Database;

public class Employee
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Address { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Code).IsRequired().HasMaxLength(10);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Address).HasMaxLength(200);
        builder.Property(s => s.Email).HasMaxLength(50);
        builder.Property(s => s.Phone).HasMaxLength(20);
        builder.HasOne(q => q.Department).WithMany().HasForeignKey(q => q.DepartmentId);
    }
}

class EmployeeSeeding : SeedEntity<BackendContext, Employee>
{
    List<int?> DepartmentIdList;

    public EmployeeSeeding(BackendContext context) : base(context)
    {
        DepartmentIdList = context.Departments.Select(q => (int?)q.Id).ToList();
        DepartmentIdList.Add(null);
    }

    protected override IEnumerable<Employee> GetSeedItems()
    {
        for (var i = 0; i < 50; i++)
        {
            var faker = new Faker("it");
            yield return new Employee
            {
                Code = faker.Random.AlphaNumeric(10).ToUpper(),
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                Address = faker.Address.FullAddress(),
                Email = faker.Internet.Email(),
                Phone = faker.Phone.PhoneNumber(),
                DepartmentId = faker.PickRandom(DepartmentIdList),
            };
        }
    }

}
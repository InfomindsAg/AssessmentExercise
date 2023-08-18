namespace Backend.Shared.Database;

abstract class SeedEntity<SeedContext, T> where SeedContext : DbContext where T : class
{
    private readonly DbSet<T> Set;
    private readonly SeedContext Context;

    public SeedEntity(SeedContext context)
    {
        Set = context.Set<T>();
        Context = context;
    }

    public void Seed()
    {
        if (Set.Any())
            return;

        foreach(var item in GetSeedItems())
            Set.Add(item);

        Context.SaveChanges();
    }

    protected abstract IEnumerable<T> GetSeedItems();
}
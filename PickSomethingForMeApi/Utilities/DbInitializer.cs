using PickSomethingForMeApi.Data;

namespace PickSomethingForMeApi.Utilities;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        // Add code to seed data if needed.
    }
}


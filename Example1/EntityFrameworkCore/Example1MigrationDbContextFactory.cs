using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Example1.EntityFrameworkCore
{
    public class Example1MigrationDbContextFactory : IDesignTimeDbContextFactory<Example1MigrationDbContext>
    {
        public Example1MigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<Example1MigrationDbContext>()
                .UseSqlite(configuration.GetConnectionString("ExampleContext"));

            return new Example1MigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using DemoListQuestions.Models;

namespace DemoListQuestions.Helpers;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Choice>();
        modelBuilder.Entity<Question>();
        modelBuilder.Entity<QuestionChoice>().HasKey(pk => new { pk.IdQuestion, pk.IdChoice });
    }
}
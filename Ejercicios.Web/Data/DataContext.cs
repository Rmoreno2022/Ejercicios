using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Comment> Comments { get; set; }
      
        public DbSet<Event> Events { get; set; }
        public DbSet<MemoryGame> MemoryGames { get; set; }
        public DbSet<MemoryCard> MemoryCards { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyOption> SurveyOptions { get; set; }
        public DbSet<SurveyVote> SurveyVotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica decimal(18,2) a TODAS las propiedades decimal del proyecto
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

     

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Azure.Identity;
using H5ServersideMonday.Components.Models;
using H5ServersideMonday.Components.Pages;
using Microsoft.EntityFrameworkCore;

namespace H5ServersideMonday.Components.Context
{
    public class MyContext : DbContext
    {
        public DbSet<CprEntry> Cpr { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }

        #region Required
        public MyContext() { }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CprEntry>();
            modelBuilder.Entity<ToDoList>();

        }
        #endregion
    }

}

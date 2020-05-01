using Microsoft.EntityFrameworkCore;

namespace MediatRDemo.Data
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Matt",
                    LastName = "Kick"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Bill",
                    LastName = "Gats"
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Satya",
                    LastName = "Nadella"
                }
         );
        }
    }
}

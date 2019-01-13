using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyCS") { }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Authorship> Authorships { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCopy> BookCopies { get; set; }

        public DbSet<BookKeyWord> BookKeyWords { get; set; }

        public DbSet<BookSubject> BookSubjects { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<KeyWord> KeyWords { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
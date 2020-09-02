using MyLibrary.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Context
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Press> Press { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SCard> SCards { get; set; }
        public DbSet<ECard> ECards { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

        public MyAppDbContext(DbContextOptions options)
            : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			#region Fluent for Students table
			modelBuilder.Entity<Student>()
                .HasOne(st => st.Group)
                .WithMany(gr => gr.Students)
                .HasPrincipalKey(gr => gr.Id)
                .HasForeignKey(st => st.GroupId);

            //modelBuilder.Entity<Student>()
            //    .Property(p => p.Id)
            //    .IsRequired(true)
            //    .HasDefaultValueSql("NEWID()");
			#endregion

			#region Fluent for Group table
			modelBuilder.Entity<Group>()
                .HasOne(gr => gr.Faculty)
                .WithMany(f => f.Groups)
                .HasPrincipalKey(f=>f.Id)
                .HasForeignKey(gr => gr.FacultyId);
			#endregion

			#region Fluent for Book table
			modelBuilder.Entity<Book>()
                .HasOne(p => p.Press)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.PressId);

            modelBuilder.Entity<Book>()
               .HasOne(p => p.Theme)
               .WithMany(b => b.Books)
               .HasForeignKey(b => b.ThemeId);

            modelBuilder.Entity<Book>()
              .HasOne(p => p.Category)
              .WithMany(b => b.Books)
              .HasForeignKey(b => b.CategoryId);
			#endregion

			#region Fluent for BookAuthor table
			modelBuilder.Entity<BookAuthor>()
               .HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.Entity<BookAuthor>()
              .HasOne(p => p.Book)
              .WithMany(b => b.BookAuthor)
              .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookAuthor>()
              .HasOne(p => p.Author)
              .WithMany(b => b.BookAuthor)
              .HasForeignKey(b => b.AuthorId);
            #endregion

            #region Fluent for Category table
            modelBuilder.Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

			#endregion


		}
	}

}

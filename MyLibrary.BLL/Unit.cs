using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Context;
using MyLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.BLL
{
    public static class Unit
    {
        static Unit()
        {
            _context = new MyAppDbContext(
                new DbContextOptionsBuilder<MyAppDbContext>()
                    .UseSqlServer(new SqlConnectionStringBuilder
                    {
                        DataSource = "127.0.0.1",
                        InitialCatalog = "Univercity",
                        IntegratedSecurity = true
                    }.ConnectionString)
                    .Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            AuthorRepository = new AuthorRepository(_context);
            BookRepository = new BookRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            DepartmentRepository = new DepartmentRepository(_context);
            ECardRepository = new ECardsRepository(_context);
            EmployeeRepository = new EmploeeRepository(_context);
            FacultyRepository = new FacultyRepository(_context);
            GroupRepository = new GroupRepository(_context);
            LibrarianRepository = new LibrarianRepository(_context);
            PressRepository = new PressRepository(_context);
            SCardRepository = new SCardsRepository(_context);
            StudentRepository = new StudentRepository(_context);
            ThemeRepository = new ThemeRepository(_context);
        }

        public static MyAppDbContext _context { get; }
        public static IAuthorRepository AuthorRepository { get; }
        public static IBookRepository BookRepository { get; }
        public static ICategoryRepository CategoryRepository { get; }
        public static IDepartmentRepository DepartmentRepository { get; }
        public static IECardRepository ECardRepository { get; }
        public static IEmployeeRepository EmployeeRepository { get; }
        public static IFacultyRepository FacultyRepository { get; }
        public static IGroupRepository GroupRepository { get; }
        public static ILibrarianRepository LibrarianRepository { get; }
        public static IPressRepository PressRepository { get; }
        public static ISCardRepository SCardRepository { get; }
        public static IStudentRepository StudentRepository { get; }
        public static IThemeRepository ThemeRepository { get; }
    }
}

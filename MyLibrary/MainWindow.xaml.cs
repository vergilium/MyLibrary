using MyLibrary.Context;
using MyLibrary.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyLibrary.BLL;
using MyLibrary.ViewModels;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
			//Unit.ThemeRepository.AddItemAsync(new Theme { Name = "C#" });
			//Unit.CategoryRepository.AddItemAsync(new Category { Name = "Programming" });
			//Unit.PressRepository.AddItemAsync(new Press { Name = "ITStep" });
			//Unit.AuthorRepository.AddItemAsync(new Author { FirstName = "Olexandr", LastName = "Kobelchak" });
			Unit.BookRepository.AddItemAsync(new Book {
				Name = "WPF",
				CategoryId = Unit.CategoryRepository.AllItems.Where(n => n.Name == "Programming").FirstOrDefault().Id,
				ThemeId = Unit.ThemeRepository.AllItems.Where(t => t.Name == "C#").FirstOrDefault().Id,
				PressId = Unit.PressRepository.AllItems.Where(p => p.Name == "ITStep").FirstOrDefault().Id,
				BookAuthor = null
			});

			//var Books = BookModel.GetAllBookVM();
			InitializeComponent();

			//dg_books.ItemsSource = Books;
		}
    }
}

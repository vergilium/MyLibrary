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

		public class _Theme {
			public string Name { get; set; }
			public List<string> themes { get; set; }
		}
		public MainWindow()
        {
			//DbInit();

			List<_Theme> categories = new List<_Theme>();
			var Themes = ThemeModel.GetParrentsVM();
			foreach(var n in Themes) {
				categories.Add(new _Theme{
					Name = n.Name,
					themes = new List<string>(ThemeModel.GetSubThemesVM(n.Id).Select(n=>n.Name))
				});
			}


			var Books = BookModel.GetAllBookVM();
			
			InitializeComponent();
			trv_CategoriesThemes.ItemsSource = categories;
			dg_books.ItemsSource = Books;
		}

		public void DbInit() {
			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme { Name = "Programming"})).Wait();
			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme { Name = "Design" })).Wait();
			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme { Name = "IT technology"})).Wait();

			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme { Name = "C++", 
				ParrentId = Unit.ThemeRepository.AllItems
					.Where(n => n.Name == "Programming")
					.FirstOrDefault().Id 
			})).Wait();

			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme { Name = "C#", 
				ParrentId = Unit.ThemeRepository.AllItems
					.Where(n => n.Name == "Programming")
					.FirstOrDefault().Id 
			})).Wait();

			Task.Run(() => Unit.ThemeRepository.AddItemAsync(new Theme {
				Name = "Photoshop",
				ParrentId = Unit.ThemeRepository.AllItems
					.Where(n => n.Name == "Design")
					.FirstOrDefault().Id
			})).Wait();

			Task.Run(() => Unit.PressRepository.AddItemAsync(new Press { Name = "ITStep" })).Wait();
			Task.Run(() => Unit.PressRepository.AddItemAsync(new Press { Name = "Press1" })).Wait();
			Task.Run(() => Unit.PressRepository.AddItemAsync(new Press { Name = "Press2" })).Wait();
			Task.Run(() => Unit.AuthorRepository.AddItemAsync(new Author { FirstName = "Olexandr", LastName = "Kobelchak" })).Wait();
			Task.Run(() => Unit.AuthorRepository.AddItemAsync(new Author { FirstName = "Oleksii", LastName = "Maloivan" })).Wait();
			Task.Run(() => Unit.AuthorRepository.AddItemAsync(new Author { FirstName = "Linus", LastName = "Torvalds" })).Wait();
			Task.Run(() => Unit.BookRepository.AddItemAsync(new Book {
				Name = "WPF",
				ThemeId = Unit.ThemeRepository.AllItems.Where(t => t.Name == "C#").FirstOrDefault().Id,
				PressId = Unit.PressRepository.AllItems.Where(p => p.Name == "ITStep").FirstOrDefault().Id,
				BookAuthor = null
			})).Wait();
		}
    }
}

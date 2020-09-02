using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary.ViewModels;
using System.Linq;

namespace MyLibrary.BLL {
	public class CategoryModel {
		public Guid Id { get; set; }
		public string Name { get; set; }

		public CategoryModel(Category category) {
			Id = category.Id;
			Name = category.Name;
		}

		public static implicit operator CategoryVM(CategoryModel model) {
			return new CategoryVM { 
				Id = model.Id,
				Name = model.Name
			};
		}

		public static IEnumerable<CategoryModel> GetAll() {
			return Unit.CategoryRepository.AllItems
				.Select(c => new CategoryModel(c));
		}
	}
}

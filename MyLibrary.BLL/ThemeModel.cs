using MyLibrary.Entities;
using MyLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace MyLibrary.BLL {
	public class ThemeModel {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid? ParrentId { get; set; }
		public ThemeModel Parrent { get; set; }

		public ThemeModel(Theme theme) {
			Id = theme.Id;
			Name = theme.Name;
			ParrentId = theme.ParrentId;
			if (theme.Parrent != null)
				Parrent = new ThemeModel(theme.Parrent);
			else Parrent = null;
		}

		public static implicit operator ThemeVM(ThemeModel model) {
			return new ThemeVM {
				Id = model.Id,
				Name = model.Name
			};
		}

		public static IEnumerable<ThemeModel> GetAll() {
			return Unit.ThemeRepository.AllItems
				.Select(t => new ThemeModel(t))
				.ToList();
		}

		public static IEnumerable<ThemeVM> GetAllVM() {
			return Unit.ThemeRepository.AllItems
				.Select(t => (ThemeVM) new ThemeModel(t))
				.ToList();
		}

		public static IEnumerable<ThemeVM> GetSubThemesVM(Guid parrentId) {
			return Unit.ThemeRepository.AllItems
				.Where(p => p.ParrentId == parrentId)
				.Select(t=> (ThemeVM) new ThemeModel(t))
				.ToList();
		}

		public static IEnumerable<ThemeVM> GetParrentsVM() {
			return Unit.ThemeRepository.AllItems
				.Where(p => p.ParrentId == null)
				.Select(t => (ThemeVM)new ThemeModel(t))
				.ToList();
		}


	}
}

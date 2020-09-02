using MyLibrary.Entities;
using MyLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary.BLL {
	public class DepartmentModel {
		public Guid Id { get; set; }
		public string Name { get; set; }

		public DepartmentModel(Department department) {
			Id = department.Id;
			Name = department.Name;
		}

		public static implicit operator DepartmentVM(DepartmentModel model) {
			return new DepartmentVM {
				Id = model.Id,
				Name = model.Name
			};
		}

		public static IEnumerable<DepartmentModel> GetAll() {
			return Unit.DepartmentRepository.AllItems
				.Select(d => new DepartmentModel(d));
		}
	}
}

using MyLibrary.Entities;
using MyLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MyLibrary.BLL {
	public class EmployeeModel {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public EmployeeModel(Employee model) {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            MiddleName = model.MiddleName;
            Email = model.Email;
            Address = model.Address;
            DepartmentName = model.Department.Name;
        }

        public static implicit operator EmployeeVM(EmployeeModel model) {
            return new EmployeeVM {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                Address = model.Address,
                DepartmentName = model.DepartmentName
            };
        }

        public static IEnumerable<EmployeeModel> GetAll() {
            return Unit.EmployeeRepository.AllItems
                .Include(d => d.Department)
                .Select(e => new EmployeeModel(e));
        }
    }
}

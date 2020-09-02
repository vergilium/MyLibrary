using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.ViewModels {
	public class EmployeeVM {
		public Guid Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using MyLibrary.Entities;
using MyLibrary.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.BLL
{
    public class FacultyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public FacultyModel(Faculty faculty) {
            Id = faculty.Id;
            Name = faculty.Name;
        }

        public static implicit operator FacultyVM(FacultyModel model) {
            return new FacultyVM {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static IEnumerable<FacultyModel> GetAll() {
            return Unit.FacultyRepository.AllItems
                .Select(s => new FacultyModel(s))
                .ToList();
        }
    }
}

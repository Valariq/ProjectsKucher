using EmployeesApp;

using System;
using System.Collections.Generic;
using System.Linq;

namespace company.db
{
    public static class EmployeeFilterService
    {
        public static List<Employee> Filter(
        List<Employee> employees,
        string selectedDept,
        decimal minSalary,
        decimal maxSalary,
        string searchText)
        {
            var query = employees.AsQueryable();

            if (!string.IsNullOrEmpty(selectedDept) && selectedDept != "Все отделы")
            {
                query = query.Where(e => e.Department == selectedDept);
            }

            query = query.Where(e => e.Salary >= minSalary && e.Salary <= maxSalary);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(e => e.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }

        public static List<Employee> Sort(List<Employee> employees, int sortType)
        {
            return sortType switch
            {
                1 => employees.OrderBy(e => e.FullName).ToList(),

                2 => employees.OrderByDescending(e => e.Salary).ToList(),

                3 => employees.OrderBy(e => e.Department)
                .ThenByDescending(e => e.Salary).ToList(),

                4 => employees.OrderBy(e => e.Position)
                .ThenBy(e => e.HireDate).ToList(),

                _ => employees
            };
        }
    }
}
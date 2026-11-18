
using System;
namespace EmployeesApp;
public record Employee(
    int Id,
    string FullName,
    string Department,
    string Position,
    decimal Salary,
    DateTime HireDate
    );
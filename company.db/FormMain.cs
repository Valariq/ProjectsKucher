using EmployeesApp;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace company.db
{
    public partial class FormMain : Form
    {
        private const string ConnectionString = "Data Source=company.db";

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDatabaseAndTable();

            LoadData();

            MessageBox.Show("База данных готова!");
        }

        private void CreateDatabaseAndTable()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string createTableQuery = @"
CREATE TABLE IF NOT EXISTS Employees (
Id INTEGER PRIMARY KEY AUTOINCREMENT,
FullName TEXT NOT NULL,
Department TEXT NOT NULL,
Position TEXT NOT NULL,
Salary REAL NOT NULL,
HireDate TEXT NOT NULL
);";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            var list = new List<Employee>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, FullName, Department, Position, Salary, HireDate FROM Employees";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDecimal(4),
                        DateTime.Parse(reader.GetString(5))
                        ));
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }
    }
}
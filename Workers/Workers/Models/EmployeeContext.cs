using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Workers.Models
{
    public class EmployeeContext
    {
        public string ConnectionString { get; set; }

        public EmployeeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from worker where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee()
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Job = reader["job"].ToString(),
                            Salary = float.Parse(reader["salary"].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                        });
                    }
                }
            }
            return list;
        }
    }
}

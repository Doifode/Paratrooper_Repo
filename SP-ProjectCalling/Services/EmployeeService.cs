using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_ProjectCalling.Data;
using SP_ProjectCalling.Interfaces;
using SP_ProjectCalling.Models.Domain;
using System.Data;
using Dapper;

namespace SP_ProjectCalling.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IConfiguration _configuration;

        private readonly ApplicationContextDb applicationContextDb;

        public EmployeeService(ApplicationContextDb applicationContextDb, IConfiguration configuration)
        {
            this.applicationContextDb = applicationContextDb;
            _configuration = configuration;
        }

        public List<Employee> GetAllEmployees()
        {
            // List<Employee> employees = applicationContextDb.Employees.FromSqlRaw("EXEC  Sp_AllEmployeeDetails").ToList();

            // string query = $"select * from Employees";

            //  List<Employee> employees = applicationContextDb.Database.ExecuteSql("EXEC Sp_AllEmployeeDetails") 


            //if (employees.Count > 0)
            //{
            //    return employees;
            //}
            //return employees;

            // using dapper

            var connection = new SqlConnection(_configuration.GetConnectionString("EmpConnectionString"));

            var emp = connection.Query<Employee>("select * from employees");
            
            return emp.ToList();

        }

        public List<Supervisor> GetAllSupervisors()
        {
            var supervisors = new List<Supervisor>();

            var query = "EXEC Sp_GetAllSupervisorDetails";

            using (var command = applicationContextDb.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                applicationContextDb.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var supervisor = new Supervisor
                        {
                            SupervisorId = reader.GetInt32(reader.GetOrdinal("SupervisorId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            TodaysTask = reader.IsDBNull(reader.GetOrdinal("TodaysTask")) ? null : reader.GetString(reader.GetOrdinal("TodaysTask")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };

                        supervisors.Add(supervisor);
                    }
                }
            }

            return supervisors;
        }
    }
}

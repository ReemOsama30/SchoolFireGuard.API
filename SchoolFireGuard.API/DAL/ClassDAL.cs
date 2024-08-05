using System;
using System.Collections.Generic;
using System.Data.OleDb;
using SchoolFireGuard.API.DTOS.classDTOs;

namespace SchoolFireGuard.API.DAL
{
    public class ClassDAL
    {
        private readonly string _connectionString;

        public ClassDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GetClassDTO> GetAllClasses()
        {
            var classes = new List<GetClassDTO>();

            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    string query = "SELECT className, NoOfStudents FROM classes WHERE IsSelected = No";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var classDto = new GetClassDTO
                                {
                                    className = reader.GetString(reader.GetOrdinal("className")),
                                    numberOfStudents = reader.IsDBNull(reader.GetOrdinal("NoOfStudents"))
                                        ? 0
                                        : reader.GetInt32(reader.GetOrdinal("NoOfStudents"))
                                };
                                classes.Add(classDto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework or system)
                throw new ApplicationException("An error occurred while getting all classes.", ex);
            }

            return classes;
        }

        public List<GetClassNameDTO> GetAllClassNames()
        {
            var classNames = new List<GetClassNameDTO>();

            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    string query = "SELECT Id, className FROM classes WHERE IsSelected = No";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var classDto = new GetClassNameDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    className = reader.GetString(reader.GetOrdinal("className"))
                                };
                                classNames.Add(classDto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework or system)
                throw new ApplicationException("An error occurred while getting all class names.", ex);
            }

            return classNames;
        }

        public int GetTotalClasses()
        {
            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) AS TotalClasses FROM Classes";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework or system)
                throw new ApplicationException("An error occurred while getting the total number of classes.", ex);
            }
        }

        public int GetTotalStudents()
        {
            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    string query = "SELECT SUM(NoOfStudents) AS TotalStudents FROM Classes";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework or system)
                throw new ApplicationException("An error occurred while getting the total number of students.", ex);
            }
        }
    }
}

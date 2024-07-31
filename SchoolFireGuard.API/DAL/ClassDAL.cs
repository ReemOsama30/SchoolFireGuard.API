using SchoolFireGuard.API.DTOS.classDTOs;
using System.Data.OleDb;

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

            using (var connection = new OleDbConnection(_connectionString))
            {
                string query = "SELECT className, NoOfStudents FROM Classes";

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

            return classes;
        }



        public List<GetClassNameDTO> GetAllClassNames()
        {
            var classNames = new List<GetClassNameDTO>();

            using (var connection = new OleDbConnection(_connectionString))
            {
                // Query to select Id and className from the Classes table
                string query = "SELECT Id, className FROM Classes";

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

            return classNames;
        }
        public int GetTotalClasses()
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

        public int GetTotalStudents()
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
    }
}

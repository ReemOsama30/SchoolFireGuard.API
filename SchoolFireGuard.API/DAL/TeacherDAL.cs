using SchoolFireGuard.API.DTOS.teacherDTOs;
using SchoolFireGuard.API.Models;
using System.Collections.Generic;
using System.Data.OleDb;
using System;

namespace SchoolFireGuard.API.DAL
{
    public class TeacherDAL
    {
        private readonly string _connectionString;

        public TeacherDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertTeacher(addTeacherDTO teacher)
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                string query = "INSERT INTO Teachers (TeacherName, ClassID, NoOfAbsentStudents, NoOfPresentStudents, isDone) VALUES (?, ?, ?, ?, ?)";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", teacher.Name);
                    command.Parameters.AddWithValue("?", teacher.classID);
                    command.Parameters.AddWithValue("?", teacher.pesentStudents);
                    command.Parameters.AddWithValue("?", teacher.absentStudents);
                    command.Parameters.AddWithValue("?", true);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<GetTeachersDTO> GetAllTeachers()
        {
            var teachers = new List<GetTeachersDTO>();

            using (var connection = new OleDbConnection(_connectionString))
            {
                string query = "SELECT TeacherName, ClassID, NoOfPresentStudents, NoOfAbsentStudents, isDone FROM Teachers";

                using (var command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var teacher = new GetTeachersDTO
                            {
                                Name = reader.GetString(reader.GetOrdinal("TeacherName")),
                                classID = reader.GetInt32(reader.GetOrdinal("ClassID")),
                                PesentStudents = reader.GetInt32(reader.GetOrdinal("NoOfPresentStudents")),
                                AbsentStudents = reader.GetInt32(reader.GetOrdinal("NoOfAbsentStudents")),
                                Done = reader.GetBoolean(reader.GetOrdinal("isDone"))
                            };
                            teachers.Add(teacher);
                        }
                    }
                }
            }

            return teachers;
        }


        public void RemoveAllTeachers()
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                string query = "DELETE FROM Teachers";

                using (var command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

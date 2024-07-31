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
                string query = "INSERT INTO Teachers (TeacherName, ClassID, NoOfPresentStudents,NoOfAbsentStudents, isDone) VALUES (?, ?, ?, ?, ?)";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", teacher.teacherName);
                    command.Parameters.AddWithValue("?", teacher.ClassID);
                    command.Parameters.AddWithValue("?", teacher.NoOfPresentStudents);
                    command.Parameters.AddWithValue("?", teacher.NoOfAbsentStudents);
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
                string query = @"
            SELECT t.TeacherName, t.ClassID, t.NoOfPresentStudents, t.NoOfAbsentStudents, t.isDone, c.className
            FROM Teachers t
            INNER JOIN Classes c ON t.ClassID = c.ID";

                using (var command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var teacher = new GetTeachersDTO
                            {
                                Name = reader.IsDBNull(reader.GetOrdinal("TeacherName")) ? null : reader.GetString(reader.GetOrdinal("TeacherName")),
                                classID = reader.IsDBNull(reader.GetOrdinal("ClassID")) ? default : reader.GetInt32(reader.GetOrdinal("ClassID")),
                                ClassName = reader.IsDBNull(reader.GetOrdinal("className")) ? null : reader.GetString(reader.GetOrdinal("className")),
                                AbsentStudents = reader.IsDBNull(reader.GetOrdinal("NoOfAbsentStudents")) ? default : reader.GetInt32(reader.GetOrdinal("NoOfAbsentStudents")),
                                PesentStudents = reader.IsDBNull(reader.GetOrdinal("NoOfPresentStudents")) ? default : reader.GetInt32(reader.GetOrdinal("NoOfPresentStudents")),
                                Done = reader.IsDBNull(reader.GetOrdinal("isDone")) ? default : reader.GetBoolean(reader.GetOrdinal("isDone"))
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

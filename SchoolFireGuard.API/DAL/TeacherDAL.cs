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
              
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert the teacher
                        string insertQuery = "INSERT INTO Teachers (TeacherName, ClassID, NoOfPresentStudents, NoOfAbsentStudents, isDone) VALUES (?, ?, ?, ?, ?)";
                        using (var insertCommand = new OleDbCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("?", teacher.teacherName);
                            insertCommand.Parameters.AddWithValue("?", teacher.ClassID);
                            insertCommand.Parameters.AddWithValue("?", teacher.NoOfPresentStudents);
                            insertCommand.Parameters.AddWithValue("?", teacher.NoOfAbsentStudents);
                            insertCommand.Parameters.AddWithValue("?", true);

                            insertCommand.ExecuteNonQuery();
                        }

                        // Update the isSelected field in the Classes table
                        string updateQuery = "UPDATE classes SET isSelected = ? WHERE Id = ?";
                        using (var updateCommand = new OleDbCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("?", true);
                            updateCommand.Parameters.AddWithValue("?", teacher.ClassID);

                            updateCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch
                    {
                        // Rollback the transaction if something goes wrong
                        transaction.Rollback();
                        throw;
                    }
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
                
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                       
                        string deleteQuery = "DELETE FROM Teachers";
                        using (var deleteCommand = new OleDbCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }

                  
                        string updateQuery = "UPDATE classes SET isSelected = ?";
                        using (var updateCommand = new OleDbCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("?", false);

                            updateCommand.ExecuteNonQuery();
                        }

                        
                        transaction.Commit();
                    }
                    catch
                    {
                       
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}

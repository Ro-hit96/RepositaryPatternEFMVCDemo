﻿using RepositaryPatternEFMVCDemo.Models;
using RepositaryPatternEFMVCDemo.Repositary;

namespace RepositaryPatternEFMVCDemo.Services
{
    public class StudentService : IstudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;   
        }
        public int AddStudent(Student student)
        {
           return repo.AddStudent(student);
        }

        public int DeleteStudent(int Roll_No)
        {
            return repo.DeleteStudent(Roll_No);
        }

        public Student GetStudentByRno(int Roll_No)
        {
             return repo.GetStudentByRno(Roll_No);
        }

        public IEnumerable<Student> GetStudents()
        {
           return repo.GetStudents();
        }

        public int UpdateStudent(Student student)
        {
            return repo.UpdateStudent(student);
        }
    }
}

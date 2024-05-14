﻿using LXP.Common.Entities;
using LXP.Data.DBContexts;
using LXP.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Data.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly LXPDbContext _lXPDbContext;
        public CourseRepository(LXPDbContext lXPDbContext) 
        {
            this._lXPDbContext = lXPDbContext;
        }
        public Course GetCourseDetailsByCourseId(Guid courseId)
        {
            return _lXPDbContext.Courses.Find(courseId);  
        }
        public Course GetCourseDetailsByCourseName(string courseName)
        {
            return _lXPDbContext.Courses.Include(course=>course.Level).Include(course=>course.Catagory).FirstOrDefault(course=>course.Title==courseName);
        }
        public void AddCourse(Course course)
        {
            _lXPDbContext.Courses.Add(course);
            _lXPDbContext.SaveChanges();
        }
        public bool AnyCourseByCourseTitle(string courseTitle)
        {
            return _lXPDbContext.Courses.Any(course=>course.Title== courseTitle);
        }
        
    }
}

using Microsoft.EntityFrameworkCore;
using Quizzes.Context;
using Quizzes.Models;

namespace Quizzes.DataAccessObject
{
    public class DAO
    {
        private readonly Cont cont;
        public DAO(Cont con)
        {
            cont = con;
        }
        public List<TeachersModel> GetTeachers()
        {
            var TeachersData = cont.teachers.FromSqlRaw("Select * from Teachers").ToList();
            return TeachersData;
        }
        public List<Studies> GetStudies()
        {
            var StudiesData = cont.studies.FromSqlRaw("Select * from Studies").ToList();
            return StudiesData;
        }
        public List<SubjectView> GetSubjectViews(string sv)
        {
            var Subjects = cont.subjectViews.FromSqlRaw(@"
                                                          SELECT        
                                                          Studies.sname, 
                                                          Studies.sdescrip, 
                                                          Subjects.subname, 
                                                          Subjects.subdesc
                                                          FROM            
                                                          Subjects 
                                                          INNER JOIN
                                                          Studies ON Subjects.subkey = Studies.id where sname = '"+sv+"'").ToList();
            return Subjects;
        }
    }
}

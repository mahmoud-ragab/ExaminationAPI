using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class InstructorRepository
    {
        public ExaminationContext context = new ExaminationContext();
        public Instructor getInstructorInformation(int id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var instructor = context.Database.SqlQuery<Instructor>("getInstructorByID @ins_ID", _Ins_id).SingleOrDefault();
            return instructor;
        }
    }
}

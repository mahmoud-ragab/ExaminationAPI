using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService
    {
        public DepartmentRepository departmentRepository = new DepartmentRepository();

        public List<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }
    }
}

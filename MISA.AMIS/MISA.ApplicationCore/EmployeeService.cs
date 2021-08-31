
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class EmployeeService : IEmployeeService
    {

        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    var employeeContext = new EmployeeContext();
        //    var employees = employeeContext.GetEmployees();
        //    return employees;
        //}

        //public Employee GetEmployeeById(Guid employeeId)
        //{


        //    var employeeContext = new EmployeeContext();
        //    var employee = employeeContext.GetEmployeeById(employeeId);
        //    return employee;
        //}
        public ServiceResult Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}

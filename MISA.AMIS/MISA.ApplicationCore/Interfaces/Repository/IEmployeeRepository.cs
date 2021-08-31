using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repository
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
       
        /// <summary>
        /// Trả về new id
        /// </summary>
        /// <returns></returns>
         public string GetNewEmployeeCode();

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các thiêu trí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên</param>
        /// <param name="departmentId">Id phòng ban</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreateBy: DTTrinh
        public List<Employee> GetEmployeesFilter(string specs, Guid? departmentId);

     
    }
}

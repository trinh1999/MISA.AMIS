using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService: IBaseService<Employee>
    {
 
        #region METHOD
        /// <summary>
        /// Tạo mã mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        ///CreateBy: DTTrinh
        string GetNewEmployeeCode();

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các thiêu trí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên</param>
        /// <param name="departmentId">Id phòng ban</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreateBy: DTTrinh
        List<Employee> GetEmployeesFilter(string specs, Guid? departmentId);

        #endregion


    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructor.Repository
{

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        #region Contructor

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public List<Employee> GetEmployeesFilter(string specs, Guid? departmentId)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();
            var parameters = new DynamicParameters();
            var input = specs != null ? specs : string.Empty;
            parameters.Add("@EmployeeCode", input, DbType.String);
            parameters.Add("@FullName", input, DbType.String);
            parameters.Add("@PhoneNumber", input, DbType.String);
            parameters.Add("@DepartmentId", departmentId, DbType.String);
            var employees = _dbConnection.Query<Employee>("Proc_GetEmployeesFilterPaging", param: parameters, commandType: CommandType.StoredProcedure);
            return employees.ToList();
            ////Thay đổi query nếu có lọc theo từ khóa
            //if (filter != "" && filter != null)
            //{
            //    orCommandString = " AND (EmployeeCode LIKE @filter OR FullName LIKE @filter OR PhoneNumber LIKE @filter)";
            //    dynamicParams.Add("@filter", $"%{filter}%");
            //}

            //// Thay đổi query nếu có lọc theo phòng ban
            //if (departmentId.ToString() != "" && departmentId != Guid.Empty)
            //{
            //    andCommandString += " AND Depart



            /// <summary>
            /// Thêm customer vào database
            /// </summary>
            /// <param name="customes"></param>
            /// <returns></returns>

        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm sinh mã mới cho nhân viên
        /// </summary>
        /// <returns>Chuỗi mã code mới</returns>
        /// CreateBy: DTTrinh
        public string GetNewEmployeeCode()
        {
            _dbConnection = new MySqlConnection(_connectionString);
            //Thực hiện lấy query lấy mã nhân viên mới từ csdl
            string sqlCommand = "SELECT EmployeeCode FROM Employee ORDER BY EmployeeCode DESC LIMIT 1";
            var employeeCode = _dbConnection.QueryFirstOrDefault<string>(sqlCommand);//sai định dạng
            //var employeeCode = _dbConnection.QueryFirstOrDefault<string>("Proc_GetNewEmployeeCode", commandType: CommandType.StoredProcedure);//sai định dạng
            return employeeCode;
        }

        #endregion
    }
}

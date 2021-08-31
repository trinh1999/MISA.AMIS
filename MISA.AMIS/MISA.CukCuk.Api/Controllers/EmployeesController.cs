using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region DECLARE
        ServiceResult _serviceResult;
        IEmployeeService _employeeService;

        #endregion


        #region Contructor
        public EmployeesController(IBaseService<Employee> baseService, IBaseRepository<Employee> baseRepository, IEmployeeService employeeService) : base(baseService, baseRepository)
        {
            _employeeService = employeeService;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm thêm mới nhân viên 
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>IActionResult</returns>
        /// CreateBy: DTTrinh
        public override IActionResult Insert(Employee entity)
        {
            try
            {
                var result = _employeeService.Add(entity);
                if (result.ErrorCode == MISACode.IsValid)
                {
                    result.Status = RequestStatus.Complete;
                    return StatusCode(201, result.Data);
                }
                else if (result.ErrorCode == MISACode.NoValid)
                {
                    result.Status = RequestStatus.Fail;
                    return BadRequest(result);
                }
                else
                {
                    result.Status = RequestStatus.Fail;
                    return StatusCode(500, result);
                }

            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }
        }


        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreateBy: DTTrinh
        public override IActionResult Update(Employee entity, Guid entityId)
        {
            try
            {
                var result = _employeeService.Update(entity, entityId);
                if (result.ErrorCode == MISACode.IsValid)
                {
                    result.Status = RequestStatus.Complete;
                    return StatusCode(200, result.Data);
                }
                else if (result.ErrorCode == MISACode.NoValid)
                {
                    result.Status = RequestStatus.Fail;
                    return BadRequest(result);
                }
                else
                {
                    result.Status = RequestStatus.Fail;
                    return StatusCode(500, result);
                }
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }

        }



        /// <summary>
        /// Sinh mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var emoloyeeCode = _employeeService.GetNewEmployeeCode();
                _serviceResult.Data = emoloyeeCode;
                _serviceResult.Status = RequestStatus.Complete;
                return StatusCode(200, _serviceResult.Data);
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }
        }

        /// <summary>
        /// Lọc theo thông tin nhập vào ô input tìm kiếm ( mã code,tên),phòng ban
        /// </summary>
        /// <param name="specs">Nội dung ô input</param>
        /// <param name="departmentId">mã phòng ban</param>
        /// <returns>StatusCode</returns>
        [HttpGet("filter")]
        public IActionResult GetEmployeeFilter([FromQuery] string specs, [FromQuery] Guid? departmentId)
        {
            try
            {
                var employees = _employeeService.GetEmployeesFilter(specs, departmentId);
                if (employees.Count() == 0)
                {
                    _serviceResult.Messager = Properties.ResourcesVN.DataEmpty;
                    _serviceResult.Status = RequestStatus.Fail;
                    return StatusCode(204, _serviceResult);
                }
                return StatusCode(200, employees);
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }
        }

 
        #endregion
    }

}

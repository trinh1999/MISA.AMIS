using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<TEntity> _baseService;
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        /// <summary>
        /// Ham khoi tao
        /// </summary>
        /// <param name="baseService">base service</param>
        /// <param name="baseRepository">base repository</param>
        /// CreateBy: DTTrinh
        #region Contructor
        public BaseEntityController(IBaseService<TEntity> baseService, IBaseRepository<TEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        /// <summary>
        /// Hiển thị danh sách 
        /// </summary>
        /// <returns>StatusCode</returns>
        /// CreateBy: DTTrinh
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _baseRepository.Get();
                return StatusCode(200, entities);
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,
                    errorCode = "misa-001",
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;

                return StatusCode(500, _serviceResult);
            }
        }

        /// <summary>
        /// API hiển thị đối tượng theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>StatusCode</returns>
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {

            try
            {
                var entity = _baseService.GetById(entityId);

                if (entity == null)
                {
                    _serviceResult.Data = entity;
                    _serviceResult.Messager = Properties.ResourcesVN.DataEmpty;
                    _serviceResult.Status = RequestStatus.Fail;
                    return StatusCode(204, _serviceResult);

                };
                _serviceResult.Data = entity;
                _serviceResult.Status = RequestStatus.Complete;
                var response = StatusCode(200, _serviceResult.Data);
                return response;
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
        /// API thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>StatusCode</returns>
        /// CreateBy: DTTrinh
        [HttpPost]
        public virtual IActionResult Insert(TEntity entity)
        {
            //try
            //{
            //    var result = _baseService.Add(entity);
            //    if (result.ErrorCode == MISACode.IsValid)
            //    {
            //        result.Status = RequestStatus.Complete;
            //        return StatusCode(201, result.Data);
            //    }
            //    else if (result.ErrorCode == MISACode.NoValid)
            //    {
            //        result.Status = RequestStatus.Fail;
            //        return BadRequest(result);
            //    }
            //    else
            //    {
            //        result.Status = RequestStatus.Fail;
            //        return StatusCode(500, result);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    var msgError = new
            //    {
            //        devMsgVN = ex.Message,
            //        userMsgVN = Properties.ResourcesVN.ErrorUserMsgExeption,

            //        errorCode = "misa-001",
            //        tradeId = "",
            //    };
            //    _serviceResult.Messager = ex.Message;
            //    _serviceResult.Data = msgError;
            //    _serviceResult.Status = RequestStatus.Exception;
            return StatusCode(1, _serviceResult);
            //}
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="entityId">id</param>
        /// <returns></returns>
        /// CreateBy: DTTrinh
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var entityById = _baseService.GetById(entityId);
                if (entityById == null)
                {
                    var errorMsg = new
                    {
                        userMgs = Properties.ResourcesVN.MsgIsValid,
                        data = "entityId",
                        errorCode = "misa-005",
                    };
                    _serviceResult.ErrorCode = MISACode.NoValid;
                    _serviceResult.Data = errorMsg;
                    return BadRequest(_serviceResult);
                }
                var result = _baseService.Delete(entityId);
                if (result.ErrorCode == MISACode.IsValid)
                {
                    result.Status = RequestStatus.Complete;
                    return StatusCode(200, result.Data);
                }
                else
                {
                    result.Status = RequestStatus.Fail;
                    return StatusCode(204, result);
                }
                //4. Trả về cho client

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
        /// Sửa 
        /// </summary>
        /// CreateBy: DTTrinh
        [HttpPut("{entityId}")]
        public virtual IActionResult Update(TEntity entity, Guid entityId)
        {
            try
            {
                var result = _baseService.Update(entity, entityId);
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
                    errorCode = "misa-001",
                    tradeId = "",
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

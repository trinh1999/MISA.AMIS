using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntityController<Department>
    {

        #region DECLARE
    

        #endregion

        #region Contructor
        public DepartmentsController(IBaseService<Department> baseService, IBaseRepository<Department> baseRepository, IDepartmentService departmentService) : base(baseService, baseRepository)
        {
        }
        #endregion

        #region Method


        #endregion

    }

}

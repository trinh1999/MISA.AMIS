using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{

    /// <summary>
    /// Để xác định trạng thái của việc validate
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Không thỏa mãn
        /// </summary>
        NoValid = 900,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
    }
      public enum RequestStatus
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Complete = 1,

        /// <summary>
        /// Thất bại
        /// </summary>
        Fail = 2,

        /// <summary>
        /// Exception
        /// </summary>
        Exception = 3
    }
    /// <summary>
    /// Xác định trạng thái của object
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Thêm mơi
        /// </summary>
        AddNew = 1,

        /// <summary>
        /// Cập nhật
        /// </summary>
        Update = 2,

        /// <summary>
        /// Xóa thành công
        /// </summary>
        Delete = 3
    }
}

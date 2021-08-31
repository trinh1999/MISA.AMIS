using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity
{

    /// <summary>
    /// Để xác  định trạng thái của việc validate
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

        /// <summary>
        /// Lỗi server
        /// </summary>
        BadRequest = 500
    }

}

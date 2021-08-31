using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        #region Property
        /// <summary>
        //Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông báo trả về
        /// </summary>
        public Object Messager { get; set; }

        /// <summary>
        /// Mã code trả về
        /// </summary>
        public MISACode ErrorCode { get; set; }

        /// <summary>
        /// Trả về trạng thái: 1.Thành công 2. Thất bại 3. Exception
        /// </summary>
        public RequestStatus Status { get; set; }

        #endregion
    }
}

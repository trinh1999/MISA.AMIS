using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class BaseEntity
    {
        #region Property
        [MISANotMap]
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreateBy: DTrinh
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        /// CreateBy: DTrinh
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        /// CreateBy: DTrinh
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Chỉnh sửa bởi
        /// </summary>
        /// CreateBy: DTrinh
        public string ModifiedBy { get; set; }

        #endregion
    }
}

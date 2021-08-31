using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Models
{
    public class Customer : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và đệm
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }



        /// <summary>
        /// Số tiền ghi nợ
        /// </summary>
        public double? DebitAmount { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// Created By 
        /// </summary>
        public string MemberCardCode { get; set; }


        /// <summary>
        /// Tên công ty của khách hàng
        /// Created By
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã tax công ty của khách hàng
        /// Created By : TTUyen
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Đã dừng chưa
        /// </summary>
        public int? IsStopFollow { get; set; }

        #endregion

    }
}

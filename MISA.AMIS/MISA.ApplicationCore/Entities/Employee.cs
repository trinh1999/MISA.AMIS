using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        [Duplicated]
        [Required]
        [MaxLength(20, "Mã nhân viên không được quá 20 ký tự")]
        [DisplayName("Mã nhân viên ")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required]
        [DisplayName("Tên nhân viên ")]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [DisplayName("Giới tính")]
        public int? Gender { get; set; }

        public string GenderName
        {
            get
            {
                if (Gender == 0)
                {
                    return "Nữ";
                }
                else if (Gender == 1)
                {
                    return "Nam";
                }
                return "Khác";
            }
        }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// 
        [FormatEmail]
        [Required]
        [DisplayName("Email nhân viên ")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// 
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// 
        public string TelePhoneNumber { get; set; }

        /// <summary>
        /// TK ngân hàng
        /// </summary>
        /// 
        public string BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// 
        public string BankBranch { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        /// 
        public string PositionName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số chứng minh thư/căn cước công dân
        /// </summary>
        /// 
        
        [DisplayName("Số chứng minh thư / Căn cước công dân của nhân viên ")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp cmt
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp 
        /// </summary>
        public string IdentityPlace { get; set; }


        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }
        public string DepartmentName { get; set; }


        #endregion

    }
}

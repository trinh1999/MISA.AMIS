<template>
  <div class="form-em-detail" id="dlgCustomerDetail" hidden>
    <div class="model"></div>
    <div
      class="dialog-content"
      style="top: 50%; transform: translate(-50%, -50%)"
    >
      <div class="employee-detail-title">THÔNG TIN KHÁCH HÀNG</div>
      <div class="em-del-content">
        <div class="em-avatar">
          <div class="icon-avatar"></div>
          <div class="notify-em">
            (Vui lòng chọn ảnh có định dạng<br />
            .jpg, .jpeg, .png, .gif)
          </div>
        </div>
        <div class="em-resume">
          <div class="em-resume-common">
            <div class="title-re-com">
              A.THÔNG TIN CHUNG
              <hr />
            </div>
            <div class="input-item">
              <div class="row">
                <div class="col mar-right-16px tooltip">
                  <label for="" class="lab-id-em"
                    >Mã khách hàng (<span style="color: red">*</span>)</label
                  >
                  <br />
                  <input
                    type="text"
                    prop-name="EmployeeCode"
                    required
                    id="txtCustomerCode"
                  />
                  <span class="tooltiptext">Nhập mã khách hàng</span>
                </div>
                <div class="col tooltip">
                  <label for="" class="lab-name-em"
                    >Họ và tên (<span style="color: red">*</span>)</label
                  >
                  <br />
                  <input
                    type="text"
                    prop-name="FullName"
                    required
                    id="txtFullName"
                  />
                  <span class="tooltiptext">Nhập họ và tên</span>
                </div>
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                <div class="col mar-right-16px">
                  <label for="" class="lab-dob-em">Ngày sinh</label>
                  <br />
                  <input
                    type="date"
                    prop-name="DateOfBirth"
                    id="txtDateOfBirth"
                  />
                </div>
                <div class="col">
                  <label for="">Giới tính </label>
                  <br />
                  <BaseDropdown
                    nameDropdown="filter-gender"
                    dropdownType="dropdown-gender drdialog"
                    type="gender"
                    dropdownValue="txtGender"
                    propName="GenderName"
                  />
                </div>
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                <div class="col mar-right-16px tooltip">
                  <label for="" class="lab-cmt-em"
                    >Số CMTNFD/ Căn cước (<span style="color: red">*</span
                    >)</label
                  >
                  <br />
                  <input
                    type="text"
                    required
                    class="input-cmt-em"
                    id="txtIdentityNumber"
                  />
                  <span class="tooltiptext">Nhập số CMTND/Căn cước</span>
                </div>
                <div class="col">
                  <label for="" class="lab-date-cmt">Ngày cấp </label>
                  <br />
                  <input
                    type="date"
                    prop-name="IdentityDate"
                    class="input-date-cmt"
                    id="txtIdentityDate"
                  />
                </div>
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                <div class="col mar-right-16px">
                  <label for="" class="lab-locate-cmt">Nơi cấp </label>
                  <br />
                  <input
                    type="text"
                    prop-name="IdentityPlace"
                    class="input-locate-cmt"
                    id="txtIdentityPlace"
                  />
                </div>
                <div class="col"></div>
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                <div class="col mar-right-16px">
                  <label for="" class="lab-email"
                    >Email (<span style="color: red">*</span>)</label
                  >
                  <br />
                  <input
                    type="email"
                    prop-name="Email"
                    id="txtEmail"
                    placeholder="example@domain"
                    required
                    class="input-email"
                  />
                </div>
                <div class="col tooltip">
                  <label for="" class="lab-phone"
                    >Số điện thoại (<span style="color: red">*</span>)</label
                  >
                  <br />
                  <input
                    type="text"
                    prop-name="PhoneNumber"
                    id="txtPhoneNumber"
                    required
                    class="input-phone"
                  />
                  <span class="tooltiptext">Nhập số điện thoại</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="btn-option">
        <div class="button bth-save" id="btnSave">
          <i class="far fa-save"></i> Lưu
        </div>
        <div class="button bth-cancle" id="btnCancelAddForm">Hủy</div>
      </div>
      <button class="btn-exit" id="btnExitForm">
  
      </button>
    </div>
  </div>
</template>
<style>
@import "../../css/layout/employee-detail.css";
</style>
<script>
import BaseDropdown from "../../components/base/Dropdown.vue";
export default {
  name: "CustomerDetail",
  components: {
    BaseDropdown,
  },
};
</script>
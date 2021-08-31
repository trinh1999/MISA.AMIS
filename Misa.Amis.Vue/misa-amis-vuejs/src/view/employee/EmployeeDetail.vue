<template>
  <div
    class="dialog"
    id="dlgEmployeeDetail"
    :class="{ 'dialog-hidden': isHide }"
  >
    <div class="model"></div>
    <div class="dialog-container">
      <div class="dialog-title">
        <div class="dialog-text">Thông tin nhân viên</div>
        <BaseCheckBox/>
      </div>
      <div class="dialog-content">
        <div class="em-resume">
          <div class="em-resume-common">
            <div class="input-item">
              <div class="row">
                <BaseInput
                  :isHide="isHideBtnReset"
                  @showToolTip="showToolTip"
                  @btnResetInput="btnResetInput"
                  tabindex="1"
                  typeName="text"
                  propName="EmployeeCode"
                  idInput="txtEmployeeCode"
                  :required="true"
                  v-model="employee.EmployeeCode"
                  ref="txtrequiredEmployeeCode"
                  validate="false"
                  nameLabel="Mã"
                  isLabel="true"
                  autoFocus="true"
                  :reFocus="reFocus"
                  colClass="mar-right-16px tooltip"
                  :isHideToolTip="isHideToolTip"
                  style="width: 180px"
                
                />

                <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  colClass="mar-right-16px tooltip"
                  nameLabel="Tên"
                  isLabel="true"
                  tabindex="2"
                  typeName="text"
                  propName="FullName"
                  :required="true"
                  idInput="txtFullName"
                  v-model="employee.FullName"
                  ref="txtrequiredFullName"
                  validate="false"
                  placeholder="Nguyễn Văn A"
                />

                <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  colClass="mar-right-16px"
                  nameLabel="Ngày sinh"
                  tabindex="3"
                  typeName="date"
                  propName="DataOfBirth"
                  idInput="txtDateOfBirth"
                  v-model="employee.DateOfBirth"
                  subClass="width-110px"
                  style="margin-right: 0px;width: 198px; margin-left: 20px"
                />
                <div class="Gender">
                  <label>Giới tính</label>
                  <BaseRadio
                   tabindex="4"/>
                </div>

              </div>
            </div>
            <div class="input-item">
              <div class="row">
                <Dropdown
                  colClass="col"
                  nameLabel="Đơn vị"
                  tabindex="5"
                  id="department"
                  nameDropdown="filter-dlgdepartment"
                  dropdownType="dropdown-department drdialog"
                  itemId="DepartmentId"
                  itemName="DepartmentName"
                  :selectedId="employee.DepartmentId"

                  v-model="employee.DepartmentId"
                  myUrl="api/Department"
                  dropdownValue="txtDepartmentName"
                  isLabel="true"
                  style="padding-bottom:0px;"
                 
                />
                 <BaseInput
                  @btnResetInput="btnResetInput"
                  tabindex="5"
                  typeName="text"
                  propName="IdentityNumber"
                  idInput="txtIdentityNumber"
                  :required="true"
                  validate="false"
                  v-model="employee.IdentityNumber"
                  ref="txtrequiredIdentityNumber"
                  nameLabel="Số CMTND"
                  isLabel="true"
                  colClass="mar-right-16px tooltip"
                  placeholder="10 số"
                  style="margin-left: 218px"
                />
                <BaseInput
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  nameLabel="Ngày cấp"
                  tabindex="7"
                  typeName="date"
                  propName="IdentityDate"
                  idInput="txtIdentityDate"
                  v-model="employee.IdentityDate"
                  subClass="width-110px"
                  style="margin-right: 0px;width: 110px; margin-left: 5px"
                />
                <!-- <Dropdown
                  colClass="col"
                  nameLabel="Giới tính"
                  id="Gender"
                  tabindex="4"
                  nameDropdown="filter-gender"
                  dropdownType="dropdown-gender drdialog"
                  dropdownValue="txtGender"
                  itemId="Gender"
                  itemName="GenderName"
                  :selectedId="employee.Gender + ''"
                  v-model="employee.Gender"
                /> -->
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                 <BaseInput
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  colClass="mar-right-26px tooltip"
                  nameLabel="Chức danh"
                  tabindex="8"
                  typeName="text"
                  propName="PositionName"
                  idInput="txtPositionName"
                  v-model="employee.PositionName"
                  style="width: 442px"
                />

                <BaseInput
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  colClass="mar-right-16px tooltip"
                  nameLabel="Nơi cấp"
                  tabindex="9"
                  typeName="text"
                  propName="IdentityPlace"
                  idInput="txtIdentityPlace"
                  v-model="employee.IdentityPlace"
                  style="magin-left: 12px"
                />
                <div class="col"></div>
              </div>
            </div>
          </div>
        <br>  
          <div class="em-resume-common">
            <div class="input-item">
              <div class="row">
               <BaseInput
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  colClass="mar-right-26px tooltip"
                  nameLabel="Địa chỉ"
                  tabindex="10"
                  typeName="text"
                  propName="Address"
                  idInput="txtAddress"
                  v-model="employee.Address"
                  style="width: 100%"
                />
              </div>
            </div>
            <div class="input-item">
              <div class="row">
              <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="11"
                  typeName="text"
                  propName="MobilePhoneNumber"
                  idInput="txtMobilePhoneNumber"
                  v-model="employee.MobilePhoneNumber"
                  validate="false"
                  nameLabel="ĐT di động"
                  colClass="tooltip"
                  style="width: 240px"
                />
                <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="12"
                  typeName="text"
                  propName="TelePhoneNumber"
                  idInput="txtTelePhoneNumber"
                  v-model="employee.TelePhoneNumber"
                  validate="false"
                  nameLabel="ĐT cố định"
                  colClass="tooltip"
                  style="width: 240px"
                />
                 <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="13"
                  typeName="email"
                  propName="Email"
                  idInput="txtEmail"
                  placeholder="example@domain"
                  v-model="employee.Email"
                  validate="false"
                  nameLabel="Email"
                  colClass="mar-right-16px tooltip"
                   style="width: 240px"
                />
              </div>
            </div>
            <div class="input-item">
              <div class="row">
                 <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="14"
                  typeName="text"
                  propName="BankAccount"
                  idInput="txtBankAccount"
                  v-model="employee.BankAccount"
                  validate="false"
                  nameLabel="Tài khoản ngân hàng"
                  colClass="tooltip"
                  style="width: 240px"
                />
                <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="15"
                  typeName="text"
                  propName="BankName"
                  idInput="txtBankName"
                  v-model="employee.BankName"
                  validate="false"
                  nameLabel="Tên ngân hàng"
                  colClass="tooltip"
                  style="width: 240px"
                />
                 <BaseInput
                  @showToolTip="showToolTip"
                  :isHideToolTip="isHideToolTip"
                  :isHide="isHideBtnReset"
                  @btnResetInput="btnResetInput"
                  tabindex="16"
                  typeName="txt"
                  propName="BankBranch"
                  idInput="txtBankBranch"
                  v-model="employee.BankBranch"
                  validate="false"
                  nameLabel="Chi nhánh"
                  colClass="mar-right-16px tooltip"
                   style="width: 240px"
                />
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="btn-option">
        <BaseButton
          tabindex="17"
          subClass="button bth-save"
          id="btnSave"
          buttonText="Cất và Thêm"
          @btnn-click="btnSaveOnClick"
        />
        <BaseButton
          tabindex="18"
          subClass="button bth-cat"
          id="btnSave"
          buttonText="Cất"
          @btnn-click="btnSaveOnClick"
        />
        <BaseButton
          tabindex="19"
          subClass="button bth-cancle"
          id="btnCancelAddForm"
          buttonText="Hủy"
          @btnn-click="btnShowPopup"
        />
      </div>
      <BaseButton
        subClass="btn-exit"
        id="btnExitForm"
        @btnn-click="btnShowPopup"
      />

       <!-- <BaseCombobox/> -->
    </div>
   
  </div>
</template>

<script>
// import BasePopup from "../../components/base/BasePopup.vue";
import Dropdown from "../../components/base/Dropdown.vue";
import BaseInput from "../../components/base/BaseInput.vue";
// import BaseCombobox from "../../components/base/BaseCombobox.vue";
// import BaseInputSalary from "../../components/base/BaseInputSalary.vue";
import BaseButton from "../../components/base/Button.vue";
import BaseRadio from "../../components/base/BaseRadio.vue";
import BaseCheckBox from "../../components/base/BaseCheckBox.vue";
import common from "../../js/common/common.js";
// import message from "../../js/common/message.js";

import axios from "axios";
// import $ from "jquery";
import { eventBus } from "../../main";
export default {
  name: "EmployeeDetail",
  components: {
    Dropdown,
    BaseInput,
    BaseButton,
    // BaseCombobox,
    BaseRadio,
    BaseCheckBox,
 
  },

  data() {
    return {
      employee: {},
      isValidated: true,
      isHideBtnReset: true,
      reFocus: false,
      isHideToolTip: true,
    };
  },
  props: {
    isHide: {
      type: Boolean,
      default: true,
      require: true,
    },
    formMode: String,
    employeeId: { type: String, require: true },
    employeeCode: String,
  },
  created() {
    /**
     * Hàm lắng nghe save trong popup
     */
    eventBus.$on("btnSaveOnClickPopup", () => {
      this.btnSaveOnClickPopup();
    });
    /**
     * Hàm lắng nghe hủy lưu trong popup
     */
    eventBus.$on("btnCancelOnClickPopup", () => {
      this.btnCancelOnClickPopup();
    });
  },

  watch: {
    /**
     * Hàm lắng nghe employeeId thay đổi để cập nhật lại dữ liệu hiển thị lên form
     */
    employeeId: function (value) {
      let vm = this;
      //Gọi API binding dữ liệu
      axios
        .get(`https://localhost:44345/api/v1/Employees/${value}`)
        .then((res) => {
          // console.log(res);
          console.log(res.data);
          vm.employee = res.data;
          vm.employee.DateOfBirth = common.formatDateYMD(
            vm.employee.DateOfBirth
          );
          vm.employee.JoinDate = common.formatDateYMD(vm.employee.JoinDate);
          vm.employee.IdentityDate = common.formatDateYMD(
            vm.employee.IdentityDate
          );
          console.log(vm.employee.JoinDate);
          console.log(vm.employee.IdentityDate);
          // vm.employee.Salary = Number(vm.employee.Salary).toLocaleString("vi");
          // console.log(vm.employee);
        })
        .catch((res) => {
          console.log(res);
        });
    },

    isHide: function () {
      this.reFocus = !this.reFocus;
    },

    /**
     * Hàm lắng nghe form thay đổi
     */
    formMode: function (value) {
      let vm = this;
      console.log("value " + value);
      if (vm.formMode == "add") {       
        vm.getNewCode();
      }
    },
  },

  methods: {
    /**
     * Hàm lấy mã nhân viên 
     * Author:
     */
    getNewCode(){
       axios
        .get("https://localhost:44345/api/v1/Employees/NewEmployeeCode")
        .then((res) => {
          let newEmployee = {};
          newEmployee.EmployeeCode = res.data;
          this.employee = newEmployee;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    
    /**
     * Hiển thị tool tip cảnh báo
     */
    showToolTip() {
      this.isHideToolTip = false;
    },
    /**
     * Hàm hiển thị popup
     */
    btnShowPopup() {
      let me = this;
      for (let [key] of Object.entries(me.$refs)) {
        if (key.includes("txt")) me.$refs[key].validateInput();
      }
      eventBus.$emit("showPopupForCancel", "cancel");
    },
    /**
     * Hàm emit đến EmployeeList
     * CreateBy DT.Trinh
     */
    btnCancelOnClickPopup() {
      this.$emit("btnCancelOnClick");
      common.turnOffValidate();
    },

    /**
     * Hàm kiểm tra validate khi click save
     * CreateBy: DT.Trinh
     */
    btnSaveOnClick() {
      // var me = this;
      //thực hiện validate dữ liệu xem dữ liệu gửi lên servise có đúng hay không
      // var inputs = me.$refs;
      // console.log(inputs);
      // var array = Object.keys(inputs);
      // console.log("111");
      // console.log(array);
      // array.map((value) => {
      //   me.isValidate(value);
      // });
      // // check những input có thuộc tính validate=false (nhập chưa đúng định dạng) thì sẽ focus vào 
      // var arrayValidate = $('input[validate="false"]');
      // if (arrayValidate && arrayValidate.length > 0) {
      //   console.log("ararray " + arrayValidate[0]);
      //   arrayValidate[0].focus();
      //   me.isValidated = false;
      //   this.$emit("showMsgMisRequied");
      //} else {
        if (this.formMode == "add") {
          eventBus.$emit("showPopupForSave", "add");
        } else {
          eventBus.$emit("showPopupForSave", "edit");
        }
      //}
    },
    /**
     * Hàm lưu nhân viên khi xác nhận l Lưu trong popup
     */
    btnSaveOnClickPopup() {
      // this.employee.Salary = common.reFormatMoney(this.employee.Salary);
      // console.log("salary" + this.employee.Salary);
      if (this.formMode == "add") {
        axios
          .post("https://localhost:44345/api/v1/Employees", this.employee)
          .then((res) => {
            console.log(res);
            console.log("add" + this.employee);
            eventBus.$emit("hidePopup");
            this.$emit("btnCancelOnClick");
            this.$emit("showMsgAddSuccess");
            this.$emit("loadData");
          })
          .catch((res) => {
            console.log(this.employee);
            console.log(res);
          });
      } else {
        axios
          .put(
            "https://localhost:44345/api/v1/Employees/" + this.employee.EmployeeId,
            this.employee
          )
          .then((res) => {
            console.log(res);
            eventBus.$emit("hidePopup");
            this.$emit("btnCancelOnClick");
            this.$emit("showMsgEditSuccess");
            this.$emit("loadData");
          })
          .catch((res) => {
            console.log(res);
          });
      }
    },

    /**
     * validate dữ liệu
     * @param {*} value key được đặt trên các thẻ input (ref)
     * createdBy: DT.Trinh
     */
    isValidate() {
      let me = this;
      for (let [key] of Object.entries(me.$refs)) {
        if (key.includes("required")) {
          me.$refs[key].isValidate(); // meme.$refs.requiredFullName.isValidate()
        }
      }
    },
    /**
     * Hàm xóa value trong input
     */
    btnResetInput() {},
  },
};
</script>

<style>
@import "../../css/layout/dialog.css";
@import "../../css/base/tool-tip.css";
@import "../../css/base/input.css";
@import "../../css/base/button.css";
@import "../../css/base/radio.css";

#txtEmployeeCode{
  width: 120px;
}

#txtPositionName{
  width: 359px;
}

#txtIdentityPlace{
   width: 369px;
}

#txtAddress{
  width: 810px;
}


</style>
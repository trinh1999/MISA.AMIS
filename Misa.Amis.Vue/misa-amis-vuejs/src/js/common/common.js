import message from './message'
import $ from 'jquery'
import dayjs from "dayjs";

const common = {
  /**
   * Sẽ được gọi đến khi ấn hủy hoặc thoát form dialog, làm cho tool-tip không hiện nữa
   *  CreatedBy: DT.Trinh 4/8/2021
   */
  turnOffValidate() {
    console.log($('.input-item input[type=text]'));
    var arrayInputText = $('.input-item input[type=text]');
    for (let i = 0; i < arrayInputText.length; i++) {
      arrayInputText[i].style.border = "";
      arrayInputText[i].nextElementSibling.style.display = "none";
    }
    var arrayInputEmail = $('.input-item input[type=email]');
    for (let i = 0; i < arrayInputEmail.length; i++) {
      arrayInputEmail[i].style.border = "";
      arrayInputEmail[i].nextElementSibling.style.display = "none";
    }
  },

  /**
   * Sẽ được gọi đến khi check validate dữ liệu nếu dữ liệu không đúng
   * @param {*} input các elements input
   * @param {*} value key được đặt trên các thẻ input (ref)
   * @param {*} message thông báo lỗi cho người dùng biết
   * CreatedBy: DT.Trinh 2/8/2021
   */
  turnOnValidate(input, value, message) {
    input.style.border = "1px solid #F65454";
    input.nextElementSibling.style.display = "block";
    input.nextElementSibling.innerText = message;
    $(input).attr('validate', false);
    input.setAttribute('validate', false);
  },


  /**
   * validate dữ liệu
   * @param {*} input các element input có chứa ref
   * @param {*} value dữ liệu của ref được gán trên thẻ input
   * @returns true - đã check validate và dữ liệu đúng hết, false - dữ liệu đang sai
   * createdBy: DT.Trinh 2/8/2021
   */
  isValidateInput(input, value) {
    // check bắt buộc nhập
   
    if (value == '') {
      console.log("vào hàm validate value trôgns");
      common.turnOnValidate(input, value, message.VALIDATE_MSG_NO_SUCCESS);
      return false;
    }
    // if (propName == "Email") {

    //   if (!common.isEmail(value)) {
    //     common.turnOnValidate(input, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
    //     return false;
    //   }
    // }
    // if (propName == "IdentityNumber") {
    //   if (!common.isIdentityNumber(value)) {
    //     common.turnOnValidate(input, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
    //     return false;
    //   }
    // }
    // input.setAttribute('validate', true);
    // var div;
    // $(input[value]).css("border", "");
    // div = $(input[value]).next()[0];
    // $(div).css("display", 'none')
    // $(input).attr('validate', true)
  },
  isFormatInput(input, value){
    console.log("vào hàm format input");
    var propName = input.getAttribute('prop-name');
    if (propName == "Email") {

      if (!common.isEmail(value)) {
        console.log("vào hàm input email");
        common.turnOnValidate(input, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
        return false;
      }
    }
    if (propName == "IdentityNumber") {
      console.log("vào hàm số phone input");
      if (!common.isIdentityNumber(value)) {
        common.turnOnValidate(input, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
        return false;
      }
    }
  },

  /**
     * Định dạng cho email
     * CreateBy DT.Trinh
     */
  isEmail(email) {
    //eslint-disable-next-line
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
      return false;
    } else {
      return true;
    }
  },
  /**
   * Định dạnh cho số chứng minh thư nhân dân
   * CreateBy DT.Trinh
   */
  isIdentityNumber(cmt) {
    //eslint-disable-next-line
    var regex = /^([0-9]{9}|[0-9]{12})+$/;
    if (!regex.test(cmt)) {
      return false;
    } else {
      return true;
    }
  },
  /**
   * Hàm format date thàng dạng yyyy-mm-dd
   *  CreateBy DT.Trinh
   */
  formatDateYMD(date) {
    if (date == null) {
      return new Date(date);
    }
    return dayjs(date).format("YYYY-MM-DD");
  },
  /**
   * Hàm chuyển số dạng 1.000.000 về dạng 1000000 để lưu dữ liệu
   *  CreateBy DT.Trinh
   */
  reFormatMoney(str) {
    str += "";
    if (str != null) {
      str.replaceAll(".", "");
      let onlynumber = "";
      for (let i = 0; i < str.length; i++) {
        if (!isNaN(parseInt(str[i], 10))) {
          onlynumber += str[i];
        }
      }
      return onlynumber;
    }
    return 0;
  },
  

}

export default common;
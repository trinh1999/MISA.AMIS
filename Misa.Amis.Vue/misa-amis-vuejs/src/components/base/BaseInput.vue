<template>
  <div>
    <div :class="['col', colClass]">
      <label :isLabel="isLabel">
        {{ nameLabel }}
        <span v-if="isLabel == 'true'"
          >(<span style="color: red">*</span>)
        </span>
      </label>
      <br />
      <input
        :type="[typeName]"
        :placeholder="[placeholder]"
        :prop-name="[propName]"
        :id="idInput"
        :class="[subClass, { valid: hasValid }, { unValid: hasUnValid }]"
        :required="required"
        :value="value"
        :tabindex="tabindex"
        @blur="onBlur($event.target.value)"
        @input="updateValue($event.target.value)"
        :validate="validate"
        ref="refInput"
        :autofocus="autoFocus"
        :isHide="isHideToolTip"
      />
      <div
        v-if="isToolTip == 'true'"
        :class="['tooltiptext', { 'tool-tip-hidden': isHideToolTip }]"
      ></div>
      <button
        :class="{ 'btn-reset btn-hidden': isHide }"
        @click="btnResetInput"
        v-if="typeName == 'text'"
      >
        <i class="fas fa-times"></i>
      </button>
    </div>
  </div>
</template>
<script>
import common from "../../js/common/common.js";
// import $ from "jquery";

export default {
  name: "BaseInput",
  props: {
    isHide: {
      type: Boolean,
      default: true,
    },
    typeName: String,
    placeholder: String,
    propName: String,
    idInput: String,
    subClass: String,
    colClass: String,
    nameLabel: String,
    isLabel: String,
    reFocus: Boolean,
    isHideToolTip: {
      type: Boolean,
      default: true,
    },
    tabindex: {
      type: String,
      Number,
      required: false,
    },
    value: {
      default: null,
    },
    required: {
      type: Boolean,
    },
    validate: String,
    autoFocus: String,
  },

  data() {
    return {
      hasValid: false,
      hasUnValid: false,
      isToolTip: "true",
    };
  },

  watch: {
    /**Hàm focus vào mã nhân viên */
    reFocus: function () {
      if (this.autoFocus == "true") {
        this.$refs.refInput.focus();
      }
    },
  },

  methods: {
    updateValue: function (value) {
      let me = this;
      me.$emit("input", value);
      // Nếu các ô bắt buộc nhập đã có dữ liệu thì bỏ viền đỏ và ẩn tooltip
      if (value != "" && me.required) {
        console.log("abc");
        me.hasUnValid = false;
        me.hasValid = true;
      }
    },
    /**
     * Hàm emit cho reset input cho cha
     */
    btnResetInput() {
      this.$emit("btnResetInput");
    },

    /**
     * Hàm hiển thị blur
     */
    onBlur(value) {
      let me = this;
      if (value == "" && me.required) {
        console.log(value);
        me.hasUnValid = true; // border đỏ
        me.hasValid = false; // border thường
        common.isValidateInput();
        // this.iisValidatesValidate();// cho vào hàm validate dữ liệu để hiển thị tooltip
      }
      if (value != "") {
        this.isFormat();
      }
    },

    /**
     * validate dữ liệu
     * @param {*} value key được đặt trên các thẻ input (ref)
     * createdBy: DT.Trinh
     */

    isFormat() {
      let me = this;
      let value = me.$refs.refInput.value;
      let input = me.$refs.refInput;
      let check = true;
      check = common.isFormatInput(input, value);
      if (check) me.isValidated = true;
      else me.isValidated = false;
    },
    
    isValidate() {
      console.log("isvalidate");
      let me = this;
      let value = me.$refs.refInput.value, //lấy giá trị của inputu
        input = me.$refs.refInput, // lấy el input
        check = true;
      if (me.required) {
        // nếu nó là trường bắt buộc
        check = common.isValidateInput(input, value);
      }
      if (check) me.isValidated = true;
      else me.isValidated = false;
    },

    /**
     * Hàm loại bỏ lỗi và tooltip cảnh báo khi mở lại form
     *
     */
    validateInput() {
      let me = this;
      me.hasUnValid = false;
      me.hasValid = true;
    },
  },
};
</script>
<style scoped>
@import "../../css/base/icon.css";
@import "../../css/base/input.css";
@import "../../css/base/button.css";
@import "../../css/common/common.css";
.tool-tip-hidden {
  display: none;
}
</style>
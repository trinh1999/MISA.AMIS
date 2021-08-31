<template>
  <div class="popup-annouce" :class="{ 'popup-hidden': isPopup }">
    <div class="model"></div>
    <div class="popup warning">
      <div class="header">
        <div class="title">
          <span class="title-text">{{ titleText }}</span>
        </div>
        <div class="btn-close" @click="btnHidePopup"></div>
      </div>
      <div class="popup-content">
        <div class="warning-icon icon-danger" v-if="type == 'delete'"></div>
        <div
          class="warning-icon icon-warning"
          v-if="type == 'edit' || type == 'add' || type == 'cancel'"
        ></div>
        <div class="warning-message">
          <span class="text-before">{{ textMessDetail }}</span>
          <!-- <span class="text-target">bản ghi</span>
            <span class="text-after"> đã chọn không</span> -->
        </div>
      </div>
      <div class="footer">
        <button
          v-if="type == 'delete'"
          class="button confirm btn-accept-delete"
          @click="btnDeleteOnClick"
          tabindex="16"
        >
          Xóa
        </button>
        <button
          v-if="type == 'edit' || type == 'add'"
          class="button confirm"
          @click="btnSaveOnClickPopup"
          tabindex="16"
        >
          Lưu
        </button>
        <button
          v-if="type == 'cancel'"
          class="button confirm"
          @click="btnCancelOnClickPopup"
          tabindex="16"
        >
          Đóng
        </button>
        <button
          class="button cancel"
          v-if="type == 'edit' || type == 'add' || type == 'delete'"
          @click="btnHidePopup"
          tabindex="17"
        >
          Hủy
        </button>
        <button
          class="button cancel"
          v-if="type == 'cancel'"
          @click="btnHidePopup"
          tabindex="17"
        >
          Tiếp tục nhập
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { eventBus } from "../../main.js";
export default {
  name: "BasePopup",
  props: {
    isPopup: {
      type: Boolean,
      default: true,
    },
    warnings: [],
    titleText: String,
    textMessDetail: String,
    type: String,
  },
  methods: {
    /**
     * Hàm gửi emit cho app đóng popup
     * CreateBy DT.Trinh (9/8/2021)
     */
    btnHidePopup() {
      this.$emit("btnHidePopup");
    },
    /**
     * Hàm emit gửi lệnh thực thi hàm xóa bản ghi
     * CreateBy DT.Trinh (9/8/2021)
     */
    btnDeleteOnClick() {
      eventBus.$emit("btnDeleteOnClick");
      this.$emit("btnHidePopup");
    },

    /**
     * Hàm emit gửi lệnh thực thi save bản ghi
     * CreateBy DT.Trinh (9/8/2021)
     */
    btnSaveOnClickPopup() {
      eventBus.$emit("btnSaveOnClickPopup");
    },
    /**
     * Hàm emit gửi lệnh thực thi hàm hủy không thực hiện nữa
     * CreateBy DT.Trinh (9/8/2021)
     */
    btnCancelOnClickPopup() {
      eventBus.$emit("btnCancelOnClickPopup");
      this.$emit("btnHidePopup");
    },
  },
};
</script>
<style scoped>
@import "../../css/base/popup.css";
.popup-hidden {
  display: none;
}
</style>

<template>
  <div id="message" :class="{ isHide: isHide }">
    <div class="message" v-for="(item, index) in errors" :key="index">
      <div class="message-icon">
        <i
          class="icon-success fas fa-check-circle"
          v-if="item.statusMsg == 'Success'"
        ></i>
        <i
          class="icon-warning fas fa-exclamation-circle"
          v-if="item.statusMsg == 'Warning'"
        ></i>
        <i
          class="icon-danger fas fa-exclamation-triangle"
          v-if="item.statusMsg == 'Danger'"
        ></i>
      </div>
      <div class="message-title">
        {{ item.titleMsg }}
      </div>
      <div class="message-icon-close" @click="btnClose">
        <i
          class="icon-success fas fa-times"
          v-if="item.statusMsg == 'Success'"
        ></i>
        <i
          class="icon-warning fas fa-times"
          v-if="item.statusMsg == 'Warning'"
        ></i>
        <i
          class="icon-danger fas fa-times"
          v-if="item.statusMsg == 'Danger'"
        ></i>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseMessage",
  props: ["isHide", "errors"],
  methods: {
    /**
     * Hàm đóng message
     * CreatedBy:
     */
    btnClose() {
      this.$emit("closeMsg", true);
    },
  },
};
</script>
<style scoped>
@import "../../css/base/message.css";
.isHide {
  display: none;
}
</style>
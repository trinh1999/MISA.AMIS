<template>
  <div class="paging">
    <div class="paging-bar">
      <div class="paging-record-info">
        Hiển thị <b>{{ EmployeePerPage }}/{{ totalEmployee }}</b> nhân viên
      </div>
      <div class="paging-option">
        <div
          class="btn-select-page m-btn-firstpage"
          @click="pageOnClick('firstpage')"
        ></div>
        <div
          class="btn-select-page m-btn-prev-page"
          @click="pageOnClick('prev-page')"
        ></div>
        <div class="m-btn-list-page">
          <button
            v-for="index in totalButton"
            :key="index"
            :class="[
              'btn-pagenumber',
              { active: index == CurrentIndex },
              { isNone: index < leftLimit || index > rightLimit },
            ]"
            @click="pageOnClick(index)"
          >
            {{ index }}
          </button>
        </div>
        <div
          class="btn-select-page m-btn-next-page"
          @click="pageOnClick('next-page')"
        ></div>
        <div
          class="btn-select-page m-btn-lastpage"
          @click="pageOnClick('lastpage')"
        ></div>
      </div>
      <div class="paging-record-option">
        <b>{{ EmployeePerPage }}&nbsp;</b>nhân viên/trang
        <div class="icon-chevron">
          <i
            class="fas fa-chevron-up"
            @click="modifyEmployee('fa-chevron-up')"
          ></i>
          <i
            class="fas fa-chevron-down"
            @click="modifyEmployee('fa-chevron-down')"
          ></i>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BasePaging",
  data() {
    return {
      EmployeePerPage: 10,
      CurrentIndex: 1,
      leftLimit: 1,
      rightLimit: 5,
      totalShow: 5,
    };
  },

  props: {
    totalEmployee: Number,
    totalButton: Number,
  },

  methods: {
    created() {
      this.updatePageNumber();
    },
    /**
     * Hàm bấm các lựa chọn ở trang
     */
    pageOnClick(statusPage) {
      let me = this;
      switch (statusPage) {
        case "firstpage":
          me.CurrentIndex = 1;
          break;
        case "prev-page":
          if (me.CurrentIndex > 1) me.CurrentIndex--;
          break;
        case "next-page":
          if (me.CurrentIndex < me.totalButton) me.CurrentIndex++;
          break;
        case "lastpage":
          me.CurrentIndex = me.totalButton;
          break;
        default:
          me.CurrentIndex = statusPage;
          break;
      }
      me.$emit("UpdatePage", me.CurrentIndex, me.EmployeePerPage);
      me.updatePageNumber();
    },

    /**
     * Hàm cập nhật trang đang được xem
     * DT.Trinh 12/8/2021
     */
    updatePageNumber() {
      let me = this;
      me.leftLimit = me.rightLimit = me.CurrentIndex; //=4
      for (var b = 1; b < me.totalShow && b < me.totalButton; ) {
        if (me.leftLimit > 1) {
          me.leftLimit--; //3,2
          b++; //2,4
        }
        if (b < me.totalShow && me.rightLimit < me.totalButton) {
          me.rightLimit++; //5,6
          b++; //3,5
        }
      }
    },

    modifyEmployee(modifyStatus) {
      let me = this;
      switch (modifyStatus) {
        case "fa-chevron-up":
          me.EmployeePerPage += 10;
          break;
        case "fa-chevron-down":
          if (me.EmployeePerPage > 10) me.EmployeePerPage -= 10;
          break;
      }
      me.$emit("UpdatePage", me.CurrentIndex, me.EmployeePerPage);
    },
  },
};
</script>

<style scoped>
@import "../../css/base/paging.css";
</style>
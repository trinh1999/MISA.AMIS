<template>
  <div :class="[nameClassInput]">
    <input
      :type="[typeName]"
      :placeholder="[detailSearch]"
      onfocus="this.placeholder = ''"
      :class="[subClass]"
      :name="[nameInput]"
      :id="[idInput]"
      :tabindex="tabindex"
    />
    <button :class="{'btn-reset btn-hidden' : isHide}"  @click="btnResetInput">
      <i :class="[iconClass]"></i>
    </button>
  </div>
</template>

<script>
export default {
  name: "BaseInputIcon",
  props: {
    nameClassInput: String,
    typeName: String,
    detailSearch: String,
    subClass: String,
    nameInput: String,
    idInput: String,
    iconClass: String,
    tabindex: Number,
    isHide:{
      type: Boolean,
      default: true,
    }
  },
  methods:{
    btnResetInput(){
      this.$emit('btnResetInput');
    }
  }
};
</script>
<style scoped>
@import "../../css/base/icon.css";
@import "../../css/base/input.css";
@import "../../css/base/button.css";

</style>
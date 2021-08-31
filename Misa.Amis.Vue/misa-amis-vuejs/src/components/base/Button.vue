<template>
  <button
    :class="[subClass]"
    :id="id"
    @click="$emit('btnn-click')"
    :tabindex="tabindex"
  >
    <i :class="[awesome]"></i>
    {{ buttonText }}
  </button>
</template>

<script>
export default {
  name: "Button",
  data() {
    return {
      id: "",
    };
  },
  props: {
    subClass: String,
    buttonText: String,
    awesome: String,
    tabindex: String,
  },
};
</script>
<style scoped>
@import "../../css/base/button.css";
</style>

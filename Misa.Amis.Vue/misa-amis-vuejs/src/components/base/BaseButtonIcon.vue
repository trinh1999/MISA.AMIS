<template>
  <div
    :class="['button', subClass]"
    :id="id"
    @click="$emit('btn-click')"
    :tabindex="tabindex"
  >
    <div :class="[buttonIcon]"></div>
    <div class="button-value">{{ buttonText }}</div>
  </div>
</template>

<script>
export default {
  name: "BaseButtonIcon",
  data() {
    return {
      id: "",
    };
  },
  props: {
    subClass: String,
    buttonIcon: String,
    buttonText: String,
    tabindex: String,
  },
};
</script>
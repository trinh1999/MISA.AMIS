<template>
 <div class="loader" v-if="HideLoader ==false">
   <div class="model" v-if="HideLoader ==false"></div>
    <div :class="['lds-roller', {'HideLoader': HideLoader}]">
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
  </div>
 </div>
</template>

<script>
export default {
  name: "BaseLoader",

  props: {
    HideLoader: Boolean,
  },

  methods: {},

  watch: {},
};
</script>

<style scoped>
.HideLoader{
  display: none;
}
</style>
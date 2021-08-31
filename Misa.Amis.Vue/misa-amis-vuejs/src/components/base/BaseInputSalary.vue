<template>
  <div>
    <div :class="['col', colClass]">
      <label>
        {{ nameLabel }}
      </label>
      <br />
      <input
        :type="[typeName]"
        :prop-name="[propName]"
        :id="idInput"
        :class="subClass"
        :value="value"
        v-on:input="updateValue($event.target.value)"
        :tabindex="tabindex"
      />
      <div class="vnd"><i>(VND)</i></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "BaseInputSalary",
  props: {
    typeName: String,
    placeholder: String,
    propName: String,
    idInput: String,
    subClass: String,
    colClass: String,
    nameLabel: String,
    tabindex: {
      type: String,
      Number,
      required: false,
    },
    value: {
      default: null,
    },
  },
  methods: {
    updateValue: function (value) {
      this.$emit("input", value);
    },
  },
};
</script>
<style scoped>
@import "../../css/base/input.css";
</style>
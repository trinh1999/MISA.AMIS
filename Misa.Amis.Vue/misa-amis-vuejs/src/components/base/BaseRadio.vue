<template>
<div>
    <div class="radio-item">
      <input type="radio" id="ritem0" name="ritem" value="0">
      <label for="ritem0">Nam</label>
    </div>

    <div class="radio-item">
      <input type="radio" id="ritem1" name="ritem" value="1">
      <label for="ritem1">Nữ</label>
    </div>

    <div class="radio-item">
      <input type="radio" id="ritem2" name="ritem" value="1">
      <label for="ritem2">Khác</label>
    </div>
</div>
</template>

<style>
@import "../../css/base/radio.css";
</style>

<script>
import "../../main.js";
  export default {
    data() {
      return {
        selected: 'first',
        options: [
          { text: 'First radio', value: '0' },
          { text: 'Second radio', value: '1' },
          { text: 'Third radio', value: '2' }
        ]
      }
    }
  }
</script>
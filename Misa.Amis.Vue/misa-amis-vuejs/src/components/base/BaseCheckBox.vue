<template>
<div>
    <div class="checkbox-item">
      <input type="checkbox" id="checkbox0" name="checkbox0" value="0">
      <label for="checkbox0">Là khách hàng</label>
    </div>

    <div class="checkbox-item">
      <input type="checkbox" id="checkbox1" name="checkbox1" value="1">
      <label for="checkbox1">Là nhà cung cấp</label>
    </div>

</div>
</template>

<style>
@import "../../css/base/checkbox.css";
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
        ]
      }
    }
  }
</script>
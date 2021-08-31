<template>
  <div class="content-commond">
    <EmployeeList />
  </div>
</template>
<script>
import EmployeeList from "../../view/employee/EmployeeList.vue";
export default {
  name: "Content",
  components: {
    EmployeeList,
  },
};
</script>
<style>
@import "../../css/layout/content.css";
</style>
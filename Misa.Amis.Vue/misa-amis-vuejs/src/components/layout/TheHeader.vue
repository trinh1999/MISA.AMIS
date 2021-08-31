<template>
  <div class="header">
    <div class="header-left">
      <div class="toggle"></div>
      <div class="logo"></div>
    </div>
    <div class="header-right">
      <div class="header-title">
        
        <Dropdown
          id="store"
          nameDropdown="filter-store"
          dropdownType="store"
          itemId="StoreId"
          itemName="StoreName"
          dropdownValue="txtStore"
          :selectedId="0+ ''"
          isLabel='false'
          isLogo='isLogo'
          colClass="dowpDownStore"
        />
      </div>

      <div class="header-info">
        <div class="announce">
          <i class="far fa-bell"></i>
        </div>
        <div class="avatar"></div>
        <div class="info-name">
          <Dropdown
          id="use"
          nameDropdown="filter-use"
          dropdownType="use"
          itemId="UseNameId"
          itemName="UseName"
          dropdownValue="txtUse"
          :selectedId="0+ ''"
          isLabel='false'
          colClass="dowpDownUse"
        />
        </div>
        <div class="option"></div>
      </div>
    </div>
  </div>
</template>
<script>
import Dropdown from "../base/Dropdown.vue";
export default {
  name: "TheHeader",
  components: {
    Dropdown,
  },
};
</script>
<style scoped>
@import "../../css/layout/header.css";
</style>
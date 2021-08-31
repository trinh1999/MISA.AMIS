<template>
  <div :class="[colClass]" :isLabel="isLabel" :isLogo="isLogo">
    <div class="avt-logo" v-if="isLogo=='isLogo'"></div>
    <label v-if="isLabel == 'true'" for="">{{ nameLabel }}
       <span v-if="isLabel == 'true'"
          >(<span style="color: red">*</span>)
        </span>
    </label>
    <div :class="[nameDropdown]" v-on-clickaway="away">
      <div
        :id="id"
        :class="['dropdown', dropdownType]"
        :myurl="myUrl"
        :itemid="itemId"
        :required="required"
        :itemname="itemName"
      >
        <div
          class="dropdown-header-wrapper"
          @click="toggleItems"
          :value="currentId"
          :tabindex="tabindex"
        >
          <span class="dropdown-value" :id="dropdownValue">
            {{ currentName }}
          </span>
          <i
            :class="['fas fa-chevron-down icon-down', opened ? 'move-up' : '']"
          ></i>
        </div>
        <ul :class="['dropdown-list', opened ? 'isshow' : 'isnone']">
          <li
            :class="[
              'dropdown-item',
              item[itemId] == currentId ? 'active' : '',
            ]"
            v-for="item in itemlist"
            :key="item[itemId]"
            @click="clickItem(item[itemId], item[itemName])"
          >
            {{ item[itemName] }}
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { directive as onClickaway } from "vue-clickaway";
export default {
  directives: {
    onClickaway: onClickaway,
  },
  name: "Dropdown",
  data() {
    return {
      itemlist: [],
      currentId: "-1",
      currentName: "",
      opened: false,
      defaultId: "-1",
    };
  },
  props: {
    id: String,
    isLabel: {
      type: String,
      default: "true",
    },
    nameLabel: String,
    nameDropdown: String,
    dropdownType: String,
    propName: String,
    colClass: String,
    dropdownValue: String,
    myUrl: String,
    itemId: String,
    itemName: String,
    defaultName: String,
    selectedId: String,
    tabindex: String,
    isLogo: String,
  },
   tabindex: {
      type: String,
      Number,
      required: false,
    },
    value: {
      default: null,
    },
    required: {
      type: Boolean,
    },
    validate: String,
    autoFocus: String,
  created() {
    this.loadDropdownData();
    this.currentName = this.defaultName;
    this.initChoice();
  },
  watch: {
    selectedId: function () {
      this.initChoice();
    },
  },
  methods: {
    away: function () {
      this.opened = false;
    },
    loadDropdownData() {
      switch (this.itemName) {
        case "UseName":
          this.itemlist = [
            {
              UseNameId: 0,
              UseName: "Đàm Thị Trinh",
            },
            {
              UseNameId: 1,
              UseName: "Lã Thị Liễu",
            },
            {
              UseNameId: 2,
              UseName: "Misa misa",
            },
          ];
          break;
        case "Action":
          this.itemlist = [
            {
              ActionId: 0,
              ActionName: "Sửa",
            },
            {
              ActionId: 1,
              ActionName: "Nhân bản",
            },
            {
              ActionId: 2,
              ActionName: "Xóa",
            },
          ];
          break;
        case "StoreName":
          this.itemlist = [
            {
              StoreId: 0,
              StoreName: "CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUY PHÚC",
            },
            {
              StoreId: 1,
              StoreName: "CÔNG TY TNHH XUẤT KHẨU - THƯƠNG MẠI - DỊCH VỤ AN NHÀN",
            },
            {
              StoreId: 2,
              StoreName: "CÔNG TY TNHH MAY MẶC - DỊCH VỤ LAN HƯƠNG",
            },
            {
              StoreId: 3,
              StoreName: "CÔNG TY TNHH BẢO VỆ - AN TOÀN - DỊCH VỤ TUẤN HƯNG",
            },
          ];
          break;
        default:
          if (this.myUrl) {
            axios
              .get(`http://cukcuk.manhnv.net/${this.myUrl}`)
              .then((res) => {
                this.itemlist = res.data;
              })
              .catch((error) => {
                console.log(error);
              });
          }
          break;
      }
    },
    initChoice() {
      let vm = this;
      if ((vm.selectedId + "").length > 0) {
        vm.itemlist.forEach((item) => {
          if (vm.selectedId == item[vm.itemId]) {
            vm.currentName = item[vm.itemName];
            vm.currentId = item[vm.itemId];
          }
        });
      } else {
        vm.currentId = "-1";
        vm.currentName = "";
      }
    },
    clickItem(itemValue, itemName) {
      this.currentId = itemValue;
      this.currentName = itemName;
      this.opened = false;
      this.$emit("input", itemValue);
    },
    toggleItems() {
      this.opened = !this.opened;
    },
  },
};
</script>
<style scoped>
@import "../../css/base/dropdown.css";
@import "../../css/base/icon.css";

.dropdown-list.isshow {
  display: block;
}

.dropdown-list.isnone {
  display: none;
}
#store .dropdown-header-wrapper{
  width: 450px;
  font-size: 13px;
  border: none;
}
#use .dropdown-header-wrapper{
  width: 128px;
  font-size: 11px;
  border: none;
  margin-left: -27px;
}
#use .dropdown-list.isshow {
    width: 120px;
    left: -25px;
}



</style>


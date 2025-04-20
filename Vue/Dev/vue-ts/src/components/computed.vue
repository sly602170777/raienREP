<template>
  <div>
    <div>
    <h1>商品价格：<input v-model="price" /> </h1></div>
    <div><h1>商品数量：<input v-model="count" /> </h1></div>
   <h1>商品总价：{{ total }} </h1>
  </div>
</template>


<script setup lang="ts">
  import { ref,computed,watch } from "vue";

const price = ref<number>(0);
const count = ref<number>(0);
const total = computed(() => {
  return price.value * count.value;
});

//监听数据的变化
watch([price,count,total],(newValue,oldValue) => {
  //debugger
  console.log("newValue",newValue);
  console.log("oldValue",oldValue);
  console.log("price",price.value);
  console.log("count",count.value);
  console.log("total",total.value);
})


</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>

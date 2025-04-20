<template>
  <div>
    <div>
      <h1>商品价格：<input v-model="price" /></h1>
    </div>
    <div>
      <h1>商品数量：<input v-model="count" /></h1>
    </div>
    <h1>商品总价：{{ total }}</h1>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted,onUpdated,onBeforeUnmount,onErrorCaptured, watch } from "vue";
//组件挂载
onMounted(() => {
  console.log("组件挂载完成");
  // debugger
  // console.log("组件挂载完成", price.value, count.value, total.value);
});
//组件更新
onUpdated(() => {
  console.log("组件更新完成");
  // debugger
  // console.log("组件更新完成", price.value, count.value, total.value);
});
//组件销毁
onBeforeUnmount(() => {
  console.log("组件销毁");
  // debugger
  // console.log("组件销毁", price.value, count.value, total.value);
});

//组件错误处理
onErrorCaptured((err, vm, info) => {
  console.log("组件错误处理", err, vm, info);
  return false; // 返回 false 以阻止错误继续传播
});
//组件事件处理

const price = ref<number>(0);
const count = ref<number>(0);
const total = computed(() => {
  return price.value * count.value;
});

//监听数据的变化
watch([price, count, total], (newValue, oldValue) => {
  //debugger
  console.log("newValue", newValue);
  console.log("oldValue", oldValue);
  console.log("price", price.value);
  console.log("count", count.value);
  console.log("total", total.value);
});
</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>

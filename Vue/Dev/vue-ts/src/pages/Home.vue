<template>
  <div>
    <h1>Home page</h1>
    <button @click="count++">自加：{{ count }}</button>
    <button @click="count--">自减：{{ count }}</button>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useCounterStore } from "../stores/counter";

const counterStore = useCounterStore();
//const count = counterStore.count; // 直接使用 store 中的 count 属性



const count = ref(0);
count.value = counterStore.count; // 使用 ref 包装 store 中的 count 属性
    </script>
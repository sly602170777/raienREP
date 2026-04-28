<template>
    <div>
      <h1>About page</h1>
      <button @click="count++">count++</button>
      <button @click="count--">count--</button>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from "vue";
  
  
  
  const count = ref(0);
  
      </script>
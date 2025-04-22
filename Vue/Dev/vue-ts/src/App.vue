<script setup lang="ts">
import { ref } from "vue";
import  HelloWorld from './components/HelloWorld.vue'
import HelloWorld2 from './components/HelloWorld2.vue'
import Computed from './components/computed.vue'
import Lifecycle from './components/lifecycle.vue'
import ParentCom from './components/ParentCom.vue'
import DynamicCom from './components/DynamicCom.vue'

/**
const count = ref(10);
const isOpen = ref<boolean>(false);
const count2 = ref<number>(10);
const isOpen2 = ref<boolean>(false);
 */
const isOpenForLife = ref<boolean>(false);
const ParentMsg = ref<string>("Home的数据");
const ParentPrice = ref<number>(10);
const ParentCount = ref<number>(5);
</script>

<template>
  <div>
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + Vue" />
  <!-- v-model 双向绑定 -->
  <h1 style="color: palegreen">双向绑定 </h1>
  <HelloWorld2 msgs="Vite + Vue2"/>
  <!-- 计算属性 -->
  <h1 style="color: palegoldenrod">计算属性 </h1>
  <Computed/>
  <!-- 生命周期 -->
  <h1 style="color: red">生命周期</h1>
  <button @click="isOpenForLife = !isOpenForLife">
      {{ isOpenForLife ? "卸载按钮Close" : "卸载按钮Open" }}
    </button>
  <Lifecycle v-if="isOpenForLife" />

  <h1 style="color: red">APP父组件 </h1>
  <button @click="ParentPrice++">APP父组件按钮</button>
  <ParentCom :msg="ParentMsg" :price="ParentPrice" :count="ParentCount" />
  <h1 style="color: red">动态组件 </h1>
  <DynamicCom/>
  <h1 style="color: red">路由导入 </h1>
  <!-- 挂载路由 -->
  <RouterView/>
</div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>

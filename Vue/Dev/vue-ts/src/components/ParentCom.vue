
<script setup lang="ts">
/* 
父组件  
      1. 通过 props 向子组件传递数据
      2. 通过 $emit 向父组件传递数据
      3. 通过 $refs 访问子组件的方法
      4. 通过 $parent 访问父组件的方法
      5. 通过 $children 访问子组件的方法
      6. 通过 $slots 访问子组件的插槽
*/
import { ref } from 'vue';
import  SonCom from './SonCom.vue';

/**
 * ref 的作用:

      ref 是 Vue 3 中用于定义响应式数据的函数。
      它会返回一个包含响应式值的对象，称为 "ref 对象"。
      通过 .value 属性访问或修改其值。
   count:

      定义了一个响应式变量 count，初始值为 10。
      类型为 number。
      该变量可以在模板中绑定到子组件或父组件的元素上，并在值发生变化时触发视图更新。
   price:

      定义了一个响应式变量 price，初始值为 10。
      类型为 number。
      用于存储子组件的价格信息，并通过 props 传递给子组件。
  msg:

      定义了一个响应式变量 msg，初始值为 '父组件传递过来的数据'。
      类型为 string。
      用于存储父组件传递给子组件的消息内容。
      当父组件更新 msg 的值时，子组件会自动响应并更新显示的内容。
      用途
      这些变量通过 props 传递给子组件 SonCom，子组件可以通过 v-model 或 props 直接使用这些数据。
      父组件可以通过事件（如按钮点击）更新这些变量的值，从而触发子组件的视图更新。
 */

const count = ref<number>(10)
const price = ref<number>(10)
const msg = ref<string>('父组件传递过来的数据')

// 定义事件处理函数
//子组件的通信 是将子组件的事件和属性提升到父组件来完成
// 通过 $emit 向父组件传递数据
// 子组件的事件处理函数
const handleUpdate = (v: number | undefined) => {
  count.value += v ?? 0; // 如果 v 是 undefined，则使用默认值 0
};
// 定义更新 msg 的函数
//子组件的响应： 因为子组件通过 props 接收 msg，当父组件更新 msg 时，
//子组件会自动响应并更新显示的内容。
const updateMsg = () => {
  msg.value = '更新后的子组件 msg 内容';
};
</script>

<template>
  <div>
      <h1>父组件</h1>
      <h2>父组件的props</h2>
      <h3>子组件传递过来的数据：<input v-model="msg"/></h3>
      <div>子组件价格：<input v-model="price"/></div>
      <div>子组件数量：<input v-model="count"/></div>
  <!-- 新增按钮 -->
  <button @click="updateMsg">更新子组件的 msg 内容</button>
      <SonCom :msg="msg" :price="price" :count="count" v-on:update="handleUpdate"></SonCom>
  </div>
  </template>

  
<style scoped>  </style>
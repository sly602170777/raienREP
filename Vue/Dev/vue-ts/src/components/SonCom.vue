


<script setup lang="ts">
import { defineProps ,defineEmits} from 'vue'

// 通过 props 向子组件传递数据
// 通过 $emit 向父组件传递数据
// 通过 $refs 访问子组件的方法
const props = defineProps({
    msg: String,
    price: {
        type: Number,
        efault: 0, // 默认值
    },
    count: {
        type: Number,
    }

})
// 通过 props 向子组件传递数据
const emit =  defineEmits<{
    (e: 'update', v: number): void
}>()

// 通过 $emit 向父组件传递数据
// 通过 $refs 访问子组件的方法
// 通过 $parent 访问父组件的方法
// 通过 $children 访问子组件的方法

</script>

<template>
    <div>
        <h1>子组件****</h1>
        <h3>父组件传递过来的数据：<input  v-model="props.msg"/></h3>
    <div>子组件价格：<input  v-model="props.price"/></div>
    <div>子组件数量：<input  v-model="props.count"/></div>
    <div >
    </div>
    <button @click="props.price !== undefined && emit('update', 100)">子组件价格：更新价格</button> 
    </div>
</template>

<style scoped>  </style>
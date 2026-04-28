


<script setup lang="ts">
import { defineProps ,defineEmits} from 'vue'
import { ref } from 'vue';
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'

//const inputDate = ref<Date | null>(null);
/* const month = ref({
  month: new Date().getMonth(),
  year: new Date().getFullYear()
}); */

// 定义响应式数据
const selectedDate = ref<string | null>(null); // 存储选中的日期


// 是否显示 month-picker
const isMonthPicker = ref(true);
// 是否显示日期选择器
const isDatePicker = ref(false);

// 处理日期选择
const handleDateSelect = (selectedDateValue: string | null) => {
  if (isMonthPicker.value) {
    
    // 如果当前是 month-picker 模式，切换到日期选择模式
    isDatePicker.value = true;
    isMonthPicker.value = false;
  } else {
    // 如果已经是日期选择模式，更新选中的日期
    selectedDate.value = selectedDateValue;
    isMonthPicker.value = true;
    isDatePicker.value = false;
  }
};


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
    <div class="date-picker">
        <h3>子组件日期</h3>
         <!-- 属性を指定するだけ 
          locale这可以通过指定来实现对于日语，"ja"请指定
          自动关闭日历 auto-apply这可以通过添加来实现。
         取消标记今天的日期 no-today这可以通过添加来实现。

         <VueDatePicker 
            v-model="inputDate"
            format="yyyy/MM/dd"
            model-type="yyyy-MM-dd"
            locale="ja"
            :auto-apply="true" 
            :auto-close="true"
            week-start="0"
            :enable-time-picker="false"
        ></VueDatePicker>
        {{ inputDate }}
参照
https://vue3datepicker.com/migration/from-v8

transitions 过度
         -->
        <VueDatePicker 
            v-model="selectedDate"
            format="yyyy/MM/dd"
            model-type="yyyy-MM-dd"
            locale="ja"
            :auto-apply="true"
            :auto-close="true"
            week-start="0"
            :enable-time-picker="false"
            :month-picker="isMonthPicker"
            :day-picker="isDatePicker"
            @update:model-value="handleDateSelect"
        ></VueDatePicker>
         {{ selectedDate }}
    </div>
    </div>
</template>


<style scoped>
/* 最低限のstyle */
.date-picker {
  margin: 60px auto 0;
  width: 50%;
}
</style>
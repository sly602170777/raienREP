# Vue2 到 Vue3 迁移指南

以下是 Vue2 迁移到 Vue3 需要修改的主要内容和代码示例：

---

## 一、项目初始化方式变化

### Vue2 写法
```javascript
import Vue from 'vue'
import App from './App.vue'

new Vue({
  render: h => h(App)
}).$mount('#app')
```

### Vue3 写法
```javascript
import { createApp } from 'vue'
import App from './App.vue'

createApp(App).mount('#app')
```

**变化说明：**
- 使用 `createApp` 工厂函数创建应用实例
- 全局 API 改为通过应用实例调用

---

## 二、组合式 API（Composition API）

### Vue2 Options API
```javascript
export default {
  data() {
    return { count: 0 }
  },
  methods: {
    increment() {
      this.count++
    }
  }
}
```

### Vue3 Composition API
```javascript
import { ref } from 'vue'

export default {
  setup() {
    const count = ref(0)
    
    const increment = () => {
      count.value++
    }

    return {
      count,
      increment
    }
  }
}
```

**核心变化：**
- 引入 `setup()` 函数作为组合式 API 的入口
- 使用 `ref`/`reactive` 创建响应式数据
- 需要手动暴露模板需要的变量和方法

---

## 三、生命周期钩子变化

| Vue2          | Vue3            |
|---------------|-----------------|
| beforeCreate  | setup()         |
| created       | setup()         |
| beforeMount   | onBeforeMount   |
| mounted       | onMounted       |
| beforeUpdate  | onBeforeUpdate  |
| updated       | onUpdated       |
| beforeDestroy | onBeforeUnmount |
| destroyed     | onUnmounted     |

**使用示例：**
```javascript
import { onMounted } from 'vue'

export default {
  setup() {
    onMounted(() => {
      console.log('组件已挂载')
    })
  }
}
```

---

## 四、v-model 语法升级

### Vue2 双向绑定
```vue
<!-- 父组件 -->
<ChildComponent v-model="pageTitle" />

<!-- 子组件 -->
<input :value="value" @input="$emit('input', $event.target.value)" />
```

### Vue3 写法
```vue
<!-- 父组件 -->
<ChildComponent v-model:title="pageTitle" />

<!-- 子组件 -->
<input 
  :value="title" 
  @input="$emit('update:title', $event.target.value)"
/>
```

**变化说明：**
- 支持多个 `v-model` 绑定
- 默认使用 `modelValue` 作为 prop，`update:modelValue` 作为事件
- 移除 `.sync` 修饰符

---

## 五、事件总线变化

### Vue2 事件总线
```javascript
// 创建
const bus = new Vue()

// 发送
bus.$emit('event-name', payload)

// 接收
bus.$on('event-name', callback)
```

### Vue3 推荐方案（使用 mitt）
```javascript
import mitt from 'mitt'

// 创建
const emitter = mitt()

// 发送
emitter.emit('event-name', payload)

// 接收
emitter.on('event-name', callback)
```

**变化说明：**
- Vue3 移除了 `$on`, `$off` 等事件 API
- 推荐使用第三方库实现事件总线

---

## 六、过滤器（Filter）移除

### Vue2 过滤器
```vue
<template>
  <div>{{ price | currency }}</div>
</template>

<script>
export default {
  filters: {
    currency(value) {
      return '$' + value.toFixed(2)
    }
  }
}
</script>
```

### Vue3 替代方案
```vue
<template>
  <div>{{ currency(price) }}</div>
</template>

<script>
export default {
  methods: {
    currency(value) {
      return '$' + value.toFixed(2)
    }
  }
}
</script>
```

**变化说明：**
- 过滤器语法被完全移除
- 推荐使用方法或计算属性替代

---

## 七、全局 API 变化

### Vue2 全局 API
```javascript
Vue.component('my-component', { /* ... */ })
Vue.directive('focus', { /* ... */ })
Vue.mixin({ /* ... */ })
```

### Vue3 实例 API
```javascript
const app = createApp({})

app.component('my-component', { /* ... */ })
app.directive('focus', { /* ... */ })
app.mixin({ /* ... */ })
```

**变化说明：**
- 全局 API 改为应用实例方法
- 避免污染全局命名空间

---

## 八、片段支持（多个根节点）

### Vue2 需要单个根元素
```vue
<template>
  <div>
    <header></header>
    <main></main>
  </div>
</template>
```

### Vue3 支持多个根节点
```vue
<template>
  <header></header>
  <main></main>
</template>
```

---

## 九、Transition 类名变化

### Vue2 类名
```
v-enter
v-enter-active
v-enter-to
```

### Vue3 类名
```
v-enter-from
v-enter-active
v-enter-to
```

**变化说明：**
- `v-enter` 重命名为 `v-enter-from`
- `v-leave` 重命名为 `v-leave-from`

---

## 迁移建议

1. 使用官方迁移构建版本（@vue/compat）
2. 分阶段逐步迁移
3. 优先处理控制台警告
4. 使用 Vue CLI 或 Vite 创建新项目
5. 利用官方迁移检查工具（https://v3-migration.vuejs.org/）

**官方迁移指南：**  
[Vue3 迁移指南](https://v3-migration.vuejs.org/)

-- 移行時に使用した資料
https://qiita.com/taisei-ide-lyd/items/4bdfdf6cd9345001795b#%E7%A7%BB%E8%A1%8C%E6%99%82%E3%81%AB%E4%BD%BF%E7%94%A8%E3%81%97%E3%81%9F%E8%B3%87%E6%96%99


https://v3-migration.vuejs.org/zh/breaking-changes/
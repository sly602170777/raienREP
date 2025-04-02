以下是添加了关键字高亮的改进版迁移指南（使用 **加粗** 进行重点标注）：

```markdown
# Vue2 到 Vue3 迁移指南

---

## 一、项目初始化方式变化

### Vue2 写法（**Vue** 构造函数）
```javascript
import **Vue** from 'vue'  // <-- Vue2 核心构造函数
import App from './App.vue'

new **Vue**({              // <-- 使用 new 创建实例
  render: h => h(App)
}).**$mount**('#app')      // <-- $mount 方法挂载
```

### Vue3 写法（**createApp** 工厂函数）
```javascript
import { **createApp** } from 'vue'  // <-- Vue3 工厂函数
import App from './App.vue'

**createApp**(App)          // <-- 创建应用实例
  .**mount**('#app')        // <-- 简化的 mount 方法
```

---

## 二、组合式 API（**Composition API**）

### Vue2 **Options API**
```javascript
export default {
  **data**() {           // <-- 数据选项
    return { count: 0 }
  },
  **methods**: {         // <-- 方法选项
    increment() {
      this.count++
    }
  }
}
```

### Vue3 **Composition API**
```javascript
import { **ref** } from 'vue'  // <-- 响应式 API

export default {
  **setup**() {         // <-- 新的入口函数
    const count = **ref**(0)  // <-- 创建响应式引用
    
    const increment = () => {
      count.**value**++  // <-- 需要 .value 访问
    }

    return {      // <-- 必须显式返回
      count,
      increment
    }
  }
}
```

---

## 三、生命周期钩子变化

| Vue2               | Vue3                 |
|--------------------|----------------------|
| **beforeCreate**   | → 使用 **setup()**   |
| **created**        | → 使用 **setup()**   |
| **beforeMount**    | → **onBeforeMount**  |
| **mounted**        | → **onMounted**      |
| **beforeUpdate**   | → **onBeforeUpdate** |
| **updated**        | → **onUpdated**      |
| **beforeDestroy**  | → **onBeforeUnmount**|
| **destroyed**      | → **onUnmounted**    |

---

## 四、**v-model** 语法升级

### Vue2（单一 **value**）
```vue
<!-- 子组件 -->
<input 
  :**value**="value" 
  @input="$emit('**input**', $event.target.value)"
/>
```

### Vue3（支持多个 **model**）
```vue
<!-- 父组件 -->
<ChildComponent **v-model:title**="pageTitle" />

<!-- 子组件 -->
<input 
  :**title**="title" 
  @input="$emit('**update:title**', $event.target.value)"
/>
```

---

## 五、全局 API 变化

### Vue2（全局 **Vue** 对象）
```javascript
**Vue.component**('my-component', { /* ... */ })  // <-- 全局注册
**Vue.directive**('focus', { /* ... */ })
```

### Vue3（应用实例 **app**）
```javascript
const app = **createApp**({})  // <-- 创建应用实例

app.**component**('my-component', { /* ... */ })  // <-- 实例方法
app.**directive**('focus', { /* ... */ })
```

---

## 六、**Transition** 类名变化

### Vue2
```css
.**v-enter** { /* 进入开始状态 */ }
.**v-enter-active** { /* 进入激活状态 */ }
```

### Vue3
```css
.**v-enter-from** { /* 进入开始状态 */ }  // <-- -from 后缀
.**v-enter-active** { /* 进入激活状态 */ }
```

---

通过 **加粗** 和注释标记，可以更直观地看到：
1. **废弃的 Vue2 特性**
2. **新增的 Vue3 API**
3. **语法/用法变化点**
4. **需要特别注意的破坏性变更**

建议配合官方迁移工具使用：[Vue 3 Migration Guide](https://v3-migration.vuejs.org/)
```
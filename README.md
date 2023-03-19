# 
Vue中有2种数据绑定的方式：

1. 单向绑定(v-bind)： 数据只能从data流向页面。

2. 双向绑定(v-model)： 数据不仅能从data流向页面，还可以从页面流向data。

备注：

双向绑定一般都应用在表单类元素上（如：input、select等）
v-model:value 可以简写为 v-model，因为v-model默认收集的就是value值。

v-bind 缩写
<!-- 完整语法 -->
<a v-bind:href="https://www.w3cschool.cn/vuejs2/url"></a>
<!-- 缩写 -->
<a :href="https://www.w3cschool.cn/vuejs2/url"></a>

<!-- 完整语法 -->
<a v-on:click="doSomething"></a>
<!-- 缩写 -->
<a @click="doSomething"></a>


Vue.js 2.0 开发插件
插件通常会为Vue添加全局功能。插件的范围没有限制——一般有下面几种：

添加全局方法或者属性，如：vue-element
添加全局资源：指令/过滤器/过渡等，如：vue-touch
通过全局 mixin方法添加一些组件选项，如：vuex
添加 Vue 实例方法，通过把它们添加到 Vue.prototype 上实现。
一个库，提供自己的 API，同时提供上面提到的一个或多个功能，如：vue-router


created, mounted的区别
	createdはDOMがまだ作られていない状態で、
	mountedではDOMが作成された直後の状態です，mounted時にはDOMの要素が取得できる
	

总结
	父传值子通过props实现
	子传父通过emit自定义事件 实现
	兄弟传值通过 eventBus实现
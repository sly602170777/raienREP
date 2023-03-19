# 
Vue中有2种数据绑定的方式：

1. 单向绑定(v-bind)： 数据只能从data流向页面。

2. 双向绑定(v-model)： 数据不仅能从data流向页面，还可以从页面流向data。

备注：

双向绑定一般都应用在表单类元素上（如：input、select等）
v-model:value 可以简写为 v-model，因为v-model默认收集的就是value值。
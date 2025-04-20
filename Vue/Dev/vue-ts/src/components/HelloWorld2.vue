<script setup lang="ts">
  import { ref, defineProps } from "vue";

  defineProps<{ msgs: string }>();

  const isOpen = ref<boolean>(false);
  const count = ref<number>(10);
</script>


<template>
  <div>
    <h1>{{ msgs }}</h1>

    <div class="card">
      <button style="color: red;" type="button" @click="count++">count is {{ count }}</button>
      <div>
        <button @click="isOpen = !isOpen">
          {{ isOpen ? "Close" : "Open" }}
        </button>
        <!-- 
          Vue 提供的内置组件，用于为元素或组件的进入和离开添加过渡效果。
          name="fade" 指定了过渡的名称为 fade，
          Vue 会根据这个名称自动添加对应的 CSS 类
          （如 fade-enter-active 和 fade-leave-active）。 -->
        <transition name="fade">
          <div v-if="isOpen">
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </div>
        </transition>
      </div>
    </div>
  </div>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>

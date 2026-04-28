<script setup lang="ts">
import { ref, computed, watch } from "vue"
import { RecycleScroller } from 'vue-virtual-scroller'
import 'vue-virtual-scroller/dist/vue-virtual-scroller.css'

const treeData = ref([
  {
    id: 1,
    title: "Item 1",
    children: [
      { id: 2, title: "Item 1-1", children: [] },
      { id: 3, title: "Item 1-2", children: [] },
    ],
  },
  {
    id: 4,
    title: "Item 2",
    children: [{ id: 5, title: "Item 2-1", children: [] }],
  },
])

function getAllNodeIds(nodes: any[]): number[] {
  return nodes.reduce((acc: number[], node: any) => {
    acc.push(node.id)
    if (node.children && node.children.length > 0) {
      acc.push(...getAllNodeIds(node.children))
    }
    return acc
  }, [])
}

const open = ref<number[]>(getAllNodeIds(treeData.value))
const selection = ref<number[]>(getAllNodeIds(treeData.value))
const selectedItems = ref<number[]>(getAllNodeIds(treeData.value))

const items = computed(() => {
  const flatten = (arr: any[]): any[] =>
    arr.reduce((acc, item) => {
      acc.push({ title: item.title, value: item.id })
      if (item.children) {
        acc.push(...flatten(item.children))
      }
      return acc
    }, [])
  return flatten(treeData.value)
})

watch(selection, (newVal) => {
  selectedItems.value = newVal
}, { deep: true })

watch(selectedItems, (newVal) => {
  selection.value = newVal
}, { deep: true })

function toggleSelect(arr: number[], val: number) {
  const idx = arr.indexOf(val)
  if (idx === -1) {
    return [...arr, val]
  } else {
    return arr.filter(v => v !== val)
  }
}
</script>

<template>
  <v-container>
    <!-- v-treeview直接使用，不用虚拟滚动 -->
    <v-treeview
      v-model="selection"
      :items="treeData"
      :open="open"
      item-key="id"
      item-title="title"
      item-children="children"
      selectable
      open-on-click
    />

    <!-- v-select虚拟滚动 -->
    <v-select
      :items="items"
      label="Select"
      multiple
      v-model="selectedItems"
    >
      <template #menu="{ props }">
        <RecycleScroller
          :items="items"
          :item-size="36"
          style="max-height: 300px"
          v-slot="{ item }"
        >
          <v-list-item
            v-bind="props"
            :key="item.value"
            :value="item.value"
            @click="selectedItems.value = toggleSelect(selectedItems.value, item.value)"
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </RecycleScroller>
      </template>
    </v-select>
    <p>選択されたアイテム: {{ selectedItems }}</p>
  </v-container>
</template>
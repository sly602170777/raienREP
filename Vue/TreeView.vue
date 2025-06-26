<script setup lang="ts">
import { ref, computed, watch } from "vue"
import { RecycleScroller } from 'vue-virtual-scroller'
import 'vue-virtual-scroller/dist/vue-virtual-scroller.css'

const treeData = ref([
  {
    id: 1,
    title: "Item 1",
    children: [
      { id: 2, title: "Item 1-1"},
      { id: 3, title: "Item 1-2" },
    ],
  },
  {
    id: 4,
    title: "Item 2",
    children: [{ id: 5, title: "Item 2-1"}],
  },
])

// 添加一万条一级节点
for (let i = 6; i < 10006; i++) {
  treeData.value.push({
    id: i,
    title: `Item ${i}`,
    children: [],
  })
}
function getAllNodeIds(nodes: any[]): number[] {
  return nodes.reduce((acc: number[], node: any) => {
    acc.push(node.id)
    if (node.children && node.children.length > 0) {
      acc.push(...getAllNodeIds(node.children))
    }
    return acc
  }, [])
}

const open = ref<number[]>([])
const selection = ref<number[]>([])
const selectedItems = ref<number[]>([])

const items = computed(() => {
  return treeData.value.map(parent => ({
    header: parent.title,
    children: parent.children.map(child => ({
      title: child.title,
      value: child.id
    }))
  }))
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
      open-all
      item-key="id"
      item-title="title"
      item-children="children"
      selectable
      open-on-click
    />
    <v-select
      :items="items"
      label="Select"
      multiple
      v-model="selectedItems"
      item-title="title"
      item-value="value"
    >
    <!-- v-select虚拟滚动 -->
      <template #item="{ item, props }">
    <v-list-subheader v-if="item.header">{{ item.header }}</v-list-subheader>
    <v-list-item
      v-else
      v-bind="props"
      :key="item.value"
      :value="item.value"
    >
    <template #prepend>
        <v-checkbox
          :model-value="selectedItems.includes(item.value)"
          @update:model-value="checked => {
            if (checked) {
              if (!selectedItems.includes(item.value)) selectedItems.push(item.value)
            } else {
              const idx = selectedItems.findIndex(sel => sel.value === item.value)
              if (idx !== -1) selectedItems.splice(idx, 1)
            }
          }"
          @click.stop
        />
      </template>
      <v-list-item-title>{{ item.title }}</v-list-item-title>
    </v-list-item>
  </template>
</v-select>
    <p>選択されたアイテム: {{  }}</p>
  </v-container>
</template>
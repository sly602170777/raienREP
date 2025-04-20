<template>
    <div>
        <h1>Dynamic Com</h1>
        <div v-for="d in data" :key="d.id">
            <component :is="comp(d.type, d.name)"></component>
        </div>
    </div>

</template>
<script setup lang="ts">
import { h } from "vue";

const data = [
    { type: "text", id: 1, name: "HelloWorld" },
    { type: "image", id: 2, name: "image🌟🌟 HelloWorld2" },
    { type: "text", id: 3, name: "Computed" },
    { type: "image", id: 4, name: "image🌟🌟 Lifecycle" },
    { type: "text", id: 5, name: "ParentCom" },
];
let comp = (type: string, name: string) => {
    switch (type) {
        case "text":
            return () => {
                return h("div", null, name)
            }
            break;
        case "image":
            return () => {
                return h("image", null, name)
            }
            break;

        default:
            return () => {
                return h("div", null, "Unknown Type");
            };
    }
}

</script>
<style scoped></style>
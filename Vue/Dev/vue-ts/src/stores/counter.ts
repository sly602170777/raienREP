import { defineStore } from "pinia";
import { computed, ref } from "vue";
//定义状态
/* interface State {
  count: number;

} 
//定义类型
interface Getters {
  doubleCount: number;
}
//定义actions类型
interface Actions {
  increment(): void;
  decrement(): void;    

}*/

//定义store
export const useCounterStore = defineStore("counter", ()=>{
  const count = ref(0);
  const doubleCount = computed(() => count.value * 2);
  const increment = () => {
    count.value++;
  }
  const  decrement=()=> {
    count.value--;
  }
  return { count, doubleCount, increment, decrement };
})
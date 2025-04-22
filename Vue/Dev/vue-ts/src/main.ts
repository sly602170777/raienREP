import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'


//创建app实例
const app =  createApp(App)

//床架pinia实例
const pinia = createPinia()

//使用router
app.use(router)
//使用pinia
app.use(pinia)
//使用VueDatePicker
app.component('VueDatePicker', VueDatePicker);
//挂载app实例
app.mount('#app')

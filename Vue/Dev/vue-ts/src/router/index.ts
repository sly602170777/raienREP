//1 .定义router 相关逻辑
//   history 模式：hash模式和history模式 
import { h } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
//import type { RouteRecordRaw } from 'vue-router'
import Home from '../pages/Home.vue'


//1.1 定义路由表
//1.2 定义路由表的类型
//1.3 定义路由表的内容
const routes= [
  {
    path: '/',
    name: 'Home',
    //component: () => h("div",'/Home')
    //component:  h("div",'../pages/Home.vue')
    component: Home// 组件懒加载
    //component: () => import('../pages/Home.vue')// 组件懒加载
  },
  {
    path: '/about',
    name: 'About',
    component: () => h("div",'../pages/About.vue')
  }
]

//1.4 创建router实例
//1.5 创建router实例的类型
const router = createRouter({
  history: createWebHistory(),
    routes // `routes: routes` 的缩写
});
//2 .导出router 相关逻辑
export default router;
//3 .导入router 相关逻辑
//4.使用router 相关逻辑
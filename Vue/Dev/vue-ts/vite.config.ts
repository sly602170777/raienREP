import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig({
  server: {
    hmr: true, // 确保 HMR 功能启用
    port: 5173, // 替换为未被占用的端口
    
  },
  plugins: [vue()],
  root: '.', // 确保根目录为当前目录
  build: {
    rollupOptions: {
      input: './index.html', // 指定入口文件
    },
  }, 
})

import '@/assets/main.css'
import router from '@/router/router';
import { createPinia } from 'pinia';

import { createApp } from 'vue'
import App from './App.vue' // Provide the correct path to the App.vue file

const pinia = createPinia();

createApp(App).use(router).use(pinia).mount('#app');

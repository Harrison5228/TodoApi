import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '@/components/home/HomePage.vue';
import LoginPage from '@/components/login/LoginPage.vue';
import TodoListPage from '@/components/todo/TodoList.vue';

const routes = [
  {
    path: '/todoList', 
    name: 'TodoList',
    component: TodoListPage,
  },
  {
    path: '/login',
    name: 'Login',
    component: LoginPage
  },
  {
    path: '/',
    name: 'Home',
    component: HomePage
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

import { TodoApi } from '@/core/lib/api';
import { ICreateTodoRequest, ITodoItem, IUpdateTodoRequest } from '@/interface/ITodoList';
import { UUID } from 'crypto';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useTodoStore = defineStore('Todo', () => {
    const isLoaded = ref(false);
    const todoList = ref<ITodoItem[]>([]);

    async function fetchTodoList() {
      isLoaded.value = false;
      const response = await TodoApi.getAllList();
      todoList.value = response.data;
      todoList.value.sort((front, back) => (front.createDateTime && back.createDateTime) ? (front.createDateTime > back.createDateTime ? 1 : -1) : 0);
      isLoaded.value = true;
    }

    async function createTodo(todo: ICreateTodoRequest) {
      await TodoApi.create(todo);
      await fetchTodoList();
    }

    async function deleteTodo(id: UUID) {
      await TodoApi.delete(id);
      await fetchTodoList();
    }

    async function updateTodo(todo: IUpdateTodoRequest) {
      await TodoApi.update(todo);
      await fetchTodoList();
    }

  return {
      todoList,
      fetchTodoList,
      createTodo,
      deleteTodo,
      updateTodo,
      isLoaded,
  };
});

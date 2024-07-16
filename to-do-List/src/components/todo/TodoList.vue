<template>
  <div class="todo-list-container">
    <h1>{{ username }}'s To-Do List</h1>
    
    <div v-if="!isLoaded">
        loading...
    </div>
    <div v-else>
      <Button 
        className="btn success" 
        buttonText="Add New Todo"
        v-on:click="openModal()"
      >
      </Button>
      <ul class="todo-list">
        <TodoItem
          v-for="todo in todoList"
          v-bind:key="todo.id"
          v-bind:todo="todo"
          v-on:edit="openModal"
        />
      </ul>
    </div>
  </div>
  <TodoModal
      v-if="showModal"
      v-bind:currentTodo="currentTodo"
      v-on:close="closeModal"
  />
</template>

<script lang="ts" setup>
  import { storeToRefs } from 'pinia';
  import { useTodoStore } from '@/store/todoStore';
  import { useUserStore } from '@/store/userStore';
  import { ref } from 'vue';
  import { ITodoItem } from '@/interface/ITodoList';
  import TodoItem from '@/components/todo/TodoItem.vue';
  import Button from '@/components/Button.vue';
  import TodoModal from '@/components/todo/TodoModal.vue';
  
  const { username } = storeToRefs(useUserStore());
  const { getUser } = useUserStore();
  const { todoList, isLoaded } = storeToRefs(useTodoStore());
  const { fetchTodoList } = useTodoStore();
  
  fetchTodoList();
  getUser();

  let currentTodo: ITodoItem | null = null;
  const showModal = ref(false);
  const openModal = (todo?: ITodoItem | null) => {
    currentTodo = todo ?? null;
    showModal.value = true;
  };
  const closeModal = () => {
    showModal.value = false;
  };

  
</script>

<style lang="scss" scoped>
  @import '@/components/todo/TodoList';
</style>

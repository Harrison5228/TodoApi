<template>
  <li class="todo-item" v-bind:class="{
      'completed': props.todo.isCompleted,
    }">
    <Button 
      theme="primary"
      size="small"
      buttonText="Update"
      v-on:click="emit('edit', todo)"
    >
    </Button>
    <div class="todo-content">
      <h3>{{ todo.title }}</h3>
      <p>{{ todo.description }}</p>
      <p>Status: {{ status }}</p>
      <p>Created: {{ createDate }}</p>
      <p>Updated: {{ updateDate }}</p>
    </div>
    <Button 
      theme="error"
      size="small"
      buttonText="Delete"
      v-on:click="deleteItem(todo.id)" >
    </Button>
  </li>
</template>
  
<script lang="ts" setup>
  import Button from '@/components/Button.vue';
  import { ITodoItem } from '@/interface/ITodoList';
  import { Status } from '@/interface/enum';
  import { useTodoStore } from '@/store/todoStore';
  import { UUID } from 'crypto';
  import { PropType, computed } from 'vue';

  const { deleteTodo } = useTodoStore();

  const props = defineProps({
    todo: {
      type:  Object as PropType<ITodoItem>,
      default: null,
      required: true,
    },
  });
  
  const emit = defineEmits(['edit']);
  const status = computed(() =>props.todo.isCompleted ? Status.Completed : Status.NotCompleted);
  const createDate = computed(() => formatDate(props.todo.createDateTime));
  const updateDate = computed(() => formatDate(props.todo.updateDateTime));

  const formatDate = (dateString?: string) => {
      if (!dateString ) 
          return '';
      const date = new Date(dateString);
      return date.toLocaleString();
  };

  const deleteItem = (id: UUID) => {
      deleteTodo(id);
  };

  
</script>
  
<style lang="scss" scoped>
  .todo-item {
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: white;
    padding: 10px;
    margin-bottom: 10px;
    border-radius: 4px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

    &.completed {
      background-color: #d4edda; // 綠色背景，表示完成
    }
  }
  
  .todo-content {
    margin-left: 20px;
    text-align: left;
  }
  
  h3 {
    margin: 0;
    font-size: 1.2em;
  }
  
  p {
    margin: 0;
    font-size: 0.9em;
    color: #555;
  }
</style>
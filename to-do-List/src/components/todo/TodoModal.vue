<template>
  <div class="todo-modal">
    <div class="todo-modal-content">
      <span class="close" v-on:click="closeModal">&times;</span>
      <h2>{{ modalTitle }}</h2>
      <Form
        v-on:submit="submitForm"
      >
        <FormGroup
            v-for="field in formFields"
            v-bind:key="field.id"
            v-bind:label="field.label"
            v-bind:labelFor="field.id"
        >
            <Textarea
              v-if="field.type ==='textarea'"
              v-bind:rows="field.rows"
              v-bind:type="field.type"
              v-bind:id="field.id"
              v-model="editableTodo[field.model]"
              className="textarea"
              v-bind:required="field.required"
            />
            <Input
              v-else
              v-bind:type="field.type"
              v-bind:id="field.id"
              v-model:modelValue="editableTodo[field.model]"
              v-bind:required="field.required"
            />
        </FormGroup>
        <Button 
          class="btn success"
          v-bind:buttonText="buttonText"
          buttonType="submit"
        >
        </Button>
      </Form>
    </div>
  </div>
</template>
  
<script lang="ts" setup>
import { computed, ref } from "vue";
import { useTodoStore } from "@/store/todoStore";
import { useUserStore } from "@/store/userStore";
import { ITodoItem } from "@/interface/ITodoList";
import { ICommonField } from "@/interface/IElementProps";
import Form from "@/components/Form.vue";
import FormGroup from "@/components/FormGroup.vue";
import Input from "@/components/Input.vue";
import Textarea from "@/components/Textarea.vue";
import Button from '@/components/Button.vue';

const { username } = useUserStore();
const { createTodo, updateTodo } = useTodoStore();

const props = defineProps({
  currentTodo: {
    type: Object as () => ITodoItem | null,
    default: undefined,
  },
});

const isEdit = computed(() => !!props.currentTodo?.id) ;
const modalTitle = computed(() => (isEdit.value ? 'Edit Todo' : 'Create New Todo'));
const buttonText = computed(() => (isEdit.value ? 'Update' : 'Create'));

const editableTodo = ref<ITodoItem>({ ...props.currentTodo } as ITodoItem || null);

const emit = defineEmits(['close']);

const submitForm = () => {
    if (!editableTodo.value?.title) {
        alert('Title is required');
        return;
    }
    if (isEdit.value) {
      if (!editableTodo.value.id) {
        return;
      }
      updateTodo({
        ...editableTodo.value,
      });
      closeModal();
      return;
    }
    createTodo({
      ...editableTodo.value,
      username: username
    });
    
    closeModal();
};
const closeModal = () => {
  emit('close');
};

const formFields = ref<ICommonField[]>([
{
    id: 'title',
    label: 'Title',
    type: 'text',
    model: 'title',
    className: '',
    required: true,
  },
  {
    id: 'description',
    label: 'Description',
    type: 'textarea',
    model: 'description',
    rows: 4,
    className:'',
    required: false
  },
  {
    id: 'isCompleted',
    label: 'Completed',
    type: 'checkbox',
    model: 'isCompleted',
    className: '',
    required: false,
  }
]);

</script>
  
<style lang="scss" scoped>
.todo-modal {
  display: flex;
  justify-content: center;
  align-items: center;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
  background-color: rgba(0, 0, 0, 0.4);
}

.todo-modal-content {
  background-color: #fefefe;
  margin: 15% auto;
  padding: 20px;
  border: 1px solid #888;
  width: 80%;
  max-width: 500px;
  border-radius: 8px;
  text-align: left;
}

.close {
  color: #aaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: black;
  cursor: pointer;
}

form {
  display: flex;
  flex-direction: column;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
}
</style>
  
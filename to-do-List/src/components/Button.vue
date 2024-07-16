<template>
  <button 
    v-bind:type="buttonType"
    class="btn" 
    v-bind:class="classes"
    v-on:click="emit('click')"
  >
    {{ buttonText }}
  </button>
</template>
  
<script lang="ts" setup>
  import { PropType, computed } from 'vue';  

  const props = defineProps({
      buttonType: {
          type: String as PropType<'button' | 'submit' | 'reset'>,
          default: '',
      },
      buttonText: {
          type: String,
          required: true,
      },
      theme: {
          type: String as PropType<'success' | 'primary' | 'error'>,
          default: '',
      },
      size:{
          type: String as PropType<'small' | 'normal' | 'large'>,
          default: 'normal',
      }
  });
  const emit = defineEmits(['click']);


  const classes = computed(() => {
      return {
          [props.theme]: props.theme,
          'btn-small': props.size === 'small',
          'btn-large': props.size === 'large',
      };
  });
</script>
  
<style lang="scss" scoped>
  .btn {
    padding: 10px 20px;
    margin-bottom: 20px;
    text-align: center;
    display: inline-block;
    border-radius: 4px;
    border: none;

    &-small {
      padding: 5px 10px;
    }

    &-large {
      font-size: 16px;
      margin: 8px 0px;
      width: 100%;
    }
  }
  
  .success {
    background-color: #4CAF50;
    color: white;

    &:hover {
      background-color: #6dbe71;
    }
  }

  .primary {
    background-color: #007bff;
    color: white;

    &:hover {
      background-color: #0056b3;
    }
  }

  .error {
    background-color: #dc3545;
    color: white;

    &:hover {
      background-color: #c82333;
    }
  }
</style>
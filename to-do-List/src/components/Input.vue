<template>
  <div>
    <input
      v-bind:type="type"
      v-bind:id="id"
      v-bind:value="modelValue"
      v-on:input="updateValue"
      v-bind:required="required"
      v-bind:className="className"
    />
  </div>
</template>

<script lang="ts" setup>

const props = defineProps({
  type: {
    type: String,
    required: true,
  },
  id: {
    type: String,
    required: true,
  },
  modelValue: {
    type: [String, Boolean],
    required: false,
  },
  className: {
    type: String,
    default: '',
  },
  required: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(['update:modelValue']);
const updateValue = (event: Event) => {
  const target = event.target as HTMLInputElement;
  const value = props.type === 'checkbox' ? (target as HTMLInputElement).checked : target.value;
  emit('update:modelValue', value);
};
</script>

<style lang="scss" scoped>
input {
  width: 100%;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}
</style>
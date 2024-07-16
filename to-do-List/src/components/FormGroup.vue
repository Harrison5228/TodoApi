<template>
  <div class="form-group">
    <label v-bind:labelFor="labelFor">{{ label }}</label>
    <slot></slot>
  </div>
</template>

<script lang="ts" setup>

defineProps({
  label: {
    type: String,
    required: true,
  },
  labelFor: {
    type: String,
    required: true,
  },
});
</script>

<style scoped>
.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
}
</style>
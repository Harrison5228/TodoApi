<template>
  <form v-on:submit.prevent="emit('submit')">
    <slot></slot>
  </form>
</template>

<script lang="ts" setup>

const emit = defineEmits(['submit']);

</script>

<template>
  <div class="login-container">
    <h2>Login</h2>
    <Form
      v-on:submit="login">
      <FormGroup
        v-for="field in formFields"
        v-bind:key="field.id"
        v-bind:label="field.label"
        v-bind:labelFor="field.id"
      >
        <Input
          v-bind:type="field.type"
          v-bind:id="field.id"
          v-model:modelValue="field.model"
          v-bind:required="field.required"
          v-bind:inputClass="field.id"
        />
      </FormGroup>
      <Button 
        theme="success"
        size="large"
        buttonText="Login"
        buttonType="submit"
      >
      </Button>
    </Form>
  </div>
</template>

<script lang="ts" setup>

import { useAuth } from '@/composable/useAuth';
import { useUserStore } from '@/store/userStore';
import { storeToRefs } from 'pinia';
import { MaybeRef, ref } from 'vue';
import { ICommonField } from '@/interface/IElementProps';
import Form from '@/components/Form.vue';
import FormGroup from '@/components/FormGroup.vue';
import Input from '@/components/Input.vue';
import Button from '@/components/Button.vue';

const { handleLogin } = useAuth();
const { username } = storeToRefs(useUserStore());
const password = ref('');

async function login(){
  await handleLogin(username.value, password.value);
}
const aa = ref('cc');
const cc: MaybeRef<string> = 'dddd';
const formFields = ref<ICommonField[]>([
  {
    id: 'username',
    label: 'Username:',
    type: 'text',
    model: cc,
    className: '',
    required: true
  },
  {
    id: 'password',
    label: 'Password:',
    type: 'password',
    model: aa,
    className: '',
    required: true
  }
]);

formFields.value.map((field) => {
  console.log(field.model);
  console.log(cc);
});

</script>

<style scoped lang="scss">
@import "@/components/login/LoginPage";
</style>

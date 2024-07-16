import { UserApi } from '@/core/lib/api';
import { defineStore } from 'pinia'
import { ref } from 'vue';


export const useUserStore = defineStore('User', () => {
    const username = ref(''); 
    async function getUser() {
        const response = await UserApi.getUser();
        username.value = response.data;
    }

    return {
        username,
        getUser,
    };
});
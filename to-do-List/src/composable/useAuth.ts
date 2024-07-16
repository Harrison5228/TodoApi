import { UserApi } from '@/core/lib/api';

export function useAuth() {
  
  async function handleLogin(username: string, password: string) {
    await UserApi.login(username, password)
    return ;
  }

  return {
    handleLogin,
  };
}

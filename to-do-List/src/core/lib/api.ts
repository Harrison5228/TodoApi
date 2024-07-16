import axios, { AxiosPromise, AxiosResponse } from 'axios';
import { getToDoBackEndUrl } from '@/core/lib/url';
import { UUID } from 'crypto';
import { ICreateTodoRequest, IGetTodoResponse, ITodoItem, IUpdateTodoRequest } from '@/interface/ITodoList';
import router from '@/router/router';


function createInstance(baseUrl: string) {
    return axios.create({
        baseURL: baseUrl,
        withCredentials: true,
    });
}

export const apiInstance = createInstance(`${getToDoBackEndUrl()}/api`);

apiInstance.interceptors.response.use(
    (response) => {
        
        return response;
    },
    (error) => {
        const { response } = error;
        if (response) {
            if (response.status === 401) {
                router.push({ name: 'Login' });
            }
        }

        return Promise.reject(error);
    },
);


export const UserApi = {
    async login(username: string, password: string) {
        await apiInstance.post('/auth/login', { username, password }); 
        router.push({ name: 'TodoList' });
    },
    async getUser(): AxiosPromise<string> {
        const response = await apiInstance.get('/auth/getUser'); 
        return response;
    },
};
export const TodoApi = {
    //Todo 研究code gen
    async getAllList(): AxiosPromise<ITodoItem[]> {
        const response: AxiosResponse<IGetTodoResponse[]> = await apiInstance.get<IGetTodoResponse[]>('/todo/getAll');
        const todoList = response.data.map<ITodoItem>( value =>({
            ...value,
        }));
        
        return {  
            ...response,
            data: todoList, 
        };
    },
    async delete(id: UUID) : AxiosPromise<void>{
        return apiInstance.post('/todo/delete', { id });
    },
    async create(data: ICreateTodoRequest): AxiosPromise<UUID> {
        return apiInstance.post('/todo/create', data);
    },
    async update(data: IUpdateTodoRequest): AxiosPromise<void> {
        return apiInstance.post('/todo/update', data);
    },
};



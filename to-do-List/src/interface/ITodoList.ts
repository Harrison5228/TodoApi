import { UUID } from "crypto";

export interface ITodoItem {
    id: UUID;
    title: string;
    description?: string;
    isCompleted: boolean;
    createDateTime: string;
    updateDateTime?: string;
    [key: string] : string | boolean | undefined;
}

export interface IGetTodoResponse {
    id: UUID;
    title: string;
    description?: string;
    isCompleted: boolean;
    createDateTime: string;
    updateDateTime?: string;
}
  
  
export interface ICreateTodoRequest {
    title: string;
    description?: string;
    username: string;
}

export interface IUpdateTodoRequest {
    id: UUID;
    title: string;
    description?: string;
    isCompleted: boolean;
}
import { MaybeRef } from "vue";


export interface ICommonField {
    id: string,
    label: string,
    type: string,
    model: MaybeRef<string>,
    className: string,
    required: boolean,
    rows?: number,
}
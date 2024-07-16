import { __URL_TODO_BACKEND__ } from '@/core/lib/constant';

export function getUrl(envUrl = '', protocol = '') {
    protocol = protocol || window.location.protocol;
    return `${protocol}//${envUrl.replace('{host}', 'localhost')}`;
}

export function getToDoBackEndUrl() {
    return getUrl(__URL_TODO_BACKEND__);
}
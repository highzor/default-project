

// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

import {httpClient} from '../helpers/HttpClient';

import { TasksModel } from '../api_models/TasksModel';
class _TasksService {
 list = async () => {
        // get: api/Tasks/List
        var _Url = 'api/Tasks/List';
        const {data} = await httpClient.get<TasksModel[]>(_Url);
        return data;
    };
 info = async (id: number) => {
        // get: api/Tasks/Info?id=${id}
        var _Url = 'api/Tasks/Info?id=${id}';
        const {data} = await httpClient.get<TasksModel>(_Url);
        return data;
    };
}
export const TasksService = new _TasksService(); 
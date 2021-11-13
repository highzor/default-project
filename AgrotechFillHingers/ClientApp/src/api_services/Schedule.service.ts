

// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

import {httpClient} from '../helpers/HttpClient';

import { ScheduleModel } from '../api_models/ScheduleModel';
class _ScheduleService {
 list = async () => {
        // get: api/Schedule/List
        var _Url = 'api/Schedule/List';
        const {data} = await httpClient.get<ScheduleModel[]>(_Url);
        return data;
    };
 info = async (id: number) => {
        // get: api/Schedule/Info?id=${id}
        var _Url = 'api/Schedule/Info?id=${id}';
        const {data} = await httpClient.get<ScheduleModel>(_Url);
        return data;
    };
}
export const ScheduleService = new _ScheduleService(); 
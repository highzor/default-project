

// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

import {httpClient} from '../helpers/HttpClient';

import { ScheduleStatusModel } from '../api_models/ScheduleStatusModel';
class _ScheduleStatusService {
 list = async () => {
        // get: api/ScheduleStatus/List
        var _Url = 'api/ScheduleStatus/List';
        const {data} = await httpClient.get<ScheduleStatusModel>(_Url);
        return data;
    };
}
export const ScheduleStatusService = new _ScheduleStatusService(); 


// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

import {httpClient} from '../helpers/HttpClient';

import { UserModel } from '../api_models/UserModel';
class _UserService {
 list = async () => {
        // get: api/User/List
        var _Url = 'api/User/List';
        const {data} = await httpClient.get<UserModel>(_Url);
        return data;
    };
 info = async (id: number) => {
        // get: api/User/Info?id=${id}
        var _Url = 'api/User/Info?id=${id}';
        const {data} = await httpClient.get<UserModel>(_Url);
        return data;
    };
}
export const UserService = new _UserService(); 
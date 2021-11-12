"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.httpClient = void 0;
var axios_1 = require("axios");
var StatusCode;
(function (StatusCode) {
    StatusCode[StatusCode["BadRequest"] = 400] = "BadRequest";
    StatusCode[StatusCode["Forbidden"] = 403] = "Forbidden";
})(StatusCode || (StatusCode = {}));
var headers = {
    Accept: 'application/json',
    'Content-Type': 'application/json; charset=utf-8',
    'Access-Control-Allow-Credentials': 'true',
    'X-Requested-With': 'XMLHttpRequest'
};
var injectToken = function (config) {
    try {
        var token = localStorage.getItem('accessToken');
        if (token != null && config.headers != undefined) {
            config.headers.Authorization = 'Bearer ${token}';
        }
        return config;
    }
    catch (error) {
        throw new Error(typeof error === "string" ? error : "");
    }
};
var HttpClient = /** @class */ (function () {
    function HttpClient() {
        this.instance = null;
    }
    Object.defineProperty(HttpClient.prototype, "http", {
        get: function () {
            return this.instance != null ? this.instance : this.initHttp();
        },
        enumerable: false,
        configurable: true
    });
    HttpClient.prototype.initHttp = function () {
        var _this = this;
        var http = axios_1.default.create({
            headers: headers,
            withCredentials: true
        });
        http.interceptors.request.use(injectToken, function (error) { return Promise.reject(error); });
        http.interceptors.response.use(function (response) { return response; }, function (error) {
            var response = error.response;
            return _this.handleError(response);
        });
        this.instance = http;
        return http;
    };
    HttpClient.prototype.get = function (url, config) {
        return this.http.get(url, config);
    };
    HttpClient.prototype.post = function (url, data, config) {
        return this.http.put(url, data, config);
    };
    HttpClient.prototype.delete = function (url, config) {
        return this.http.delete(url, config);
    };
    HttpClient.prototype.handleError = function (error) {
        var status = error.status, data = error.data;
        var statusText = data;
        switch (status) {
            case StatusCode.BadRequest: {
                throw statusText;
            }
            case StatusCode.Forbidden: {
                throw new Error('Unauthorized');
            }
        }
        return Promise.reject(statusText);
    };
    return HttpClient;
}());
exports.httpClient = new HttpClient();
//# sourceMappingURL=HttpClient.js.map
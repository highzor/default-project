import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';

enum StatusCode {
    BadRequest = 400,
    Forbidden = 403,
}

const headers: Readonly<Record<string, string>> = {
    Accept: 'application/json',
    'Content-Type': 'application/json; charset=utf-8',
    'Access-Control-Allow-Credentials': 'true',
    'X-Requested-With': 'XMLHttpRequest'
};

const injectToken = (config: AxiosRequestConfig): AxiosRequestConfig => {
    try {
        const token = localStorage.getItem('accessToken');
        if (token != null && config.headers != undefined) {
            config.headers.Authorization = 'Bearer ${token}';
        }
        return config;
    }
    catch (error) {
        throw new Error(typeof error === "string" ? error : "");
    }
}

class HttpClient {
    private instance: AxiosInstance | null = null;

    private get http(): AxiosInstance {
        return this.instance != null ? this.instance : this.initHttp();
    }

    initHttp() {
        const http = axios.create({
            headers,
            withCredentials: true
        });

        http.interceptors.request.use(injectToken, (error) => Promise.reject(error));

        http.interceptors.response.use(
            (response) => response,
            (error) => {
                const { response } = error;
                return this.handleError(response);
            }
        )
        this.instance = http;
        return http;
    }

    get<T = any, R = AxiosResponse<T>>(url: string, config?: AxiosRequestConfig): Promise<R> {
        return this.http.get<T, R>(url, config);
    }

    post<T = any, R = AxiosResponse<T>>(
        url: string,
        data?: T,
        config?: AxiosRequestConfig
    ): Promise<R> {
        return this.http.put<T, R>(url, data, config);
    }

    delete<T = any, R = AxiosResponse<T>>(url: string, config?: AxiosRequestConfig): Promise<R> {
        return this.http.delete<T, R>(url, config);
    }

    private handleError(error) {
        const { status, data } = error;
        let statusText = data;
        switch (status) {
            case StatusCode.BadRequest: {
                throw statusText;
            }
            case StatusCode.Forbidden: {
               
                throw new Error('Unauthorized');
            }
        }
        return Promise.reject(statusText)
    }
}

export const httpClient = new HttpClient();
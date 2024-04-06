import { DataProvider, fetchUtils } from "react-admin";
import { stringify } from "query-string";


const apiUrl = import.meta.env.VITE_API_URL;

const httpClient = fetchUtils.fetchJson;

export const dataProvider: DataProvider = {
    getList: async (resource, params) => {

        const { page, perPage } = params.pagination;

        params.filter = {
            ...params.filter,
            page, 
            perPage
        }

        const objString = new URLSearchParams(params.filter).toString();
        const url = `${apiUrl}/${resource}?${objString}`;
        // console.log(url);

        return await httpClient(url).then(({ headers, json }) => ({
            data: json,
            total: parseInt((headers.get('content-range') || "0").split('/').pop() || '0', 10),
        }));
    },

    getOne: async (resource, params) =>
        await httpClient(`${apiUrl}/${resource}/${params.id}`).then(({ json }) => ({
            data: json,
        })),

    getMany: async (resource, params) => {
        const queryString = params.ids.map(value => `id=${value}`).join('&') + '&perPage=100';
        const url = `${apiUrl}/${resource}?${queryString}`;
        return await httpClient(url).then(({ json }) => ({
            data: json
        }));
    },

    getManyReference: (resource, params) => {
        const { page, perPage } = params.pagination;
        const { field, order } = params.sort;
        const query = {
            sort: JSON.stringify([field, order]),
            range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
            filter: JSON.stringify({
                ...params.filter,
                [params.target]: params.id,
            }),
        };
        const url = `${apiUrl}/${resource}?${stringify(query)}`;        

        return httpClient(url).then(({ headers, json }) => ({
            data: json,
            total: parseInt((headers.get('content-range') || "0").split('/').pop() || '0', 10),
        }));
    },

    update: (resource, params) =>
        httpClient(`${apiUrl}/${resource}/${params.id}`, {
            method: 'PUT',
            body: JSON.stringify(params.data),
        }).then(({ json }) => ({
            data: json
        })),

    updateMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ id: params.ids }),
        };
        return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
            method: 'PUT',
            body: JSON.stringify(params.data),
        }).then(({ json }) => ({ data: json }));
    },

    create: (resource, params) =>
        httpClient(`${apiUrl}/${resource}`, {
            method: 'POST',
            body: JSON.stringify(params.data),
        }).then(({ json }) => ({
            data: { ...params.data, id: json.id } as any,
        })),

    delete: (resource, params) =>
        httpClient(`${apiUrl}/${resource}/${params.id}`, {
            method: 'DELETE',
        }).then(({ json }) => ({
            data: json
        })),

    deleteMany: (resource, params) => {
        // const query = {
        //     filter: JSON.stringify({ id: params.ids }),
        // };

        const queryString = params.ids.map(value => `id=${value}`).join('&');
        const url = `${apiUrl}/${resource}?${queryString}`;

        return httpClient(url, {
            method: 'DELETE',
        }).then(({ json }) => ({ data: json }));
    }
};

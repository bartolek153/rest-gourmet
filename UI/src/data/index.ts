import { DataProvider, fetchUtils } from "react-admin";
import { QueryClient } from "react-query";
import { stringify } from "query-string";


let apiUrl = 'https://webapiaugustagourmet.azurewebsites.net/api';
apiUrl = 'http://localhost:5274/api';

const httpClient = fetchUtils.fetchJson;

export const dataProvider: DataProvider = {
    getList: (resource, params) => {
        const { page, perPage } = params.pagination;
        // const { field, order } = params.sort;
        
        params.filter.page = page;
        params.filter.perPage = perPage;
        
        
        const query = {
            // sort: JSON.stringify([field, order]),

            page: page,
            perPage: perPage,

            q: params.filter.q,
            group: params.filter.group,
        };

        const objString = new URLSearchParams(params.filter).toString();

        // const url = `${apiUrl}/${resource}?${stringify(query)}`;
        const url = `${apiUrl}/${resource}?${objString}`;

        console.info(url)


        return httpClient(url).then(({ headers, json }) => ({
            data: json,
            // data: json.map(resource => ({ ...resource, id: resource.Id }) ),

            total: parseInt((headers.get('content-range') || "0").split('/').pop() || '0', 10),
        }));
    },

    getOne: (resource, params) =>
        httpClient(`${apiUrl}/${resource}/${params.id}`).then(({ json }) => ({
            data: json,
            // data: { ...json, id: json.Id },
        })),

    getMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ id: params.ids }),
        };
        const url = `${apiUrl}/${resource}?${stringify(query)}`;
        return httpClient(url).then(({ json }) => ({ 
            data: json 
            // data: json.map(resource => ({ ...resource, id: resource.Id }) ),
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
            // data: json.map(resource => ({ ...resource, id: resource.Id }) ),
            total: parseInt((headers.get('content-range') || "0").split('/').pop() || '0', 10),
        }));
    },

    update: (resource, params) =>
        httpClient(`${apiUrl}/${resource}/${params.id}`, {
            method: 'PUT',
            body: JSON.stringify(params.data),
        }).then(({ json }) => ({ 
            data: json 
            // data: { ...json, id: json.Id },
    })),

    updateMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ id: params.ids}),
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
            // data: { ...params.data, id: json.Id } as any,
        })),

    delete: (resource, params) =>
        httpClient(`${apiUrl}/${resource}/${params.id}`, {
            method: 'DELETE',
        }).then(({ json }) => ({ 
            data: json 
            // data: { ...json, id: json.Id },
        })),

    deleteMany: (resource, params) => {
        const query = {
            filter: JSON.stringify({ id: params.ids}),
        };
        return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
            method: 'DELETE',
        }).then(({ json }) => ({ data: json }));
    }
};


// const queryClient = new QueryClient({
//         defaultOptions: {
//             queries: {
//                 staleTime: 5 * 60 * 1000, // 5 minutes
//             },
//         },
//     });



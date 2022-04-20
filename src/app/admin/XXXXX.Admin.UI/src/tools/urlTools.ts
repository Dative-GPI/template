import axiosBuildURL from 'axios/lib/helpers/buildURL';

function deepFlat(key: string, value: any): { key: string, value: any }[] {
    if ((typeof value !== 'object' || value === null || value instanceof Date)) {
        return [{ key, value }]
    }
    else if (Array.isArray(value)) {
        return value.map(i => {
            return { key, value: i };
        })
    }
    else {
        const result = [];
        for (const subKey in value) {
            result.push(...deepFlat(key + "." + subKey, value[subKey]))
        }
        return result;
    }
}

function clear(params: any) {
    for (const param in params) {
        if (!params[param])
            delete params[param];
    }

    return params;
}

function flat(obj: any) {
    const result: { [key: string]: any } = {}
    for (const key in obj) {
        const flatted = deepFlat(key, obj[key]);
        for (const item of flatted) {
            result[item.key] = item.value
        }
    }
    return result;
}


export function buildURL(url: string, params?: any, paramsSerializer?: (params: any[]) => any[]) {

    if (params) {
        params = clear(params);

        params = flat(params);
    }

    return axiosBuildURL(url, params, paramsSerializer);
}
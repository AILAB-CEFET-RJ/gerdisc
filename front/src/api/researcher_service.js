import api from './_api'

export async function getResearchers(){
    return await api.get("externalResearchers")?.data
}

export async function postResearchers(data) {
    return (await api.post("externalResearchers", data))?.data
}
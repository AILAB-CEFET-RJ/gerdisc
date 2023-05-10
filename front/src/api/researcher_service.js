import api from './_api'

export async function getResearchers(){
    return await api.get("researchers")?.data
}

export async function postResearchers(data) {
    return (await api.post("researchers", data))?.data
}
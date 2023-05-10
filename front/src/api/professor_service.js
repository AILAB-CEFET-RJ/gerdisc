import api from './_api'

export async function getProfessors(){
    return (await api.get("professors"))?.data
}

export async function postProfessors(data){
    return (await api.post("professors",data))?.data
}
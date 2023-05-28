import api from './_api'

export async function getResearch(){
    return (await api.get("dissertations"))?.data
}

export async function postResearch(data){
    return (await api.post("dissertations",data))?.data
}
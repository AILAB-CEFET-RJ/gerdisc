import api from './_api'

export async function getStudents(){
    return (await api.get("api/Students"))?.data
}

export async function postStudents(data){
    return (await api.post("api/Students",data))?.data
}
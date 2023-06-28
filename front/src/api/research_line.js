import api from './_api'

export async function getResearchLines(){
    return (await api.get("researchLines"))?.data
}
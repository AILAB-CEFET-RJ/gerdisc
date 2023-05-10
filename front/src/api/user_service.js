import api from './_api'

export async function Login({email, password})
    {
        api.post('users/login', { email, password})
        .then((response)=>{
            if (response.status === 200)
            {
                localStorage.setItem('token', response.data.token)
                localStorage.setItem('role', response.data?.user?.role)
                localStorage.setItem('name', `${response.data?.user?.firstName} ${response.data?.user?.lastName}`)
                return response.data?.user
            }
            else{
                return null
            }
        })
        .catch((promise)=>{
            console.log(promise)
            return null
        })
    }



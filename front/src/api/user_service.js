import api from './_api'

export function Login({email, password})
    {
        return api.post('users/login', { email, password})
    }



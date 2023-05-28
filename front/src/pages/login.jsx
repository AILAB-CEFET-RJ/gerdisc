import React from 'react'
import '../styles/login.scss'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Login as login } from '../api/user_service'

export default function Login() {
    const navigate = useNavigate()
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState(undefined)

    const handleSubmit = async (e) => {
        e.preventDefault()
        setError(undefined)
        const user = login({ email, password })
            .then((response) => {
                if (response.status === 200) {
                    localStorage.setItem('token', response.data.token)
                    localStorage.setItem('role', response.data?.user?.role)
                    localStorage.setItem('name', `${response.data?.user?.firstName} ${response.data?.user?.lastName}`)
                    return response.data?.user
                }
                else {
                    return null
                }
            })
            .catch((promise) => {
                return null
            })
        if (user !== null) {
            console.log(user)
            navigate("/")
        }
        else {
            setError('login failed')
        }
    }


    return (
        <>
            <main className='login'>
                <div className={"body"}>
                    <div className={"header"}>
                        <div className='app-name'>
                            GERDISC
                        </div>
                        <div className={"headerOptions"}>
                            <div style={{ "marginRight": "2rem" }}> Sobre</div>
                            <div> Contato</div>
                        </div>
                    </div>
                    <div className={"form"}>
                        <p>Entrar na conta</p>
                        <label htmlFor='email'>Email</label>
                        <input type='text' id='email' placeholder='Digite seu email' value={email} onChange={(e) => setEmail(e.target.value)} />
                        <label htmlFor='password'>Senha</label>
                        <input type='password' id='password' placeholder='Digite sua senha' value={password} onChange={(e) => setPassword(e.target.value)} />
                        <input type='submit' id='submit' value={'Login'} onClick={(e) => handleSubmit(e)} />
                        {error && <p> {error} </p>}
                    </div>
                </div>
            </main>
        </>
    )
}
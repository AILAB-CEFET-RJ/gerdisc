import React from 'react'
import '../styles/login.scss'
import Head from '../components/header'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function Login() {
    const navigate = useNavigate()
    const [ email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const handleSubmit = (e)=> {
        console.log(email, password)
        navigate("/")

    }
    return (
        <>
        <Head>  title={"Login"}, name={"Login Page"}</Head>
        <main className='login'>
            <div className={"body"}>
                <div className={"header"}>
                    <div className='app-name'>
                        GERDISC
                    </div>
                    <div className={"headerOptions"}>
                    <div style={{ "marginRight": "2rem"}}> Sobre</div>
                    <div> Contato</div>
                    </div>
                </div>
                <div className={"form"}>
                    <p>Entrar na conta</p>
                    <label htmlFor='email'>Email</label>
                    <input type='text' id='email' placeholder='Digite seu email' value={email} onChange={(e)=>setEmail(e.target.value)}/>
                    <label htmlFor='password'>Senha</label>
                    <input type='password' id='password' placeholder='Digite sua senha' value={password} onChange={(e)=>setPassword(e.target.value)}/>
                    <input type='submit' id='submit' value={'Login'} onClick={(e)=>handleSubmit(e)}/>
                </div>
            </div>
        </main>
        </>
    )
}
import styles from '@/styles/Login.module.css'
import Head from 'next/head'
import { useState } from 'react'
import { useRouter } from 'next/router'
import { useNavigate } from 'react-router-dom'

export default function Login() {
    const router = useRouter()
    const navigator = useNavigate()
    const [ email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const handleSubmit = (e)=> {
        console.log(email, password)
        router.push(
            {
            pathname:'/Home',
            query: {name: "Radhanama",role: "Administrator"}
            })
        navigator.

    }
    return (
        <>
      <Head>
        <title>Login</title>
        <meta name="description" content="Gerdisc login page" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
        <main className='login'>
            <div className={styles.body}>
                <div className={styles.header}>
                    <div className='app-name'>
                        GERDISC
                    </div>
                    <div className={styles.headerOptions}>
                    <div style={{ "marginRight": "2rem"}}> Sobre</div>
                    <div> Contato</div>
                    </div>
                </div>
                <div className={styles.form}>
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
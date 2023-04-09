import styles from '@/styles/HomePage.module.css'
import Head from 'next/head'

export default function Home()
{
    return (
        <>
        <Head>
            <title>Estudantes</title>
            <meta name="description" content="Student List Page" />
            <meta name="viewport" content="width=device-width, initial-scale=1" />
            <link rel="icon" href="/favicon.ico" />
        </Head>
        <main className={styles.main}>
            <div className={styles.body}>
                <div className={styles.header}>
                    <div className={styles.appName}>
                        <div className={styles.bleap}> </div>
                        <span>GERDISC</span>
                    </div>
                    <div className={styles.headerOptions}>
                    <div>Olá, Coordenador</div>
                    </div>
                </div>
                <div className={styles.headerBreak}></div>
                <br></br>
                <div id='student'>
                    <img src="/student.png" width="80rem" align=""/>
                    <h3 id='pre'>Estudantes</h3>
                </div>
                <div>
                    <input placeholder='Pesquisar...'/>
                    <button margin="1rem">Cadastrar novo estudante</button>
                </div>
                <div id="tableContainer">
                    <table border="1">
                        <tr>
                            <td>Nome Completo</td>
                            <td>Projeto de Pesquisa</td>
                            <td>Data de Entrada</td>
                            <td>Previsão de Defesa</td>
                        </tr>
                        <tr>
                            <td>José da Silva Gomes</td>
                            <td>Projeto Exemplo Exemplo</td>
                            <td>14/02/2022</td>
                            <td>14/11/2023</td>
                        </tr>
                        <tr>
                            <td>Maria Eduarda Ferreira Dias</td>
                            <td>Lorem Ipsum</td>
                            <td>10/03/2022</td>
                            <td>11/12/2023</td>
                        </tr>
                        <tr>
                            <td>Felipe Duarte dos Santos</td>
                            <td>Exemplo Pesquisa</td>
                            <td>22/11/2021</td>
                            <td>17/09/2023</td>
                        </tr>
                    </table>
                </div>
                
                <div className={styles.footer}><img src='/cefet.png' /></div>
            </div>
        </main>
        </>
    );
}
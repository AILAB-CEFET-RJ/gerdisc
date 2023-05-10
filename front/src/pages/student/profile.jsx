import Header from "../../components/header";
import Footer from "../../components/footer";
import { useParams } from "react-router";
import { useEffect, useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import "../../styles/profile.scss";


export default function StudentProfile()
{
    const {id} = useParams()
    const [student, setStudent] = useState({})
    useEffect(()=>
    {
        setStudent({
            name: "Radhanama",
            email: "radhanama@gmail.com",
            proficiency: "Ingles Avançado",
            projeto: "Analise de Dados e Aplicacões",
            entranceDate: "20/01/2019",
            defenceDate: "20/01/2023",
            qualificationDate: "10/01/2023"
        })
    },[id,setStudent])

    return(
        <div className='studentProfile'>
        <main className={"main"}>
            <div className={"body"}>
                <Header name={id}/>
                <div className="back-button"><FontAwesomeIcon icon={faArrowLeft} color="white" height={"1rem"} width="1rem" /></div>
                <div className="card-label">Perfil estudante</div>
                <div className="studentCard">
                    <p>Nome: {student.name}</p>
                    <p>Email: {student.email}</p>
                    <p>Proficiencia: {student.proficiency}</p>
                    <p>Projeto de pesquisa: {student.project}</p>
                    <p>Data de ingresso: {student.entranceDate}</p>
                    <p>Previsao de defesa: {student.defenseDate}</p>
                    <p>Previsao de qualificação: {student.qualificationDate}</p>
                </div>
                <Footer></Footer>
            </div>
        </main>
        </div>
    );
}
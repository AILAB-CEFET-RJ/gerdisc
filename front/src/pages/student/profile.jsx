import { useParams } from "react-router";
import { useEffect, useState } from "react";
import "../../styles/profile.scss";
import { useNavigate } from "react-router";
import { getStudentById } from "../../api/student_service";
import BackButton from "../../components/BackButton";
import ErrorPage from "../../components/error/Error";
import jwt_decode from "jwt-decode";
import PageContainer from "../../components/PageContainer";


export default function StudentProfile() {
    const { id } = useParams()
    const [student, setStudent] = useState(undefined)
    const [error, setError] = useState(false)

    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const token = localStorage.getItem('token')
        try {
            const decoded = jwt_decode(token)
        } catch (error) {
            navigate('/login', { replace: true })
        }
    }, [navigate]);

    useEffect(() => {
        getStudentById(id)
            .then(student => {
                console.log(student)
                setStudent(student);
                setIsLoading(false);
            })
            .catch(error => setError(true))
    }, [id, setStudent, setError, setIsLoading]);

    return (
        <PageContainer name={name} isLoading={isLoading}>
            {!error && <div style={
                { display: "flex", flexDirection: "column", flexWrap: 'wrap' }
            }>
                <div className="bar">
                    <BackButton />
                    <div className="options">
                        <input type={'button'} className="option" value={"Criar Dissertação"} onClick={(e) => navigate(`researches/add`)} />
                        <input type={'button'} className="option" value={'Criar Extensão'} onClick={(e) => navigate('extensions/add')} />
                    </div>
                </div>
                {!isLoading && <>
                    <div className="card-label">Perfil estudante</div>
                    <div className="studentCard">
                        <p>Nome: {`${student.firstName} ${student.lastName}`}</p>
                        <p>Email: {student.email}</p>
                        <p>Proficiencia: {student.proficiency}</p>
                        <p>Matricula: {student.registration}</p>
                        <p>Projeto de pesquisa: {student.projectId}</p>
                        <p>Data de ingresso: {student.entryDate}</p>
                        <p>Previsao de defesa: {student.projectDefenceDate}</p>
                        <p>Previsao de qualificação: {student.projectQualificationDate}</p>
                        <p>Bolsa: {student.scholarship}</p>
                    </div>
                </>}
            </div>
            }
            {error && <ErrorPage />}

        </PageContainer>
    );
}
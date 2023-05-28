import { useEffect, useState } from "react"
import '../../styles/researchList.scss';
import Table from "../../components/Table/table"
import { getResearch } from "../../api/research_service"
import { useNavigate } from "react-router"
import jwt_decode from "jwt-decode";
import BackButton from "../../components/BackButton";
import ErrorPage from "../../components/error/Error";
import PageContainer from "../../components/PageContainer";


export default function ResearchList() {
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [isLoading, setIsLoading] = useState(true)
    const [error, setError] = useState(false)
    const [researches, setResearches] = useState([])

    useEffect(() => {
        const roles = ['Administrator', 'Professor']
        const token = localStorage.getItem('token')
        try {
            const decoded = jwt_decode(token)
            if (!roles.includes(decoded.role)) {
                navigate('/')
            }
            setRole(decoded.role)
        } catch (error) {
            navigate('/login')
        }
    }, [setRole, navigate, role]);

    useEffect(() => {
        getResearch()
            .then(result => {
                let mapped = []
                if (result !== null && result !== undefined) {
                    mapped = result.map((project) => {
                        return {
                            Id: project.Id,
                            Nome: project.name,
                            Status: project.status,
                            Professores: project.orientator,
                            Students: project.student
                        }
                    })
                }
                setResearches(mapped)
                setIsLoading(false)

            })
            .catch(error => {
                setError(true)
                setIsLoading(false)
            })
    }, [setResearches, setIsLoading])


    return (
        <PageContainer name={name} isLoading={isLoading}>
            {!error && <>
                <div className="researchBar">
                    <div className="left-bar">
                        <div>
                            <img src="research.png" alt="A logo representing Researches" height={"100rem"} />
                        </div>
                        <div className="title">Dissertações</div>
                    </div>
                    <div className="right-bar">
                        {/* <div className="search">
                            <input type="search" name="search" id="search" />
                            <i className="fas fa-" />
                        </div> */}
                    </div>
                </div>
                <BackButton />
                <Table data={researches} />
            </>
            }
            {error && <ErrorPage />}
        </PageContainer>
    )
}
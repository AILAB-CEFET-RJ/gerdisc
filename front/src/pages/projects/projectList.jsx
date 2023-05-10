import { useEffect, useState } from "react"
import '../../styles/projectList.scss';
import Header from "../../components/header"
import Table from "../../components/Table/table"
import { getProjects } from "../../api/project_service"
import { useNavigate } from "react-router"
import jwt_decode from "jwt-decode";
import Footer from "../../components/footer"

export default function ProjectList() {
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [isLoading, setIsLoading] = useState(true)
    const [projects, setProjects] = useState([])

    useEffect(() => {
        const roles = ['Administrator']
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
        getProjects()
            .then(result => {
                let mapped = []
                if (result !== null && result !== undefined) {
                    console.log(result)
                    mapped = result.map((project) => {
                        return {
                            Id: project.Id,
                            Nome: project.name,
                            Status: project.status,
                            Professores: project?.professors?.length,
                            Dissertações: project?.dissertations.length,
                            Students:project?.students?.length
                        }
                    })
                }
                setProjects(mapped)
                setIsLoading(false)

            })
    }, [setProjects, setIsLoading])


    return (<div className="projectList">
        <main className="main">
            <div className="body">
                <Header name={name} />
                <div className="projectBar">
                    <div className="left-bar">
                        <div>
                            <img src="lamp.png" alt="A logo representing Projects" height={"100rem"} />
                        </div>
                        <div className="title">Projetos</div>
                    </div>
                    <div className="right-bar">
                        <div className="search">
                            <input type="search" name="search" id="search" />
                            <i className="fas fa-"/>
                        </div>
                        <div className="create-button">
                            <button>Novo Projeto</button>
                        </div>
                    </div>
                </div>
                {!isLoading && <Table data={projects} />}
                {isLoading && <div>Loading</div>}
                <Footer></Footer>
            </div>
        </main>
    </div>)
}
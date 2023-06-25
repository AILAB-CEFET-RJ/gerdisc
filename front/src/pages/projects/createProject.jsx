import { useEffect, useState } from "react";
import "../../styles/createProject.scss";
import { useNavigate, useParams } from "react-router"
import jwt_decode from "jwt-decode";
import { getProfessors } from "../../api/professor_service"
import Select from "../../components/select";
import BackButton from "../../components/BackButton";
import MultiSelect from "../../components/Multiselect";
import ErrorPage from "../../components/error/Error";
import PageContainer from "../../components/PageContainer";
import { postProjects, getProjectById, putProjectsById } from "../../api/project_service";

export default function ProjectForm({ Update = false }) {
    const {id} = useParams()
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [error, setError] = useState(null);
    const [isUpdate] = useState(Update)
    const [isLoading, setIsLoading] = useState(true)
    const [professors, setProfessor] = useState([])
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [project, setProject] = useState(
        {
            name: '',
            status: 'Ativo',
            professorIds: [],
        }
    );

    useEffect(() => {
        setIsLoading(true);
        getProfessors()
            .then(result => {
                let mapped = []
                if (result !== null && result !== undefined) {
                    mapped = result.map((professor) => {
                        return {
                            Id: professor.id,
                            Name: `${professor.firstName} ${professor.lastName}  - ${professor.siape}`,
                        }
                    })
                }
                setProfessor(mapped)
                setIsLoading(false)

            })

    }, [setProfessor, setIsLoading])

    const setName = (name) => {
        let newValue = {}
        newValue['name'] = name
        console.log(newValue)
        setProject({ ...project, ...newValue });
    }
    const setStatus = (status) => {
        let newValue = {}
        newValue['status'] = status
        setProject({ ...project, ...newValue });
    }
    useEffect(()=>
    {
        if(isUpdate)
        {
            getProjectById(id)
            .then(project =>
                {
                    setProject(project)
                })
            .catch(err =>
                {
                    setError(true)
                })
        }
    },[isUpdate,isLoading,setIsLoading,id])

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

    const handlepost = async () => {
        postProjects(project)
            .then(() => navigate(-1))
            .catch((error) => setError(error))
    }

    const onProfessorSelect = (selectedList, Item) => {
        console.log(selectedList)
        setProject({ ...project, ...{ professorIds: selectedList.map(item => item.Id) } })
    }

    const handleUpdate = async () => {
        putProjectsById(id, project)
        .then(() => navigate("/projects"))
        .catch((error) => setError(error))
    }

    const handleSave = (e) => {
        e.preventDefault()
        const form = document.querySelector('form')
        if(form.reportValidity())
        {
            isUpdate ? handleUpdate() : handlepost()
        }
    }

    return (
        <PageContainer isLoading={isLoading} name={name}>
            <BackButton />
            {!error && <form className="form">
                <div className="form-section">
                    <div className="formInput">
                        <label htmlFor="name">Nome</label>
                        <input required={true} type="text" name="name" value={project.name} onChange={(e) => setName(e.target.value)} id="name" />
                    </div>
                    <Select required={true} className="formInput" onSelect={setStatus} options={["Ativo", "Inativo", "Fechado"]} label="Status" name="status" />
                </div>
                <div className="form-section">
                    <MultiSelect
                        options={professors}
                        loading={isLoading}
                        placeholder='Selecionar professores'
                        onSelect={onProfessorSelect}
                        onRemove={onProfessorSelect}
                        displayValue="Name"
                    />
                </div>
                <div className="form-section">
                    <div className="formInput">
                        <input type="submit" value={"Submit"} onClick={(e) => handleSave(e)} />
                    </div>
                </div>
            </form>}
            {error && <ErrorPage/>}
        </PageContainer>
    );
}

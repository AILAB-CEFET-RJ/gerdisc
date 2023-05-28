import { useEffect, useState } from "react";
import "../../styles/createProject.scss";
import { useNavigate } from "react-router"
import jwt_decode from "jwt-decode";
import { getProfessors } from "../../api/professor_service"
import Select from "../../components/select";
import BackButton from "../../components/BackButton";
import MultiSelect from "../../components/Multiselect";
import PageContainer from "../../components/PageContainer";

export default function ProjectForm() {
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [error, setError] = useState(null);
    const [isLoading, setIsLoading] = useState(true)
    const [professors, setProfessor] = useState([])
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [project, setProject] = useState(
        {
            name: '',
            status: '',
            professors: [],

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
                            Id: professor.Id,
                            Name: `${professor.user?.firstName} ${professor.user?.lastName}`,
                        }
                    })
                }
                setProfessor(mapped)
                setIsLoading(false)

            })

    }, [setProfessor, setIsLoading])

    const setName = (name) => {
        setProject(...project, ...{ 'name': name });
    }
    const setStatus = (status) => {
        setProject(...project, ...{ 'name': status });
    }

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

    }

    const onProfessorSelect = (selectedList, Item) => {
        setProject(...project, ...{ professors: selectedList })
    }

    const handleSave = (e) => {
        e.preventDefault()
        handlepost()
    }

    return (
        <PageContainer>
            <BackButton />
            <div className="form">
                <div className="form-section">
                    <div className="formInput">
                        <label htmlFor="name">Nome</label>
                        <input type="text" name="name" value={project.name} onChange={(e) => setName(e.target.value)} id="name" />
                    </div>
                    <Select className="formInput" onSelect={setStatus} options={["Ativo", "Inativo", "Fechado"]} label="Status" name="status" />
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
            </div>
        </PageContainer>
    );
}

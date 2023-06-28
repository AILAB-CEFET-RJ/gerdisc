import { useEffect, useState } from "react";
import "../../styles/form.scss";
import { useNavigate, useParams } from "react-router"
import jwt_decode from "jwt-decode";
import Select from "../../components/select";
import BackButton from "../../components/BackButton";
import { getStudentById } from "../../api/student_service";
import { getProjectById } from "../../api/project_service";
import { getResearchers } from "../../api/researcher_service";
import ErrorPage from "../../components/error/Error";
import PageContainer from "../../components/PageContainer";
import { postResearch } from "../../api/research_service";


export default function ResearchForm() {
    const { id } = useParams();
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [error, setError] = useState(null);
    const [errorMessage, setErrorMessage] = useState('');
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [isLoading, setIsLoading] = useState(true)
    const [professorOptions, setProfessorOptions] = useState([]);
    const [externalResearchers, setExternalResearchers] = useState([]);
    const [coorientatorOptions, setCoorientatorOptions] = useState([]);
    const [student, setStudent] = useState({})
    const [project, setproject] = useState({})
    const [research, setResearch] = useState(
        {
            name: '',
            studentId: id,
            orientator: '',
            'co-orientator': '',
        })
    const setName = (name) => {
        setResearch(...research, ...{ 'name': name });
    }
    const setOrientator = (name) => {

        setResearch(...research, ...{ 'orientator': name });
    }
    const setCoorientator = (name) => {
        setResearch(...research, ...{ 'co-orientator': name });
    }

    useEffect(() => {
        if (externalResearchers && professorOptions) {
            let options = externalResearchers.map(r => `${r.firstName} ${r.lastName}`)
            setCoorientatorOptions(professorOptions.concat(options));
        }
    }, [externalResearchers, setCoorientatorOptions, professorOptions]);

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
        setIsLoading(true);
        if (student?.projectId) {
            getProjectById(student.projectId)
                .then(project => {
                    setproject(project)
                })
                .catch(error => {
                    setError(true)
                    setErrorMessage(error.message)
                })
        }
        setIsLoading(false)
    }, [student.projectId,]);

    useEffect(() => {
        setIsLoading(true)
        getStudentById(id)
            .then(student => {
                setStudent(student)
                return student
            })
            .catch(error => {
                setError(true)
                setErrorMessage(error.message)
            });
        setIsLoading(false)
    }, [setError, setErrorMessage, setIsLoading, id, setStudent])

    useEffect(() => {
        setProfessorOptions(project?.professors?.map(p => `${p.firstName} ${p.lastName}`))
    }, [project,])

    useEffect(() => {
        setIsLoading(true)
        getResearchers()
            .then(reserchers => {
                setExternalResearchers(reserchers)
            })
            .catch(err => {
                setError(true)
                setErrorMessage(err.message)
            })
        setIsLoading(false)
    }, [setExternalResearchers, setErrorMessage, setError])

    const handlepost = async () => {
        postResearch(research)
        .then(result =>navigate(-1))
        .catch(err =>setError(true))
    }

    const handleSave = (e) => {
        e.preventDefault()
        handlepost()
    }

    return (
        <PageContainer name={name} isLoading={isLoading}>
            <BackButton />
            {!error && student && project && <>
                <div className="form">
                    <div className="form-section">
                        <div className="formInput">
                            <label htmlFor="name">Nome</label>
                            <input type="text" name="name" value={research.name} onChange={(e) => setName(e.target.value)} id="name" />
                        </div>
                    </div>
                    <div className="form-section">
                        <Select className="formInput" onSelect={setOrientator} options={professorOptions} label="Orientador" name="orientator" />
                        <Select className="formInput" onSelect={setCoorientator} options={coorientatorOptions} label="Co-Orientador" name="coorientator" />
                    </div>
                    <div className="form-section">
                        <div className="formInput">
                            <input type="submit" value={"Submit"} onClick={(e) => handleSave(e)} />
                        </div>
                    </div>
                </div>
            </>
            }
            {error && <ErrorPage errorMessage={errorMessage} />}
        </PageContainer>

    );
}

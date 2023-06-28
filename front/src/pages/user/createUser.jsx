import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router"
import jwt_decode from "jwt-decode";
import Select from "../../components/select";
import { postProfessors, getProfessorById,putProfessorById } from "../../api/professor_service";
import { postStudents, getStudentById, putStudentById } from "../../api/student_service";
import { getProjects } from "../../api/project_service";
import { postResearchers, getResearcherById, putResearcherById } from "../../api/researcher_service";
import BackButton from "../../components/BackButton";
import ErrorPage from "../../components/error/Error";
import PageContainer from "../../components/PageContainer";
import { ROLES_ENUM, AREA_ENUM, INSTITUTION_TYPE_ENUM } from "../../enum_helpers";



export default function UserForm({ type = undefined, isUpdate = false }) {
    const navigate = useNavigate()
    const { id } = useParams()
    const [userType, setUserType] = useState(type);
    const [name,] = useState(localStorage.getItem('name'))
    const [isStudent, setIsStudent] = useState(false);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState();
    const [errorMessage, setErrorMessage] = useState(undefined);
    const [projects, setProjects] = useState([])
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [user, setUser] = useState({
        firstName: '',
        lastName: '',
        email: '',
        cpf: '',
        password: '',
        createdAt: '',
        role: isStudent ? 'student' : 'Professor',
    })
    const [student, SetStudent] = useState({
        registration: "",
        registrationDate: '',
        status: 1,
        entryDate: '',
        proficiency: false,
        undergraduateInstitution: "",
        institutionType: 1,
        undergraduateCourse: "",
        graduationYear: 2012,
        undergraduateArea: 1,
        dateOfBirth: '',
        scholarship: 0,
        projectId: "",
    })
    const [professor, setProfessor] = useState({
        siape: '',
        institution: '',
        projectId: '',
    })

    useEffect(() => {
        console.log({"usertype": userType, "isstudent": isStudent})
        if (isUpdate) {
            if (isStudent) {
                getStudentById(id)
                    .then(student => {
                        console.log(student)
                        setUser(student)
                        SetStudent(student)
                    })
                    .catch(error => {
                        setError(true)
                        setErrorMessage(error.message)
                    })

            }
            else if (userType === 'Professor') {
                getProfessorById(id)
                    .then(professor => {
                        setUser(professor)
                        setProfessor(professor)
                        console.log(professor)
                    })
                    .catch(error => {
                        setError(true)
                        setErrorMessage(error.message)
                    })
            }
            else if(userType === 'Externo'){
                getResearcherById(id)
                    .then(researcher => {
                        setUser(researcher)
                        setProfessor(researcher)
                    })
                    .catch(error => {
                        setError(true)
                        setErrorMessage(error.message)
                    })
            }
        }
    }, [isUpdate, isStudent, setUser, SetStudent, setProfessor, id, userType]);

    useEffect(() => {
        if (isStudent) {
            setIsLoading(true);
            getProjects()
                .then(result => {
                    let mapped = []
                    if (result !== null && result !== undefined) {
                        mapped = result.map((project) => {
                            return {
                                Id: project.id,
                                Nome: project.name
                            }
                        })
                        setProjects(mapped)
                    }
                })
                .catch(err => setError(true))
            setIsLoading(false);
        }
    }, [isStudent, setProjects, isUpdate])

    const changeUserAtribute = (name, value) => {
        let newValue = {}
        newValue[name] = value
        setUser({ ...user, ...newValue })
    }

    const changeStudentAtribute = (name, value) => {
        let newValue = {}
        newValue[name] = value
        SetStudent({ ...student, ...newValue })
    }
    const changeProfessorAtribute = (name, value) => {
        let newValue = {}
        newValue[name] = value
        setProfessor({ ...professor, ...newValue })
    }

    const handleUsertypeSelect = (value) => {
        setUserType(value);
    };
    const handleProjectSelect = (value) => {
        let project = projects.find(p => p.Nome === value)
        if (userType === 'Professor') {
            setProfessor({ ...professor, ...{ projectId: project?.Id } })
        }
        else {
            SetStudent({ ...student, ...{ projectId: project?.Id } });
        }
    };

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
        setIsStudent(userType === "Estudante");
    }, [userType]);

    const handlepost = async () => {
        if (isStudent) {
            let _user = user
            _user.createdAt = new Date()
            _user.password = student.registration
            _user.role = ROLES_ENUM.Student
            let body = { ..._user, ...student }
            body.entryDate = new Date(body.entryDate)
            body.dateOfBirth = new Date(body.dateOfBirth)
            body.registrationDate = new Date(body.registrationDate)
            body.projectDefenceDate = new Date("2025-05-11")
            body.projectQualificationDate = new Date("2025-05-11")
            postStudents(body)
                .then((student) => navigate("/students"))
                .catch(error => { setError('Unable to create student') });
        }
        else {
            let body = { ...user, ...professor }
            body.createdAt = new Date()
            body.password = professor.siape
            if (userType === "Professor") {
                body.role = ROLES_ENUM.Professor
                postProfessors(body)
                    .then((professor) => navigate("/professors"))
                    .catch(error => { setError('Unable to create Professor') });
            }
            else {
                body.role = ROLES_ENUM.ExternalResearcher
                postResearchers(body)
                    .then((researcher) => navigate("/researchers"))
                    .catch(error => { setError('Unable to create Researcher') });
            }
        }
    }
    const handleSave = (e) => {
        e.preventDefault()
        const form = document.querySelector('form')
        if(form.reportValidity())
        {
            isUpdate ? handleUpdate() : handlepost()
        }
    }
    const handleUpdate = () => {
       if (isStudent) {
        let body = { ...user, ...student }
        putStudentById(id, body)
        .then((student) =>{
            navigate("/students")
        })
        .catch(error => setError(true))
       }
       else if (userType === 'Professor') {
        let body = { ...user, ...professor }
        putProfessorById(id, body)
        .then((student) =>navigate("/professors"))
        .catch(error => setError(true))
       }
       else{
        let body = { ...user, ...professor }
        putResearcherById(id,body)
        .then((student) =>navigate("/researchers"))
        .catch(error => setError(true))
       }
    }
    return (
        <PageContainer name={name} isLoading={isLoading}>
            {!error && <>
                <BackButton />
                <form className="form">
                    {type === undefined && <div className="form-section">
                        <Select required={true} className="formInput" onSelect={handleUsertypeSelect} options={["", "Professor", "Estudante", "Externo"]} label="Tipo de Usuario" name="role" />
                    </div>}
                    <div className="form-section">
                        <div className="formInput">
                            <label htmlFor="firstName">Primeiro Nome</label>
                            <input required={true} type="text" name="firstName" value={user.firstName} onChange={(e) => changeUserAtribute(e.target.name, e.target.value)} id="firstName" />
                        </div>
                        <div className="formInput">
                            <label htmlFor="lastName">SobreNome</label>
                            <input required={true} type="text" name="lastName" id="lastName" value={user.lastName} onChange={(e) => changeUserAtribute(e.target.name, e.target.value)} />
                        </div>
                    </div>
                    <div className="form-section">
                        <div className="formInput">
                            <label htmlFor="email">Email</label>
                            <input required={true} type="email" name="email" id="email" value={user.email} onChange={(e) => changeUserAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="cpf">CPF</label>
                            <input required={true} disabled={isUpdate} type="text" name="cpf" value={user.cpf} id="cpf" onChange={(e) => changeUserAtribute(e.target.name, e.target.value)} />
                        </div>
                    </div>
                    {isStudent && <div className="form-section" id="registration-section">
                        <div className="formInput">
                            <label htmlFor="registration">Matricula</label>
                            <input required={true} disabled={isUpdate} type="text" name="registration" id="registration" value={student.registration} onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="scholarship">Bolsa</label>
                            <input type="number" name="scholarship" id="scholarship" value={student.scholarship} onChange={(e) => changeStudentAtribute(e.target.name, Number(e.target.value))} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="registrationDate">Data de Matricula</label>
                            <input required={true} disabled={isUpdate} type="date" name="registrationDate" id="registrationDate" value={student.registrationDate} onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="entryDate">Data de Entrada</label>
                            <input required={true} disabled={isUpdate} type="date" name="entryDate" id="entryDate" value={student.entryDate} onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="dateOfBirth">Data de Nascimento</label>
                            <input required={true} disabled={isUpdate} type="date" name="dateOfBirth" id="dateOfBirth" value={student.dateOfBirth} onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                    </div>}
                    {isStudent && <div className="form-section" id="qualification-section2">
                        <div className="formInput">
                            <label htmlFor="undergraduateInstitution">Institução de graduação</label>
                            <input required={true} minLength={3} type="text" name="undergraduateInstitution" value={student.undergraduateInstitution} id="undergraduateInstitution" onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="undergraduateCourse">Curso</label>
                            <input required={true} type="text" name="undergraduateCourse" id="undergraduateCourse" value={student.undergraduateCourse} onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                        <div className="formInput">
                            <Select required={true} label={"undergraduateArea"} onSelect={(value)=>changeStudentAtribute('undergraduateArea', Number(AREA_ENUM[value])) } name="undergraduateArea" options={Object.keys(AREA_ENUM)} />
                        </div>
                        <div className="formInput">
                            <label htmlFor="graduationYear">Ano de formação</label>
                            <input required={true} type="number" min={1950} max={3000} name="graduationYear" value={student.graduationYear} id="graduationYear" onChange={(e) => changeStudentAtribute(e.target.name, e.target.value)} />
                        </div>
                    </div>}
                    {isStudent && <div className="form-section" id="qualification-section3">
                        <div className="formInput">
                            <Select required={false} className="formInput" options={Object.keys(INSTITUTION_TYPE_ENUM)} onSelect={(value)=>changeStudentAtribute('institutionType', Number(INSTITUTION_TYPE_ENUM[value])) } label="Tipo de Institução" name="institutionType" />
                        </div>
                        <div className="formInput">
                            <Select required={true} defaultValue="" className="formInput" onSelect={handleProjectSelect} options={[""].concat(projects.map(x => x.Nome))} label="Projeto" name="project" />
                        </div>
                    </div>}
                    {!isStudent && <div className="form-section" id="professor-section">
                        {userType === "Externo" && <div className="formInput">
                            <label htmlFor="institution">Institução</label>
                            <input required={true} type="text" name="institution" value={professor.institution} id="institution" onChange={(e) => changeProfessorAtribute(e.target.name, e.target.value)} />
                        </div>}
                        {userType === "Professor" && <div className="formInput">
                            <Select required={false} className="formInput" onSelect={handleProjectSelect} options={[""].concat(projects.map(x => x.Nome))} label="Projeto" name="project" />
                        </div>
                        }
                        <div className="formInput">
                            <label htmlFor="siape">SIAPE</label>
                            <input required={userType==="Professor"? true: false} disabled={isUpdate} type="text" minLength={3} value={professor.siape} name="siape" id="siape" onChange={(e) => changeProfessorAtribute(e.target.name, e.target.value)} />
                        </div>
                    </div>}
                    <div className="form-section">
                        <div className="formInput">
                            <input type="submit" value={isUpdate ? "Update" : "Submit"} onClick={(e) => handleSave(e)} />
                        </div>
                    </div>
                </form>
            </>}
            {error && <ErrorPage errorMessage={errorMessage} />}
        </PageContainer>

    );
}

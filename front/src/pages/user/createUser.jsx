import Header from "../../components/header";
import Footer from "../../components/footer";
import { useEffect, useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import "../../styles/createUser.scss";
import { useNavigate } from "react-router"
import jwt_decode from "jwt-decode";
import Select from "../../components/select";
import { postProfessors } from  "../../api/professor_service";
import { postStudents } from  "../../api/student_service";
import { postResearchers } from  "../../api/researcher_service";


export default function UserForm({type=undefined}) {
    const navigate  = useNavigate()
    const [userType, setUserType] = useState(type);
    const [name,] = useState(localStorage.getItem('name'))
    const [error, setError] = useState(null);
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [ user, setUser] = useState({
        firstName: '',
        lastname: '',
        email: '',
        cpf: '',
        role: userType,
    })
    const [student, SetStudent] = useState({
        registration: "",
        institutionCountry: "",
        registrationDate: Date.now(),
        status: 1,
        entryDate: Date.now(),
        proficiency: "",
        undergraduateInstitution: "",
        institutionType: "",
        undergraduateCourse: "",
        graduationYear: 2012,
        undergraduateArea: 1,
        dateOfBirth: Date.now(),
        scholarship: 0  
    })
    const [professor, setProfessor] = useState({
        siape: '',
        institution: ''
    })
    const [address, setAddress] = useState({
        country: '',
        city: '',
        street: '',
        number: ''
    })

    const changeAddressAtribute = (name, value)=> {
        let newValue = {name: value}
        setAddress(state=> ({...state, newValue}))
    }
    const changeUserAtribute = (name, value)=> {
        let newValue = {name: value}
        setUser(state=> ({...state, newValue}))
    }

    const changeStudentAtribute = (name, value)=> {
        let newValue = {name: value}
        SetStudent(state=> ({...state, newValue}))
    }
    const changeProfessorAtribute = (name, value)=> {
        let newValue = {name: value}
        setProfessor(state=> ({...state, newValue}))
    }

    const handleUsertypeSelect = (value) => {
        setUserType(value);
    };
    const [isStudent, setIsStudent] = useState(false);

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
    },[userType]);

    const handlepost = async () => {
        if (isStudent) {
            let body = {user, ...student}
            postStudents(body)
            .then((student) => navigate("/students"))
            .catch(error => {setError('Unable to create student')});
        }
        else{
            let body = {user, ...professor}
            if (userType === "Professor"){
                postProfessors(body)
                .then((student) => navigate("/professors"))
                .catch(error => {setError('Unable to create Professor')});
            }
            else {
                postResearchers(body)
                .then((student) => navigate("/researchers"))
                .catch(error => {setError('Unable to create Researcher')});
            }
        }
    }
    const handleSave = (e)=>{
        e.preventDefault()
        handlepost()
    }

    return (
        <div className='createUser'>
            <main className={"main"}>
                <div className={"body"}>
                    <Header name={name} />
                    <div className="back-button"><FontAwesomeIcon icon={faArrowLeft} color="white" height={"1rem"} width="1rem" /></div>
                    <div className="userForm">
                        {type === undefined && <div className="form-section">
                            <Select className="formInput" onSelect={handleUsertypeSelect} options={["Professor", "Estudante", "Externo"]} label="Tipo de Usuario" name="role" />
                        </div>}
                        <div className="form-section">
                            <div className="formInput">
                                <label htmlFor="firstName">Primeiro Nome</label>
                                <input type="text" name="firstName" value={user.firstName} onChange={(e)=>changeUserAtribute(e.target.name, e.target.value)} id="firstName" />
                            </div>
                            <div className="formInput">
                                <label htmlFor="lastName">SobreNome</label>
                                <input type="text" name="lastName" id="lastName" value={user.lastname} onChange={(e)=>changeUserAtribute(e.target.name, e.target.value)} />
                            </div>
                        </div>
                        <div className="form-section">
                            <div className="formInput">
                                <label htmlFor="email">Email</label>
                                <input type="email" name="email" id="email" value={user.email} onChange={(e)=>changeUserAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="cpf">CPF</label>
                                <input type="text" name="cpf" value={user.cpf} id="cpf" onChange={(e)=>changeUserAtribute(e.target.name, e.target.value)}/>
                            </div>
                        </div>
                        {isStudent && <div className="form-section" id="adress-section">
                            <div className="formInput">
                                <label htmlFor="country">País</label>
                                <input type="text" name="country" id="country" value={address.country}  onChange={(e)=> changeAddressAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="city">Cidade</label>
                                <input type="text" name="city" id="city" value={address.city}  onChange={(e)=> changeAddressAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="street">Rua</label>
                                <input type="text" name="street" id="street" value={address.street}  onChange={(e)=> changeAddressAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="number">Numero</label>
                                <input type="text" name="number" id="number" value={address.number}  onChange={(e)=> changeAddressAtribute(e.target.name, e.target.value)} />
                            </div>
                        </div>}
                        {isStudent && <div className="form-section" id="registration-section">
                            <div className="formInput">
                                <label htmlFor="registration">Matricula</label>
                                <input type="text" name="registration" id="registration" value={student.registration}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)}/>
                            </div>
                            <div className="formInput">
                                <label htmlFor="scholarship">Bolsa</label>
                                <input type="text" name="scholarship" id="scholarship" value={student.scholarship}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="registrationDate">Data de Matricula</label>
                                <input type="date" name="registrationDate" id="registrationDate" value={student.registrationDate}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="entryDate">Data de Entrada</label>
                                <input type="date" name="entryDate" id="entryDate" value={student.entryDate}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="dateOfBirth">Data de Nascimento</label>
                                <input type="date" name="dateOfBirth" id="dateOfBirth" value={student.dateOfBirth}   onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)}/>
                            </div>
                        </div>}
                        {isStudent && <div className="form-section" id="qualification-section2">
                            <div className="formInput">
                                <label htmlFor="undergraduateInstitution">Institução de graduação</label>
                                <input type="text" name="undergraduateInstitution" value={student.undergraduateInstitution} id="undergraduateInstitution"  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="undergraduateCourse">Curso</label>
                                <input type="text" name="undergraduateCourse" id="undergraduateCourse" value={student.undergraduateCourse}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="undergraduateArea">Areá</label>
                                <input type="text" name="undergraduateArea" id="undergraduateArea" value={student.undergraduateArea}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                            <div className="formInput">
                                <label htmlFor="graduationYear">Ano de formação</label>
                                <input type="number" min={1950} max={3000} name="graduationYear" value={student.graduationYear} id="graduationYear"  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)}/>
                            </div>
                        </div>}
                        {isStudent && <div className="form-section" id="qualification-section3">
                        <div className="formInput">
                                <label htmlFor="institutionType">Tipo de Institução</label>
                                <input type="text" name="institutionType" id="institutionType" value={student.institutionType}  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)}/>
                            </div>   
                            <div className="formInput">
                                <label htmlFor="institutionCountry">País de Institução</label>
                                <input type="text" name="institutionCountry" value={student.institutionCountry} id="institutionCountry"  onChange={(e)=> changeStudentAtribute(e.target.name, e.target.value)} />
                            </div>
                        </div>}
                        {!isStudent && <div className="form-section" id="professor-section">
                        {userType === "Externo" && <div className="formInput">
                                <label htmlFor="institution">Institução</label>
                                <input type="text" name="institution" value={professor.institution} id="institution" onChange={(e)=> changeProfessorAtribute(e.target.name, e.target.value)} />
                            </div>}
                        <div className="formInput">
                                <label htmlFor="siape">SIAPE</label>
                                <input type="text" minLength={3} value={professor.siape} name="siape" id="siape" onChange={(e)=> changeProfessorAtribute(e.target.name, e.target.value)}/>
                            </div>
                        </div>}
                        <div className="form-section">
                            <div className="formInput">
                                <input type="submit" value={"Submit"} onClick={(e)=> handleSave(e)} />
                            </div>                 
                        </div>
                    </div>
                    <Footer></Footer>
                </div>
            </main>
        </div>
    );
}
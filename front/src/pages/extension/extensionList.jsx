import { useEffect, useState } from "react"
import '../../styles/extensionList.scss';
import Header from "../../components/header"
import Table from "../../components/Table/table"
import { getExtensions } from "../../api/extension_service"
import { useNavigate } from "react-router"
import jwt_decode from "jwt-decode";
import Footer from "../../components/footer"
import BackButton from "../../components/BackButton";
import Spinner from "../../components/spinner";
import ErrorPage from "../../components/error/Error";


export default function ExtensionList() {
    const navigate = useNavigate()
    const [name,] = useState(localStorage.getItem('name'))
    const [role, setRole] = useState(localStorage.getItem('role'))
    const [isLoading, setIsLoading] = useState(true)
    const [error, setError] = useState(false)
    const [extensions, setextensions] = useState([])

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
        getExtensions()
            .then(result => {
                let mapped = []
                if (result !== null && result !== undefined) {
                    mapped = result.map((extension) => {
                        return {
                            Id: extension.Id,
                            Nome: extension.name,
                            Status: extension.status,
                            Student: extension?.student,
                            Project: extension?.project
                        }
                    })
                }
                setextensions(mapped)
                setIsLoading(false)

            })
    }, [setextensions, setIsLoading])


    return (<div className="extensionList">
        <main className="main">
            <div className="body">
                <Header name={name} />
                <div className="extensionBar">
                    <div className="left-bar">
                        <div>
                            <img className="filtered" src="lamp.png" alt="A logo representing extension" height={"100rem"} />
                        </div>
                        <div className="title">Dissertações</div>
                    </div>
                    <div className="right-bar">
                        <div className="search">
                            <input type="search" name="search" id="search" />
                            <i className="fas fa-" />
                        </div>
                        {/* {role === 'Administrator' && <div className="create-button">
                            <button onClick={() => navigate('/extensions/add')}>Nova Extensão</button>
                        </div>} */}
                    </div>
                </div>
                <BackButton />
                {!isLoading && <Table data={extensions} useOptions={false} />}
                {isLoading && <Spinner />}
                {error && < ErrorPage/>}
                <Footer></Footer>
            </div>
        </main>
    </div>)
}
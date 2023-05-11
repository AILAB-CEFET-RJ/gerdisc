/* eslint-disable jsx-a11y/alt-text */
import React, { useEffect, useState } from 'react';
import '../styles/home.scss';
import Header from '../components/header';
import Footer from '../components/footer';
import jwt_decode from "jwt-decode";
import { useNavigate } from 'react-router-dom'

export default function Home() {
    const navigate = useNavigate()
    var [role, setRole] = useState("")
    var [name, setName] = useState("")
    useEffect(() => {
    
        let token = localStorage.getItem('token')
        setName(localStorage.getItem('name'))
        try {
            const decoded = jwt_decode(token)
            setRole(decoded.role)
        } catch (error) {
            navigate('/login')
        }
    },[navigate, setRole, setName]);

    return (
        <div className='home'>
            <main className={"main"}>
                <div className={"body"}>
                    <Header name={name} />
                    <div>
                        <pre id='pre' style={{ margin: "1rem" }}>Acesse os paneis para consulta e cadastro:</pre>
                    </div>
                    <div className={"dashboard"}>
                        {(role === "Professor" || role === "Administrator") && <div className={"boardItem"} onClick={()=> navigate('/students')}>
                            <div id='student' className={"itemIcon"} >
                                <img src="student.png" />
                            </div>
                            <label htmlFor='student' className={"iconLabel"}>Students</label>
                        </div>}
                        {(role === "Student") && <div className={"boardItem"} onClick={()=> navigate('/student/perfil')}>
                            <div id='Profile' className={"itemIcon"} >
                                <img src="student.png" />
                            </div>
                            <label htmlFor='Profile' className={"iconLabel"}>Meu Perfil</label>
                        </div>}
                        {(role === "Student") && <div className={"boardItem"} onClick={()=> navigate('/extensions')}>
                            <div id='extensions' className={"itemIcon"} >
                                <img className={"filtered"} src="calender.png" />
                            </div>
                            <label htmlFor='extensions' className={"iconLabel"}>Pedidos de Extensão</label>
                        </div>}
                        {(role === "Administrator") && <div className={"boardItem"} onClick={()=> navigate('/professors')}>
                            <div id='professor' className={"itemIcon"} >
                                <img src="professor.png" />
                            </div>
                            <label htmlFor='professor' className={"iconLabel"}>Professors</label>
                        </div>}
                        {(role === "Administrator" || role === "Professor") && <div className={"boardItem"} onClick={()=> navigate('/researches')}>
                            <div id='research' className={"itemIcon"} >
                                <img src="research.png" />
                            </div>
                            <label htmlFor='research' className={"iconLabel"}>Research</label>
                        </div>}
                        {(role === "Administrator" || role === "Professor") && <div className={"boardItem"} onClick={()=> navigate('/projects')}>
                            <div id='project' className={"itemIcon"} >
                                <img className={"filtered"} src="lamp.png" />
                            </div>
                            <label htmlFor='project' className={"iconLabel"}>Project</label>
                        </div>}
                        {(role === "Administrator") && <div className={"boardItem"} onClick={()=> navigate('/reports')}>
                            <div id='report' className={"itemIcon"} >
                                <img className={"filtered"} src="report.png" />
                            </div>
                            <label htmlFor='report' className={"iconLabel"}>Report</label>
                        </div>}
                    </div>
                    <Footer></Footer>
                </div>
            </main>
        </div>
    );
}
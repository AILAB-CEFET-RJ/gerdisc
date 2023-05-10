import React from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/home";
import Login from "./pages/login";
import StudentProfile from "./pages/student/profile";
import UserForm from './pages/user/createUser';
import StudentList from './pages/student/StudentList';
import ProfessorList from './pages/professor/professorList';
import ResearcherList from './pages/researcher/researcherList';
import ProjectList from './pages/projects/projectList';

export default function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/student/:id" element={<StudentProfile />} />
        <Route path="/students" element={<StudentList />} />
        <Route path="/professors" element={<ProfessorList />} />
        <Route path="/researchers" element={<ResearcherList />} />
        <Route path="/projects" element={<ProjectList />} />
        <Route path="/user/add" element={<UserForm />} />
        <Route path="/students/add" element={<UserForm  type={"Estudante"}/>} />
        <Route path="/professors/add" element={<UserForm type={"Professor"}/>} />
        <Route path="/researchers/add" element={<UserForm type={"Externo"}/>} />
      </Routes>
    </Router>
  );
}
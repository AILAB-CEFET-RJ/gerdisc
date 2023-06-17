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
import ProjectForm from './pages/projects/createProject';
import ExtensionList from './pages/extension/extensionList';
import ResearchForm from './pages/research/createResearch';
import ResearchList from './pages/research/researchList';
import ExtensionForm from './pages/extension/createExtension';
import CsvLoader from './pages/CsvLoader';

export default function App() {
  return (
    <Router basename="/gerdisc">
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/students/:id" element={<StudentProfile />} />
        <Route path="/students/:id/edit" element={<UserForm isUpdate={true} type={"Estudante"} />} />
        <Route path="/students" element={<StudentList />} />
        <Route path="/professors" element={<ProfessorList />} />
        <Route path="/researchers" element={<ResearcherList />} />
        <Route path="/researches" element={<ResearchList />} />
        <Route path="/extensions" element={<ExtensionList />} />
        <Route path="/projects" element={<ProjectList />} />
        <Route path="/user/add" element={<UserForm />} />
        <Route path="/entities/csv" element={<CsvLoader />} />
        <Route path="/students/:id/researches/add" element={<ResearchForm />} />
        <Route path="/students/add" element={<UserForm type={"Estudante"}/>} />
        <Route path="/professors/add" element={<UserForm type={"Professor"}/>} />
        <Route path="/professors/:id" element={<UserForm type={"Professor"} isUpdate={true}/>} />
        <Route path="/researchers/:id" element={<UserForm type={"Externo"} isUpdate={true}/>} />
        <Route path="/projects/add" element={<ProjectForm />} />
        <Route path="/projects/:id" element={<ProjectForm isUpdate={true} />} />
        <Route path="/students/:id/extensions/add" element={<ExtensionForm />} />
      </Routes>
    </Router>
  );
}

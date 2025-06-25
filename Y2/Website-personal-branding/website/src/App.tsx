import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Home from "./components/Home.tsx";
import Desktop from "./components/Desktop.tsx";
import AboutMe from "./components/AboutMe.tsx"
import Skills from "./components/Skills.tsx";
import Education from "./components/Education.tsx";
import Projects from "./components/Projects.tsx";
import Links from "./components/Links.tsx";
import Contact from "./components/Contact.tsx"

export default function App() {
    return (
        <Router basename="/portfolio-website">
            <Routes>
                <Route path="/" element={<Home/>}/>
                <Route path="/desktop" element={<Desktop/>}/>
                <Route path="/about-me" element={<AboutMe/>}/>
                <Route path="/education" element={<Education/>}/>
                <Route path="/skills" element={<Skills/>}/>
                <Route path="/projects" element={<Projects/>}/>
                <Route path="/links" element={<Links/>}/>
                <Route path="/contact" element={<Contact/>}/>
            </Routes>
        </Router>
    );
}

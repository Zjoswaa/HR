import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Desktop from "./components/Desktop.tsx";
import AboutMe from "./components/AboutMe.tsx"
import Links from "./components/Links.tsx";
import Contact from "./components/Contact.tsx"
import Projects from "./components/Projects.tsx";
import Home from "./components/Home.tsx";

export default function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home/>}/>
                <Route path="/desktop" element={<Desktop/>}/>
                <Route path="/about-me" element={<AboutMe/>}/>
                <Route path="/links" element={<Links/>}/>
                <Route path="/contact" element={<Contact/>}/>
                <Route path="/projects" element={<Projects/>}/>
            </Routes>
        </Router>
    );
}

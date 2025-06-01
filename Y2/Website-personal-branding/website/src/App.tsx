import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Desktop from "./components/Desktop.tsx";
import ReadMe from "./components/ReadMe.tsx";
import AboutMe from "./components/AboutMe.tsx"
import Links from "./components/Links.tsx";
import Contact from "./components/Contact.tsx"
// Projects

export default function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Desktop/>}/>
                <Route path="/readme" element={<ReadMe/>}/>
                <Route path="/about-me" element={<AboutMe/>}/>
                <Route path="/links" element={<Links/>}/>
                <Route path="/contact" element={<Contact/>}/>
                <Route path="/projects" element={<Desktop/>}/>
            </Routes>
        </Router>
    );
}

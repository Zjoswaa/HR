import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Desktop from "./components/Desktop.tsx";

export default function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Desktop/>}/>
                <Route path="/readme" element={<Desktop/>}/>
                <Route path="/about" element={<Desktop/>}/>
                <Route path="/links" element={<Desktop/>}/>
                <Route path="/projects" element={<Desktop/>}/>
            </Routes>
        </Router>
    );
}

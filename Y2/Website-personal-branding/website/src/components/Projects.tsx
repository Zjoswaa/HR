import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Projects.module.css"

export default function Projects() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Projects.md" onCloseClick={() => handleDirectoryClick("/")}>
                <h1>Projects</h1>
                <hr/>
                <h2>HR</h2>
                <h3>Description</h3>
                <p>This is not really a single project, but this repository contains all class assignments I have made at the Rotterdam University of Applied Sciences.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/HR">https://github.com/Zjoswaa/HR</a>
                <hr/>
                <h2>Project-B</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# terminal-based application that simulates a restaurant management application. The restaurants are a bit different than usual though, you first need to complete an escape room to enter the restaurant.</p>
                <p>Users can register and login to this application to view the menu, view the locations and view and manage their own reservations.</p>
                <p>Admins can also login to this application to view and manage the menu, locations and all reservations</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-B">https://github.com/Zjoswaa/Project-B</a>
                <hr/>
                <h2>Project-D</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a Python backend en React frontend for a RAG-based LLM chatbot for the NDW Docs, NDW is a Dutch government instantiation that provides information about the Dutch infrastructure.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-D">https://github.com/Zjoswaa/Project-D</a>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

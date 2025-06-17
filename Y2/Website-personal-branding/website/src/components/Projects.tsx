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
            <MarkdownWindow title="Projects.md" onCloseClick={() => handleDirectoryClick("/")}>z
                <h1>Projects</h1>
                <hr/>
                <h2>HR</h2>
                <h3>Description</h3>
                <p>This is not really a single project, but this repository contains all class assignments I have made at the Rotterdam University of Applied Sciences.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/HR" target={"_blank"}>https://github.com/Zjoswaa/HR</a>
                <hr/>
                <h2>Project-Alpha</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# terminal-based adventure game with a class system and inventory system.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-Alpha" target={"_blank"}>https://github.com/Zjoswaa/Project-Alpha</a>
                <hr/>
                <h2>Project-B</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# terminal-based application that simulates a restaurant management application. The restaurants are a bit different than usual though, you first need to complete an escape room to enter the restaurant.</p>
                <p>Users can register and login to this application to view the menu, view the locations and view and manage their own reservations.</p>
                <p>Admins can also login to this application to view and manage the menu, locations and all reservations</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-B" target={"_blank"}>https://github.com/Zjoswaa/Project-B</a>
                <hr/>
                <h2>Project-D</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a Python backend en React frontend for a RAG-based LLM chatbot for the NDW Docs, NDW is a Dutch government instantiation that provides information about the Dutch infrastructure.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-D" target={"_blank"}>https://github.com/Zjoswaa/Project-D</a>
                <hr/>
                <h2>Urban Mobility Backend System</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a Python console-based secure database management system for a scooter service, admins and service engineers can login and manage the data they are allowed to edit.</p>
                <p>Everything is encrypted or hashed in the database, a logging system keeps track of suspicious activities and admins can make and revert to backups.</p>
                <h3>Link</h3>
                <a href="https://github.com/333suki/UrbanMobility_BackendSystem" target={"_blank"}>https://github.com/333suki/UrbanMobility_BackendSystem</a>
                <hr/>
                <h2>DNS Client & Server</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# console application that consist of a server and client who communicate through sockets using the UDP protocol.</p>
                <p></p>
                <h3>Link</h3>
                <a href="https://github.com/333suki/DNS_ClientServer" target={"_blank"}>https://github.com/333suki/DNS_ClientServer</a>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Projects.module.css"

import ChadBotClearImage from "../assets/chadbot-clear-dark.png"
import ChadBotQueryImage from "../assets/chadbot-query-dark.png"

export default function Projects() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Projects.md" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Projects</h1>
                <hr/>

                <h2>HR</h2>
                <h3>Description</h3>
                <p>This is not a single project, but this repository contains all class assignments I have made at the Rotterdam University of Applied Sciences.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/HR" target={"_blank"}>https://github.com/Zjoswaa/HR</a>
                <hr/>

                <h2>Project-D</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a Python backend and React frontend for a RAG-based LLM chatbot called ChadBot for the <a id={styles.ndwLink} href="https://docs.ndw.nu/en/" target={"_blank"}>NDW Docs</a>.</p>
                <p>NDW is a Dutch government instantiation that provides information about the Dutch infrastructure.</p>
                <h3>Showcase</h3>
                <img className={styles.showcaseImage} id={styles.chadbotClear} src={ChadBotClearImage} alt="An image of the ChadBot frontend"/>
                <img className={styles.showcaseImage} id={styles.chadbotQuery} src={ChadBotQueryImage} alt="An image of the ChadBot frontend, including a query and response."/>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-D" target={"_blank"}>https://github.com/Zjoswaa/Project-D</a>
                <hr/>

                <h2>Portfolio Website</h2>
                <h3>Description</h3>
                <p>This is the website you are currently looking at.</p>
                <p>I started making this website for an elective course I followed at the Rotterdam University of Applied Sciences.</p>
                <hr/>

                <h2>Urban Mobility Backend System</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a Python console-based secure database management system for a urban mobility service managing scooters and travelers, admins and service engineers can login and manage the data they are allowed to edit.</p>
                <p>Everything is encrypted or hashed in the database, a logging system keeps track of any activity and marks suspicious activity as such. Admins can make and revert to system backups.</p>
                <h3>Link</h3>
                <a href="https://github.com/333suki/UrbanMobility_BackendSystem" target={"_blank"}>https://github.com/333suki/UrbanMobility_BackendSystem</a>
                <hr/>

                <h2>DNS Client & Server</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my second year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# console application that consist of a server and client who communicate through sockets using the UDP protocol.</p>
                <p>The program simulates a DNS lookup system and tries to simulate a TCP protocol through Hello, Acknowledge, End packets.</p>
                <p>The client can send a DNSLookop packet to the server, this packet contains the full URL and the record type that the client would like to know the IP of.</p>
                <p>The server retrieves this packet and searches its data storage for a match, it it is found, it returns a DNSLookupReply with the record type, URL, IP, TTL and Priority.</p>
                <h3>Link</h3>
                <a href="https://github.com/333suki/DNS_ClientServer" target={"_blank"}>https://github.com/333suki/DNS_ClientServer</a>
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

                <h2>Project-Alpha</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>It is a C# terminal-based dungeons and dragons-inspired game with a class system and inventory system.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/Project-Alpha" target={"_blank"}>https://github.com/Zjoswaa/Project-Alpha</a>
                <hr/>

                <h2>TUBOGA</h2>
                <h3>Description</h3>
                <p>This is a group project I worked on during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>TUBOGA - The Ultimate Board Game is a simple two-player board game made using the Pygame Python library.</p>
                <p>It is a dice-based, Monopoly-inspired game where the goal is to assemble and sell a computer, during the game you can earn money to buy computer parts, assemble these parts into computers and sell them for a profit.</p>
                <p>You can also choose to trade with your opponent when you are both on the same tile.</p>
                <p>On certain tiles, you can play a minigame to earn extra coins.</p>
                <p>The goal is to get to 5000 coins before your opponent does.</p>
                <h3>Link</h3>
                <a href="https://github.com/Zjoswaa/TUBOGA" target={"_blank"}>https://github.com/Zjoswaa/TUBOGA</a>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

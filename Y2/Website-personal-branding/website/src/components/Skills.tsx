import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Skills.module.css"

export default function Skills() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Skills.md" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Skills</h1>
                <hr/>

                <h2>Technical Skills</h2>
                <h3>Project Design</h3>
                <p>During my time at school, I have worked on many projects.</p>
                <p>When we started working on a new project, it was important that we first thoroughly considered a design for the project before working on it.</p>
                <p>I have worked on designing UML Models like Use Case Diagrams, Class Diagrams, Sequence Diagrams and Activity Diagrams for the projects.</p>
                <hr/>
                <p>I have experience with multiple programming languages, the ones I have worked the most are mentioned here</p>

                <h3>C++</h3>
                <p>When I first started programming around 2014, the language I started with was C++.</p>
                <p>I made some basic programs back then and over the years I have made more complex projects.</p>
                <p>Examples include a terminal-based sudoku solver, a GUI-application for John Conway's Game of Life and a basic game engine.</p>
                <p>Some of these projects can be found on my GitHub.</p>
                <p>During my time at Leiden University, the main taught programming language was also C++.</p>
                <hr/>

                <h3>Java</h3>
                <p>A little after I first started programming, I also started working with Java, I mostly made some simple Minecraft mods back then.</p>
                <p>Later I also started making some GUI applications using the Java Swing toolkit and JavaFX.</p>
                <p>Currently, I mostly use the Java Spring Boot library to make backends for web-based remakes of projects I have made at school.</p>
                <hr/>

                <h3>C#</h3>
                <p>I started programming in this language during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>During this period I have made many assignments using C#, handling JSON data, using databases and using sockets.</p>
                <p>I also worked on multiple projects using C# during this year, these can be found on the Projects page.</p>
                <hr/>

                <h3>Python</h3>
                <p>I had some basic experience with Python before but I first really started programming in this language during my first year at the Rotterdam University of Applied Sciences.</p>
                <p>I made many assignments using Python, learning skills like database management, numpy, pandas dataframes and data visualisation.</p>
                <p>I have worked on multiple projects during my first and second year using Python, these can be found on the Projects page.</p>
                <hr/>

                <h2>Professional Skills</h2>
                <h3>Scrum</h3>
                <p>During my time at Rotterdam University of Applied Sciences, I have worked with the Scrum methodology on some of the projects I worked on.</p>
                <p>I applied skills like setting up a project backlog, working in sprints of 2 weeks with a retrospective discussion after every sprint.</p>
                <p>I also learned how to communicate with a Product Owner through a monthly meeting I had with a Product Owner during some of my projects, applying skills like taking meeting minutes (notes) and adapting to shifting wishes of the Product Owner.</p>
                <hr/>

                <h3>Leadership</h3>
                <p>When working with Scrum, I have taken on the role as a Scrum Master multiple times, organizing meetings with my team and managing potential issues in my team.</p>
                <p>I have gotten positive reviews from my teammates who appreciated my clarity and directionality while still being friendly and engaged.</p>
                <p>Though Scrum Master is not my favorite position, I still learned a lot from this and it has also made me a better team member, being able to see through the eyes of the Scrum Master.</p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Home.module.css"

export default function Home() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Home" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Home</h1>
                <hr/>

                <h2>Welcome</h2>
                <p><strong>Welcome!</strong></p>
                <p>My name is <strong>Joshua van der Jagt</strong>, I am a computer science student with a passion for creating robust, well-working and good-looking projects.</p>
                <p>On this website you can find projects I have made and worked on, any relevant information about me, and ways to contact me.</p>
                <div className={styles.quickButtons}>
                    <button id={styles.viewProjects} onClick={() => handleDirectoryClick("/projects")}>View my Projects</button>
                    <button id={styles.contactMe} onClick={() => handleDirectoryClick("/contact")}>Contact Me</button>
                </div>
                <hr/>

                <h2>Navigation</h2>
                <p>This website works a bit like a <strong>computer desktop</strong>, you can close any window by clicking on the <strong>red cross</strong> in the top right, this will close the window and navigate you to the <strong>desktop</strong>.</p>
                <p>On the desktop you can click on any of the files, for example <span>About-Me.md</span> to open the file in a window like this and read its contents.</p>
                <p>You can also click on any file in the <strong>navigation</strong> on the left side of the window to open that file.</p>
                <hr/>

                <h3>About Me</h3>
                <p>The about me page contains some more personal information about me.</p>
                <hr/>

                <h3>Education</h3>
                <p>On the education page you can find my education history.</p>
                <hr/>

                <h3>Skills</h3>
                <p>On the skills page you can find information about my technical and professional skills.</p>
                <hr/>

                <h3>Projects</h3>
                <p>On the projects page you can find my highlighted projects that I have worked on or made myself.</p>
                <hr/>

                <h3>Links</h3>
                <p>Here you can find all my links to my profiles on external websites.</p>
                <hr/>

                <h3>Contact</h3>
                <p>Here you can find ways to contact me if you are interested in working with me, or just want to ask me a question.</p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

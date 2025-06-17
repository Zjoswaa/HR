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
                <p>Welcome to my digital portfolio. This window provides information about navigating the site and its features.</p>
                <p>This website was made as part of an elective course I followed at the Rotterdam University of Applied Sciences.</p>
                <hr/>
                <h2>Navigation</h2>
                <p>This website works a bit like a computer desktop, you can close any window by clicking on the red cross in the top right, this will close the window and navigate you to the desktop.</p>
                <p>On the desktop you can click on any of the files, for example <span>About-Me.md</span> to open the file in a window like this and read its contents.</p>
                <p>You can also click on any file in the navigation on the left of the window to open that file.</p>
                <h3>About Me</h3>
                <p>The about me page contains some personal information about me.</p>
                <h3>Projects</h3>
                <p>On the projects page you can find my highlighted projects that I have worked on or made myself.</p>
                <h3>Links</h3>
                <p>Here you can find all my links to my profiles on external websites.</p>
                <h3>Contact</h3>
                <p>Here you can find ways to contact me if you are interested in working with me.</p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

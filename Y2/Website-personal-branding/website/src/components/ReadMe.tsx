import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./ReadMe.module.css"

export default function ReadMe() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="README.md" onCloseClick={() => handleDirectoryClick("/")}>
                <h1>Portfolio Website</h1>
                <hr/>
                <p>Welcome to my digital portfolio. This window provides information about navigating the site and its features.</p>
                <p>This website was made as part of an elective course I followed at the Rotterdam University of Applied Sciences.</p>
                <hr/>
                <h1>Navigation</h1>
                <p>This website works a bit like a computer desktop, you can click on the files on the desktop to open the files and read their content. What you are reading now is one of those files called <span>README.md</span>.</p>
                <p>Clicking on the folders on the desktop will open that directory in an explorer, from which you can click on a multiple folders/files to open them.</p>
                <p>You can close any window by clicking on the red cross in the top right, this will navigate you one directory back if you opened it from an explorer window.</p>
                <p>You can also click the home button in the top left to instantly go back to the home desktop.</p>
            </MarkdownWindow>
        </div>
    )
}

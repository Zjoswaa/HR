import { useNavigate } from "react-router-dom";

import DesktopIcon from "./DesktopIcon.tsx";

import styles from "./Home.module.css"

export default function Desktop() {
    const navigate = useNavigate();

    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.directoryIconContainer}>
                <DesktopIcon title="Home" iconPath="/home.svg" onClick={() => handleDirectoryClick("/")}/>
                <DesktopIcon title="README.md" iconPath="/document-markdown.svg" onClick={() => handleDirectoryClick("/readme")}/>
                <DesktopIcon title="About Me.md" iconPath="/document-markdown.svg" onClick={() => handleDirectoryClick("/about-me")}/>
                <DesktopIcon title="Links.md" iconPath="/document-markdown.svg" onClick={() => handleDirectoryClick("/links")}/>
                <DesktopIcon title="Projects" iconPath="/directory-code.svg" onClick={() => handleDirectoryClick("/projects")}/>
            </div>
        </div>
    );
}

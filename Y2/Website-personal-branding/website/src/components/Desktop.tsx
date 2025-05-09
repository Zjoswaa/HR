import { useNavigate } from "react-router-dom";
import DesktopIcon from "./DesktopIcon.tsx";
import styles from "./Desktop.module.css"

export default function Desktop() {
    const navigate = useNavigate();

    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.directoryIconContainer}>
                <DesktopIcon title="Home" iconPath="/home.svg" onClick={() => handleDirectoryClick("/")}/>
                <DesktopIcon title="Readme.md" iconPath="/markdown-document.svg" onClick={() => handleDirectoryClick("/readme")}/>
                <DesktopIcon title="About.md" iconPath="/markdown-document.svg" onClick={() => handleDirectoryClick("/about")}/>
                <DesktopIcon title="Links.md" iconPath="markdown-document.svg" onClick={() => handleDirectoryClick("/links")}/>
                <DesktopIcon title="Projects" iconPath="/directory.svg" onClick={() => handleDirectoryClick("/projects")}/>
            </div>
        </div>
    );
}

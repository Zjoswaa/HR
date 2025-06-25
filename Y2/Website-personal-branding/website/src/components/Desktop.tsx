import { useNavigate } from "react-router-dom";

import DesktopIcon from "./DesktopIcon.tsx";

import styles from "./Desktop.module.css"

import HomeIcon from "../assets/home.svg"
import MarkDownIcon from "../assets/document-markdown.svg"

export default function Desktop() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.directoryIconContainer}>
                <DesktopIcon title="Home" iconPath={HomeIcon} onClick={() => handleDirectoryClick("/")}/>
                <DesktopIcon title="About-Me.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/about-me")}/>
                <DesktopIcon title="Education.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/education")}/>
                <DesktopIcon title="Skills.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/skills")}/>
                <DesktopIcon title="Projects.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/projects")}/>
                <DesktopIcon title="Links.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/links")}/>
                <DesktopIcon title="Contact.md" iconPath={MarkDownIcon} onClick={() => handleDirectoryClick("/contact")}/>
            </div>
        </div>
    );
}

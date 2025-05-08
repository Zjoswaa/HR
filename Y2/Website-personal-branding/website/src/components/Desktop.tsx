import { useNavigate } from "react-router-dom";
import DirectoryIcon from "./DirectoryIcon.tsx";
import styles from "./Desktop.module.css"

export default function Desktop() {
    const navigate = useNavigate();

    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.directoryIconContainer}>
                <DirectoryIcon title="Trash" iconPath="/trash-bin.svg" onClick={() => handleDirectoryClick("/")}/>
                <DirectoryIcon title="Home" iconPath="/home-directory.svg" onClick={() => handleDirectoryClick("/")}/>
                <DirectoryIcon title="About Me" iconPath="/about-directory.svg" onClick={() => handleDirectoryClick("/about-me")}/>
                <DirectoryIcon title="Projects" iconPath="/development-directory.svg" onClick={() => handleDirectoryClick("/projects")}/>
                <DirectoryIcon title="Links" iconPath="/links-directory.svg" onClick={() => handleDirectoryClick("/links")}/>
            </div>
        </div>
    );
}

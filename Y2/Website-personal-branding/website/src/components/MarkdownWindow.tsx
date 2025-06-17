import React from "react";
import {useNavigate} from "react-router-dom";

import styles from "./MarkdownWindow.module.css"

interface props {
    title: string;
    onCloseClick: (e: React.MouseEvent) => void;
    children: React.ReactNode;
}

export default function MarkdownWindow({ title, onCloseClick, children}: props) {
    const navigate = useNavigate();

    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.navigationBar}>
                {/*<img className={styles.leftItem} src="/home.svg" alt="Desktop" onClick={() => handleDirectoryClick("/desktop")}/>*/}
                <div className={styles.centerItem}>{title}</div>
                <img className={styles.rightItem} src="/cross.svg" alt="Close" onClick={onCloseClick}/>
            </div>
            <div className={styles.windowContent}>
                <div className={styles.filesNavigationBar}>
                    <div className={`${styles.fileNavigator} ${title === "Home" ? styles.current : ""}`} onClick={() => handleDirectoryClick("/")}>
                        <img className={styles.fileNavigatorIcon} id={styles.homeIcon} src="/home.svg" alt="Home Icon"/>
                        <div className={styles.fileNavigatorText}>
                            Home
                        </div>
                    </div>
                    <div className={`${styles.fileNavigator} ${title === "About-Me.md" ? styles.current : ""}`} onClick={() => handleDirectoryClick("/about-me")}>
                        <img className={styles.fileNavigatorIcon} src="/document-markdown.svg" alt="Markdown Document Icon"/>
                        <div className={styles.fileNavigatorText}>
                            About-Me.md
                        </div>
                    </div>
                    <div className={`${styles.fileNavigator} ${title === "Projects.md" ? styles.current : ""}`} onClick={() => handleDirectoryClick("/projects")}>
                        <img className={styles.fileNavigatorIcon} src="/document-markdown.svg" alt="Markdown Document Icon"/>
                        <div className={styles.fileNavigatorText}>
                            Projects.md
                        </div>
                    </div>
                    <div className={`${styles.fileNavigator} ${title === "Links.md" ? styles.current : ""}`} onClick={() => handleDirectoryClick("/links")}>
                        <img className={styles.fileNavigatorIcon} src="/document-markdown.svg" alt="Markdown Document Icon"/>
                        <div className={styles.fileNavigatorText}>
                            Links.md
                        </div>
                    </div>
                    <div className={`${styles.fileNavigator} ${title === "Contact.md" ? styles.current : ""}`} onClick={() => handleDirectoryClick("/contact")}>
                        <img className={styles.fileNavigatorIcon} src="/document-markdown.svg" alt="Markdown Document Icon"/>
                        <div className={styles.fileNavigatorText}>
                            Contact.md
                        </div>
                    </div>
                </div>
                <div className={styles.childrenContainer}>
                    {children}
                </div>
            </div>
        </div>
    )
}

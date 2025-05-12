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
                <img className={styles.leftItem} src="/home.svg" alt="Desktop" onClick={() => handleDirectoryClick("/")}/>
                <div className={styles.centerItem}>{title}</div>
                <img className={styles.rightItem} src="/cross.svg" alt="Close" onClick={onCloseClick}/>
            </div>
            <div className={styles.windowContent}>
                {children}
            </div>
        </div>
    )
}

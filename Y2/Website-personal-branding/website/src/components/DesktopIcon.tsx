import React from "react";
import styles from "./DesktopIcon.module.css"

interface props {
    title: string;
    iconPath: string
    onClick: (e: React.MouseEvent) => void;
}

export default function DesktopIcon({title, iconPath, onClick}: props) {
    return (
        <div className={styles.container} onClick={onClick}>
            <img className={styles.icon} src={iconPath} alt="Desktop Icon"/>
            <p className={styles.title}>{title}</p>
        </div>
    );
}

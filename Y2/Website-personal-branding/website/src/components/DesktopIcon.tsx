import React from "react";
import styles from "./DesktopIcon.module.css"

interface props {
    title: string;
    iconPath: string
    onClick: (e: React.MouseEvent) => void;
}

export default function DesktopIcon(props: props) {
    return (
        <div className={styles.container} onClick={props.onClick}>
            <img className={styles.icon} src={props.iconPath} alt="Directory"/>
            <p className={styles.title}>{props.title}</p>
        </div>
    );
}

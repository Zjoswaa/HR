import styles from "./DirectoryIcon.module.css"

interface props {
    title: string;
    iconPath: string
    onClick: () => void;
}

export default function DirectoryIcon(props: props) {
    return (
        <div className={styles.container}>
            <img className={styles.icon} src={props.iconPath} alt="Directory" onClick={props.onClick}/>
            <p className={styles.title}>{props.title}</p>
        </div>
    );
}

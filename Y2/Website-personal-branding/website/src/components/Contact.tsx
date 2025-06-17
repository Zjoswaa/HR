import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Contact.module.css"

export default function Links() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Contact.md" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Contact</h1>
                <hr/>
                <p>You can contact me in multiple ways, my most used contact points are the following:</p>
                <br/>
                <h2>Discord</h2>
                <p>Username: <span>zjoswaa</span></p>
                <hr/>
                <h2>E-Mail</h2>
                <p>Gmail: <span>joshuavdjagt@gmail.com</span></p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

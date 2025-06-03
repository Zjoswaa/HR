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
            <MarkdownWindow title="Contact.md" onCloseClick={() => handleDirectoryClick("/")}>
                <h1>Contact</h1>
                <hr/>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias, amet aut commodi consequatur, culpa delectus dolorem, doloribus dolorum fugit inventore maiores numquam quod quos rem saepe. Dicta earum repellendus unde?</p>
                </MarkdownWindow>
        </div>
    )
}

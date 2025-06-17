import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Links.module.css"

export default function Links() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Links.md" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Links</h1>
                <hr/>
                <h2>GitHub</h2>
                <p>On my GitHub you can find my personal project and some of the projects I have worked on at school.</p>
                <a href="https://github.com/Zjoswaa" target={"_blank"}>https://github.com/Zjoswaa</a>
                <hr/>
                <h2>LinkedIn</h2>
                <p>On my LinkedIn you can find my educational- and working history. You can also find some additional information about me like my skills, languages, recommendations I have received, etc.</p>
                <a href="https://www.linkedin.com/in/joshua-van-der-jagt" target={"_blank"}>https://www.linkedin.com/in/joshua-van-der-jagt</a>
                <hr/>
                <h2>Instagram</h2>
                <p>Here you can find my personal posts.</p>
                <a href="https://www.instagram.com/zjoswaa" target={"_blank"}>https://www.instagram.com/zjoswaa</a>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

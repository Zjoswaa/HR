import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./Education.module.css"

export default function Education() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="Education.md" onCloseClick={() => handleDirectoryClick("/desktop")}>
                <h1>Education</h1>
                <hr/>

                <h2>Rotterdam University of Applied Sciences</h2>
                <p><strong>Bachelor Computer Science</strong></p>
                <p><strong>Feb 2024 - Feb 2028</strong></p>
                <br/>
                <p>Here I continued my studies in computer science, learning more professional skills and expanding my skillset by learning more about the practical concepts of computer science.</p>
                <p>Many of the projects found on this website were made during my time here.</p>
                <hr/>

                <h2>Leiden University</h2>
                <p><strong>BSc Computer Science</strong></p>
                <p><strong>Sep 2021 - Nov 2023</strong></p>
                <br/>
                <p>After getting my high school degree, I studied at the Leiden University.</p>
                <p>I followed courses like: Calculus, Linear Algebra, Algorithms & Datastructures, Statistics for Computer Scientists, Computability, Complexity, Databases, Logic, Foundations of Computer Science, Fundamentals of Digital Systems Design and Security.</p>
                <p>I unfortunately did not finish this degree because of personal reasons, but I did learn a lot about the more technical concepts of computer science during my time here.</p>
                <hr/>

                <h2>Gymnasium Erasmianum Rotterdam</h2>
                <p><strong>High school</strong></p>
                <p><strong>Sep 2014 - Jul 2021</strong></p>
                <br/>
                <p>During the 7 years I studied here I earned my VWO (pre-university education) degree for the courses: Latin, English, French, physics, math B, chemistry, biology and history.</p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

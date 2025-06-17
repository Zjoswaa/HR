import {useNavigate} from "react-router-dom";

import MarkdownWindow from "./MarkdownWindow.tsx";

import styles from "./AboutMe.module.css"

const calculateYearsSince = (date: string) => {
    const now = new Date();
    const pastDate = new Date(date);
    let years = now.getFullYear() - pastDate.getFullYear();

    // Adjust for whether the specific date has occurred yet this year
    const hasPassedThisYear =
        now.getMonth() > pastDate.getMonth() ||
        (now.getMonth() === pastDate.getMonth() && now.getDate() >= pastDate.getDate());

    if (!hasPassedThisYear) {
        years -= 1;
    }

    return years;
};

export default function AboutMe() {
    const navigate = useNavigate();
    const handleDirectoryClick = (path: string) => {
        navigate(path);
    };

    return (
        <div className={styles.mainContainer}>
            <MarkdownWindow title="About Me.md" onCloseClick={() => handleDirectoryClick("/")}>
                <h1>About Me</h1>
                <hr/>
                <p>Hi, my name is Joshua van der Jagt, I am {calculateYearsSince("2002-10-20")} years old.</p>
                <p>I am currently studying computer science at the Rotterdam University of Applied Sciences, where I have completed my first year with a cum laude distinction.</p>
                <p>My hobbies include playing video games, watching movies and series, having fun with my friends and developing my personal projects. These projects can be found on this website.</p>
                <br/>
                <p>Friends and family describe me as calm, patient, helpful and caring, I love helping people when they have any problems. When I have helped someone solve an issue they have, that feels like a great accomplishment for me.</p>
                <p>This is also why I have worked as a tutor for a company called After's Cool for a little over 3 years, this company provides on-location after-school tutoring for high school students in the Netherlands. I am also currently working as a student tutor at my own school, the Rotterdam University of Applied Sciences, where I serve as a point of contact for any problems students in the years below me might have, technical or non-technical problems alike.</p>
                <hr/>
            </MarkdownWindow>
        </div>
    )
}

import Router from "./router/Router";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import { useState, useEffect } from "react";

function App() {
    const [theme, setTheme] = useState("dark");

    useEffect(() => {
        if (
            window.matchMedia &&
            window.matchMedia("(prefers-color-scheme: dark)").matches
        ) {
            setTheme("dark");
        } else {
            setTheme("light");
        }
    }, []);

    return (
        <div className={theme === "dark" ? "App dark-theme" : "App"}>
            <Router theme={theme} setTheme={setTheme} />
        </div>
    );
}

export default App;

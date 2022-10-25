import React, { Component } from "react";
import "./themeBtn.css";

export default class ThemeBtn extends Component {
    handleClick = () => {
        this.props.setTheme(this.props.theme === "dark" ? "light" : "dark");
    };

    render() {
        return (
            <div className="toggleWrapper">
                <input type="checkbox" className="dn" id="dn" />
                <label
                    htmlFor="dn"
                    className="toggle"
                    onClick={this.handleClick}
                >
                    <span className="toggle__handler">
                        <span className="crater crater--1"></span>
                        <span className="crater crater--2"></span>
                        <span className="crater crater--3"></span>
                    </span>
                    <span className="star star--1"></span>
                    <span className="star star--2"></span>
                    <span className="star star--3"></span>
                    <span className="star star--4"></span>
                    <span className="star star--5"></span>
                    <span className="star star--6"></span>
                </label>
            </div>
        );
    }
}

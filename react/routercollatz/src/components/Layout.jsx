import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";
import ThemeBtn from "./ThemeBtn";
import "./layout.css";

export default class Layout extends Component {
    state = {
        links: [],
    };

    createLinks = () => {
        this.state.links.splice(0);
        this.setState({
            links: this.state.links,
        });

        for (let i = 0; i < 10; i++) {
            this.state.links.push(
                <Link
                    key={i}
                    className={
                        this.props.theme === "dark"
                            ? "btn btn-dark"
                            : "btn btn-primary"
                    }
                    role="button"
                    to={`collatz/${i}`}
                >
                    Collatz {i}
                </Link>
            );
        }
    };

    componentDidMount() {
        this.createLinks();
    }

    componentDidUpdate(oldProps) {
        if (oldProps.theme !== this.props.theme) {
            this.createLinks();
        }
    }

    render() {
        return (
            <>
                <div>
                    <nav
                        className="nav btn-group pt-3 mb-1"
                    >
                        {this.state.links}
                    </nav>
                    <div className="centered-theme-btn">
                        <ThemeBtn
                            theme={this.props.theme}
                            setTheme={this.props.setTheme}
                        />
                    </div>
                </div>
                <Outlet />
            </>
        );
    }
}

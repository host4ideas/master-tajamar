import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";
import ThemeBtn from "./ThemeBtn";

export default class Menu extends Component {
    render() {
        return (
            <>
                <div>
                    <nav
                        className={
                            this.props.theme === "dark"
                                ? "navbar navbar-expand-lg bg-light"
                                : "navbar navbar-expand-lg bg-dark text-white"
                        }
                    >
                        <div className="container-fluid">
                            <button
                                className="navbar-toggler"
                                type="button"
                                data-bs-toggle="collapse"
                                data-bs-target="#navbarNav"
                                aria-controls="navbarNav"
                                aria-expanded="false"
                                aria-label="Toggle navigation"
                            >
                                <span className="navbar-toggler-icon"></span>
                            </button>
                            <div
                                className="collapse navbar-collapse"
                                id="navbarNav"
                            >
                                <ul className="navbar-nav">
                                    <li className="nav-item">
                                        <Link
                                            className={
                                                this.props.theme === "dark"
                                                    ? "nav-link"
                                                    : "nav-link text-white"
                                            }
                                            to={`/`}
                                        >
                                            Departamentos
                                        </Link>
                                    </li>
                                    <li className="nav-item">
                                        <Link
                                            className={
                                                this.props.theme === "dark"
                                                    ? "nav-link"
                                                    : "nav-link text-white"
                                            }
                                            to={`createdepartamento`}
                                        >
                                            Crear departamento
                                        </Link>
                                    </li>
                                    <li className="nav-item">
                                        <ThemeBtn
                                            theme={this.props.theme}
                                            setTheme={this.props.setTheme}
                                        />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </nav>
                </div>
                <Outlet />
            </>
        );
    }
}

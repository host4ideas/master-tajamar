import React, { Component } from "react";
import MenuEquipos from "./MenuEquipos";
import { Outlet, Link } from "react-router-dom";
import championsIcon from "../assets/images/champions-icon.png";

export default class Menu extends Component {
    render() {
        return (
            <div>
                <nav className="navbar navbar-expand-lg bg-light">
                    <div className="container-fluid">
                        <Link className="navbar-brand" to="/">
                            <img
                                width={50}
                                src={championsIcon}
                                alt="Champions"
                            />
                        </Link>
                        <button
                            className="navbar-toggler"
                            type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#navbarSupportedContent"
                            aria-controls="navbarSupportedContent"
                            aria-expanded="false"
                            aria-label="Toggle navigation"
                        >
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div
                            className="collapse navbar-collapse"
                            id="navbarSupportedContent"
                        >
                            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                                <li className="nav-item">
                                    <Link className="nav-link" to={"/"}>
                                        Home
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link" to={"/apuestas"}>
                                        Apuestas
                                    </Link>
                                </li>
                                <MenuEquipos equipos={this.props.equipos} />
                            </ul>
                        </div>
                    </div>
                </nav>

                <Outlet />
            </div>
        );
    }
}

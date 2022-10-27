import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class MenuEquipos extends Component {
    render() {
        return (
            <li class="nav-item dropdown">
                <span
                    class="nav-link dropdown-toggle"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                >
                    Equipos
                </span>
                <ul class="dropdown-menu">
                    {this.props.equipos.map((equipo, index) => {
                        return (
                            <li key={index}>
                                <Link
                                    className="dropdown-item"
                                    to={`/detallesEquipo/${index}`}
                                >
                                    {equipo.nombre}
                                </Link>
                            </li>
                        );
                    })}
                </ul>
            </li>
        );
    }
}

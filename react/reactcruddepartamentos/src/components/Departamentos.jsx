import React, { Component } from "react";
import { NavLink } from "react-router-dom";

export default class Departamentos extends Component {
    state = {
        newLocation: null,
    };

    redirectToHome = React.createRef();

    showDetails = (numero, nombre, localidad) => {
        this.setState({
            newLocation: `/details/${numero}/${nombre}/${localidad}`,
        });
        this.redirectToHome.current.click();
    };

    render() {
        if (this.props.loading) {
            return (
                <div>
                    <h1
                        className={
                            this.props.theme !== "dark"
                                ? "text-white"
                                : undefined
                        }
                    >
                        Departamentos
                    </h1>

                    <div className="d-flex justify-content-center">
                        <div className="spinner-border" role="status"></div>
                    </div>
                </div>
            );
        } else {
            return (
                <div>
                    <h1
                        className={
                            this.props.theme !== "dark"
                                ? "text-white"
                                : undefined
                        }
                    >
                        Departamentos
                    </h1>
                    <table
                        className={
                            this.props.theme === "dark"
                                ? "table"
                                : "table table-dark"
                        }
                    >
                        <thead>
                            <tr>
                                <th>Número</th>
                                <th>Nombre</th>
                                <th>Localidad</th>
                                <th>Opciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.props.departamentos.map(
                                (departamento, index) => {
                                    return (
                                        <tr
                                            key={index}
                                            style={{ cursor: "pointer" }}
                                        >
                                            <td
                                                onClick={() => {
                                                    this.showDetails(
                                                        departamento.numero,
                                                        departamento.nombre,
                                                        departamento.localidad
                                                    );
                                                }}
                                            >
                                                {departamento.numero}
                                            </td>
                                            <td
                                                onClick={() => {
                                                    this.showDetails(
                                                        departamento.numero,
                                                        departamento.nombre,
                                                        departamento.localidad
                                                    );
                                                }}
                                            >
                                                {departamento.nombre}
                                            </td>
                                            <td
                                                onClick={() => {
                                                    this.showDetails(
                                                        departamento.numero,
                                                        departamento.nombre,
                                                        departamento.localidad
                                                    );
                                                }}
                                            >
                                                {departamento.localidad}
                                            </td>
                                            <td>
                                                <NavLink
                                                    className={"btn btn-danger"}
                                                    role="button"
                                                    to={`delete/${departamento.numero}`}
                                                >
                                                    🗑️
                                                </NavLink>{" "}
                                                <NavLink
                                                    className={
                                                        "btn btn-warning"
                                                    }
                                                    role="button"
                                                    to={`update/${departamento.numero}/${departamento.nombre}/${departamento.localidad}`}
                                                >
                                                    ✏️
                                                </NavLink>
                                            </td>
                                            <td style={{ display: "none" }}>
                                                <NavLink
                                                    to={this.state.newLocation}
                                                    ref={this.redirectToHome}
                                                >
                                                </NavLink>
                                            </td>
                                        </tr>
                                    );
                                }
                            )}
                        </tbody>
                    </table>
                </div>
            );
        }
    }
}

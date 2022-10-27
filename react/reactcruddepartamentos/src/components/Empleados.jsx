import React, { Component } from "react";
import axios from "axios";
import Global from "../Global";
import { NavLink } from "react-router-dom";

export default class Empleados extends Component {
    state = {
        empleados: [],
        loading: true,
        newLocation: null,
    };

    redirectToHome = React.createRef();

    showDetails = (id, apellido, oficio, salario, departamento) => {
        this.setState({
            newLocation: `/detallesempleado/${id}/${apellido}/${oficio}/${salario}/${departamento}/`,
        });
        this.redirectToHome.current.click();
    };

    getEmpleados = () => {
        this.setState({
            empleados: [],
        });
		
        const request =
            Global.urlEmpleados +
            `api/Empleados/EmpleadosDepartamento/${this.props.departamentoId}`;
        axios
            .get(request)
            .then((response) => {
                this.setState({
                    loading: false,
                    empleados: response.data,
                });
            })
            .catch((error) => {
                console.error(error);
                this.setState({
                    loading: false,
                });
            });
    };

    componentDidMount() {
        this.getEmpleados();
    }

    componentDidUpdate(oldProps) {
        if (oldProps.departamentoId !== this.props.departamentoId) {
            this.getEmpleados();
        }
    }

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
                        Empleados del departamento: {this.props.departamentoId}
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
                        Empleados del departamento: {this.props.departamentoId}
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
                                <th>ID</th>
                                <th>Apellido</th>
                                <th>Oficio</th>
                                <th>Salario</th>
                                <th>Departamento</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.empleados.map((empleado, index) => {
                                return (
                                    <tr
                                        key={index}
                                        style={{ cursor: "pointer" }}
                                        onClick={() => {
                                            console.log(empleado.apellido);
                                            this.showDetails(
                                                empleado.idempleado,
                                                empleado.apellido,
                                                empleado.oficio,
                                                empleado.salario,
                                                empleado.departamento
                                            );
                                        }}
                                    >
                                        <td>{empleado.idempleado}</td>
                                        <td>{empleado.apellido}</td>
                                        <td>{empleado.oficio}</td>
                                        <td>{empleado.salario}</td>
                                        <td>{empleado.departamento}</td>
                                        <td style={{ display: "none" }}>
                                            <NavLink
                                                to={this.state.newLocation}
                                                ref={this.redirectToHome}
                                            >
                                                Test
                                            </NavLink>
                                        </td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </table>
                </div>
            );
        }
    }
}

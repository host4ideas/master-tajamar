import React, { Component } from "react";
import { NavLink } from "react-router-dom";

export default class DetallesEmpleado extends Component {
    render() {
        return (
            <div>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Detalles empleado: {this.props.empleadoid}
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Apellido: {this.props.apellido}
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Oficio: {this.props.oficio}
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Salario: {this.props.salario}€/anual
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Departamento: {this.props.departamento}
                </h1>

                <NavLink
                    className={"btn btn-outline-info"}
                    to={`/empleados/${this.props.departamento}`}
                >
                    🔙
                </NavLink>
            </div>
        );
    }
}

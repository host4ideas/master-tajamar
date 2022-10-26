import React, { Component } from "react";

export default class DetallesDepartamento extends Component {
    render() {
        return (
            <div>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Detalles departamento: {this.props.numero}
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Nombre: {this.props.nombre}
                </h1>
                <h1
                    className={
                        this.props.theme !== "dark" ? "text-white" : undefined
                    }
                >
                    Localidad: {this.props.localidad}
                </h1>
            </div>
        );
    }
}

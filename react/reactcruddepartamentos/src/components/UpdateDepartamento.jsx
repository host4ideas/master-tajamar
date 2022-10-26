import React, { Component } from "react";
import { Navigate } from "react-router-dom";
import axios from "axios";
import Global from "../Global";

export default class UpdateDepartamento extends Component {
    cajaNombreRef = React.createRef();
    cajaLocalidadRef = React.createRef();

    state = {
        message: null,
        loading: false,
        update: true,
    };

    actualizarDepartamento = () => {
        const request = Global.urlDepartamentos + "/api/Departamentos";

        const nuevoDepartamento = {
            numero: parseInt(this.props.numero),
            nombre: this.cajaNombreRef.current.value,
            localidad: this.cajaLocalidadRef.current.value,
        };

        axios
            .put(request, nuevoDepartamento)
            .then(() => {
                this.setState({
                    loading: false,
                    update: false,
                });
            })
            .catch((error) => {
                this.setState({
                    message: error.message,
                });
            });
    };

    handleForm = (ev) => {
        ev.preventDefault();
        this.setState({
            loading: true,
        });
        this.actualizarDepartamento();
    };

    render() {
        if (this.state.message) {
            return (
                <div>
                    <h1
                        className={
                            this.props.theme !== "dark"
                                ? "text-white"
                                : undefined
                        }
                    >
                        Actualizar departamento: {this.props.numero}
                    </h1>
                    <h2 style={{ color: "red" }}>{this.state.message}</h2>
                </div>
            );
        }

        if (this.state.loading) {
            return (
                <div className="d-flex justify-content-center">
                    <div className="spinner-border" role="status"></div>
                </div>
            );
        }

        if (this.state.update) {
            return (
                <div>
                    <h1
                        className={
                            this.props.theme !== "dark"
                                ? "text-white"
                                : undefined
                        }
                    >
                        Modificar departamento: {this.props.numero}
                    </h1>
                    <form onSubmit={this.handleForm}>
                        <div className="mb-3">
                            <label
                                className={
                                    this.props.theme !== "dark"
                                        ? " form-label text-white"
                                        : " form-label"
                                }
                                htmlFor="cajaNombre"
                            >
                                Nombre:{" "}
                            </label>
                            <input
                                type="text"
                                id="cajaNombre"
                                className="form-control"
                                ref={this.cajaNombreRef}
                                defaultValue={this.props.nombre}
                            />
                        </div>

                        <div className="mb-3">
                            <label
                                htmlFor="cajaLocalidad"
                                className={
                                    this.props.theme !== "dark"
                                        ? " form-label text-white"
                                        : " form-label"
                                }
                            >
                                Localidad:{" "}
                            </label>
                            <input
                                type="text"
                                id="cajaLocalidad"
                                className="form-control"
                                ref={this.cajaLocalidadRef}
                                defaultValue={this.props.localidad}
                            />
                        </div>

                        <button type="submit" className="btn btn-primary">
                            Modificar departamento
                        </button>
                    </form>
                </div>
            );
        }

        return <Navigate to={"/"} />;
    }
}

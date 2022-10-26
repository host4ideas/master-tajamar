import React, { Component } from "react";
import { Navigate } from "react-router-dom";
import Global from "../Global";
import axios from "axios";

export default class CreateDepartamento extends Component {
    cajaNumeroRef = React.createRef();
    cajaNombreRef = React.createRef();
    cajaLocalidadRef = React.createRef();

    state = {
        message: "",
        loading: false,
    };

    handleForm = (ev) => {
        ev.preventDefault();

        this.setState({
            loading: true,
        });

        const request = Global.urlDepartamentos + "/api/Departamentos";
        const nuevoDepartamento = {
            numero: parseInt(this.cajaNumeroRef.current.value),
            nombre: this.cajaNombreRef.current.value,
            localidad: this.cajaLocalidadRef.current.value,
        };

        axios
            .post(request, nuevoDepartamento)
            .then(() => {
                this.setState({
                    loading: false,
                });
            })
            .catch((error) => {
                this.setState({
                    loading: false,
                    message: error.message,
                });
            });
    };

    render() {
        if (this.state.loading) {
            <div>
                <h1 className={this.props.theme !== "dark" && "text-white"}>
                    Departamentos
                </h1>

                <div className="d-flex justify-content-center">
                    <div className="spinner-border" role="status"></div>
                </div>
            </div>;
        }

        if (!this.state.loading && !this.state.message) {
            return (
                <div>
                    <h2 style={{ color: "red" }}>{this.state.message}</h2>
                    <form onSubmit={this.handleForm}>
                        <div className="mb-3">
                            <label
                                htmlFor="cajaNumeroRef"
                                className={
                                    this.props.theme !== "dark"
                                        ? " form-label text-white"
                                        : " form-label"
                                }
                            >
                                Numero:{" "}
                            </label>
                            <input
                                type="text"
                                id="cajaNumeroRef"
                                className="form-control"
                                ref={this.cajaNumeroRef}
                            />
                        </div>
                        <div className="mb-3">
                            <label
                                htmlFor="cajaNombre"
                                className={
                                    this.props.theme !== "dark"
                                        ? " form-label text-white"
                                        : " form-label"
                                }
                            >
                                Nombre:{" "}
                            </label>
                            <input
                                type="text"
                                id="cajaNombre"
                                className="form-control"
                                ref={this.cajaNombreRef}
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
                            />
                        </div>

                        <button type="submit" className="btn btn-primary">
                            Crear departamento
                        </button>
                    </form>
                </div>
            );
        }

        return <Navigate to="/" replace={true} />;
    }
}

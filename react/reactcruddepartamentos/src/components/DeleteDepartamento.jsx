import React, { Component } from "react";
import { Navigate } from "react-router-dom";
import Global from "../Global";
import axios from "axios";

export default class DeleteDepartamento extends Component {
    state = {
        message: null,
        loading: true,
        delete: false,
    };

    deleteDepartamento = () => {
        const request = `/api/Departamentos/${this.props.numero}`;
        axios
            .delete(Global.urlDepartamentos + request)
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

    handleConfirmation = () => {
        this.setState({
            delete: true,
        });

        this.deleteDepartamento();
    };

    render() {
        if (!this.state.delete) {
            return (
                <button
                    className="btn btn-danger"
                    onClick={this.handleConfirmation}
                >
                    ¿Estas seguro de que quieres eliminar el departamento:{" "}
                    {this.props.numero}?
                </button>
            );
        }

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
                        Borrar departamento: {this.props.numero}
                    </h1>
                    <h2
                        className={
                            this.props.theme !== "dark"
                                ? "text-white"
                                : undefined
                        }
                        style={{ color: "red" }}
                    >
                        {this.state.message}
                    </h2>
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

        return <Navigate to="/" />;
    }
}

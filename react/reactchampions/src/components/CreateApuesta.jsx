import React, { Component } from "react";
import axios from "axios";
import Global from "../Global";
import { Navigate } from "react-router-dom";

export default class CreateApuesta extends Component {
    /*
	 {
		"idApuesta": 1,
		"usuario": "sample string 2",
		"resultado": "sample string 3",
		"fecha": "sample string 4"
	}
	 */

    state = {
        redirigir: false,
    };

    inputFecha = React.createRef();
    inputUsuario = React.createRef();
    inputResultado1 = React.createRef();
    inputResultado2 = React.createRef();

    handleSubmit = (ev) => {
        ev.preventDefault();

        const request = Global.urlChampios + "/api/Apuestas";

        const nuevaApuesta = {
            usuario: this.inputUsuario.current.value,
            resultado: `Liverpool Football Club ${this.inputResultado1.current.value} - Real Madrid Club de Fútbol ${this.inputResultado2.current.value}`,
            fecha: this.inputFecha.current.value,
        };

        axios
            .post(request, nuevaApuesta)
            .then(() => {
                console.log("Apuesta realizada");

                this.setState({
                    redirigir: true,
                });
            })
            .catch((error) => {
                console.error(error);
            });
    };

    render() {
        if (this.state.redirigir) {
            return <Navigate to="/apuestas" replace={true} />;
        }
        return (
            <div>
                <form className="m-4" onSubmit={this.handleSubmit}>
                    <div className="row mb-3">
                        <label
                            for="colFormLabel"
                            className="col-sm-2 col-form-label"
                        >
                            Usuario
                        </label>
                        <div className="col-sm-10">
                            <input
                                ref={this.inputUsuario}
                                type="text"
                                className="form-control"
                                id="colFormLabel"
                                placeholder="Introduce tu usuario"
                            />
                        </div>
                    </div>
                    <div className="row mb-3">
                        <label
                            for="colFormLabel"
                            className="col-sm-2 col-form-label"
                        >
                            Liverpool Football Club
                        </label>
                        <div className="col-sm-10">
                            <input
                                ref={this.inputResultado1}
                                type="text"
                                className="form-control"
                                id="colFormLabel"
                                placeholder="Introduce el resultado para: Liverpool Football Club"
                            />
                        </div>
                    </div>
                    <div className="row mb-3">
                        <label
                            for="colFormLabel"
                            className="col-sm-2 col-form-label"
                        >
                            Real Madrid Club de Fútbol
                        </label>
                        <div className="col-sm-10">
                            <input
                                ref={this.inputResultado2}
                                type="text"
                                className="form-control"
                                id="colFormLabel"
                                placeholder="Introduce el resultado para: Real Madrid Club de Fútbol"
                            />
                        </div>
                    </div>
                    <div className="row mb-3">
                        <label
                            for="colFormLabel"
                            className="col-sm-2 col-form-label"
                        >
                            Fecha
                        </label>
                        <div className="col-sm-10">
                            <input
                                ref={this.inputFecha}
                                type="text"
                                className="form-control"
                                id="colFormLabel"
                                placeholder="Introduce la fecha del partido"
                            />
                        </div>
                    </div>

                    <div class="col-auto">
                        <button type="submit" class="btn btn-primary">
                            Nueva apuesta
                        </button>
                    </div>
                </form>
            </div>
        );
    }
}

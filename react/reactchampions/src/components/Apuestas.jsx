import React, { Component } from "react";
import Global from "../Global";
import axios from "axios";
import { Link } from "react-router-dom";

export default class Apuestas extends Component {
    state = {
        apuestas: [],
    };

    getApuestas = () => {
        const request = Global.urlChampios + "api/Apuestas";

        axios
            .get(request)
            .then((res) => {
                this.setState({
                    apuestas: res.data,
                });
            })
            .catch((error) => {
                console.error(error);
            });
    };

    componentDidMount() {
        this.getApuestas();
    }

    render() {
        return (
            <div>
                <Link className="btn btn-danger" to={"/nuevaApuesta"}>
                    Realizar apuesta
                </Link>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Usuario</th>
                            <th>Resultado</th>
                            <th>Fecha</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state?.apuestas?.map((apuesta, index) => {
                            return (
                                <tr key={index}>
                                    <td>{apuesta.usuario}</td>
                                    <td>{apuesta.resultado}</td>
                                    <td>{apuesta.fecha}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        );
    }
}

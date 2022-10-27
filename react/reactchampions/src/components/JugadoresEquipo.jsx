import React, { Component } from "react";
import { Link } from "react-router-dom";
import Global from "../Global";
import axios from "axios";

export default class JugadoresEquipo extends Component {
    state = {
        jugadores: [],
    };
    /*
    {
        "idJugador": 1,
        "nombre": "sample string 2",
        "posicion": "sample string 3",
        "imagen": "sample string 4",
        "fechaNacimiento": "sample string 5",
        "pais": "sample string 6",
        "idEquipo": 7
    },
    */

    getJugadores = () => {
        const request =
            Global.urlChampios +
            `api/Jugadores/JugadoresEquipo/${this.props.idEquipo}`;

        axios
            .get(request)
            .then((res) => {
                this.setState({
                    jugadores: res.data,
                });
            })
            .catch((error) => {
                console.error(error);
            });
    };

    componentDidMount() {
        this.getJugadores();
    }

    componentDidUpdate(oldProps) {
        if (oldProps.idEquipo !== this.props.idEquipo) {
            this.getJugadores();
        }
    }

    render() {
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Imagen</th>
                            <th>Detalles</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state?.jugadores?.map((jugador, index) => {
                            return (
                                <tr>
                                    <td>{jugador.nombre}</td>
                                    <td>
                                        <img
                                            width={150}
                                            src={jugador.imagen}
                                            alt=""
                                        />
                                    </td>
                                    <td>
                                        <Link
                                            className="btn btn-outline-danger"
                                            to={`/detallesJugador/${jugador.idJugador}`}
                                        >
                                            Detalles
                                        </Link>
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

import React, { Component } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import Global from "../Global";

export default class DetallesJugador extends Component {
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

    state = {
        jugador: {},
    };

    getDetallesJugador = () => {
        const request =
            Global.urlChampios + `api/Jugadores/${this.props.idJugador}`;

        axios
            .get(request)
            .then((res) => {
                this.setState({
                    jugador: res.data,
                });
            })
            .catch((error) => {
                console.error(error);
            });
    };

    componentDidMount() {
        this.getDetallesJugador();
    }

    render() {
        return (
            <div>
                <h1>Nombre: {this.state?.jugador?.nombre}</h1>
                <h2>Posición: {this.state?.jugador?.posicion}</h2>
                <p>Fecha de nacimiento: {this.state?.jugador?.fechaNacimiento}</p>
                <Link
                    className="btn btn-success"
                    to={`/jugadoresEquipo/${this.state?.jugador?.idEquipo}`}
                >
                    Jugadores
                </Link>
            </div>
        );
    }
}

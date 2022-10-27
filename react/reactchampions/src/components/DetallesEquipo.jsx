import React, { Component } from "react";
import { Link } from "react-router-dom";
import Global from "../Global";
import axios from "axios";

export default class DetallesEquipo extends Component {
    /*
		idEquipo,
		nombre,
		imagen,
		champions,
		paginaWeb,
		descripcion,
	*/

    getEquipos = () => {
        const request = Global.urlChampios + "/api/Equipos";

        axios
            .get(request)
            .then((res) => {
                this.setState({
                    equipos: res.data,
                });
            })
            .catch((error) => {
                console.error(error);
            });
    };

    componentDidMount() {
        this.getEquipos();
    }

    render() {
        return (
            <div>
                <h1>{this.props.equipo.nombre}</h1>
                <h2>Champions: {this.props.equipo.champions}</h2>
                <p>{this.props.equipo.descripcion}</p>
                <img width={200} src={this.props.equipo.imagen} alt="Equipo" />
                <Link
                    className="btn btn-primary"
                    to={`/jugadoresEquipo/${this.props.equipo.idEquipo}`}
                >
                    Jugadores
                </Link>
                <Link
                    className="btn btn-primary"
                    to={`/jugadoresEquipo/${this.props.equipo.idEquipo}`}
                >
                    Volver
                </Link>
            </div>
        );
    }
}

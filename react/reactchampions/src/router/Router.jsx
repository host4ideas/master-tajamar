import React, { Component } from "react";
import { BrowserRouter, Route, Routes, useParams } from "react-router-dom";
import Global from "../Global";
import axios from "axios";
import Menu from "../components/Menu";
import Home from "../components/Home";
import DetallesEquipo from "../components/DetallesEquipo";
import JugadoresEquipo from "../components/JugadoresEquipo";
import DetallesJugador from "../components/DetallesJugador";
import Apuestas from "../components/Apuestas";
import CreateApuesta from "../components/CreateApuesta";

export default class Router extends Component {
    state = {
        equipos: [],
    };

    indiceEquipoActual = 0;
    indiceJugadorActual = 0;

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
        const DetallesEquiposElement = () => {
            const { indexEquipo } = useParams();

            this.indiceEquipoActual = indexEquipo;

            return (
                <DetallesEquipo
                    equipo={this.state.equipos[this.indiceEquipoActual]}
                />
            );
        };

        const JugadoresEquipoElement = () => {
            const { idEquipo } = useParams();

            return <JugadoresEquipo idEquipo={idEquipo} />;
        };

        const DetallesJugadorElement = () => {
            const { idJugador } = useParams();

            return (
                <DetallesJugador
                    idJugador={idJugador}
                    indiceEquipoActual={this.indiceEquipoActual}
                />
            );
        };

        return (
            <BrowserRouter>
                <Routes>
                    <Route
                        path="/"
                        element={<Menu equipos={this.state.equipos} />}
                    >
                        <Route path="/" element={<Home />} />
                        <Route
                            path="/detallesEquipo/:indexEquipo"
                            element={<DetallesEquiposElement />}
                        />
                        <Route
                            path="/jugadoresEquipo/:idEquipo"
                            element={<JugadoresEquipoElement />}
                        />
                        <Route
                            path="/detallesJugador/:idJugador"
                            element={<DetallesJugadorElement />}
                        />
                        <Route path="/apuestas" element={<Apuestas />} />
                        <Route
                            path="/nuevaApuesta"
                            element={<CreateApuesta />}
                        />
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
}

import React, { Component } from "react";
import HijoDeporte from "./HijoDeporte";

export default class PadreDeportes extends Component {
    state = {
        listaDeportes: ["Futbol", "Tenis", "Badminton", "Fronton", "Golf"],
        deporteFavorito: "",
    };

    setDeporteFavorito = (deporte) => {
        this.setState({ deporteFavorito: deporte });
    };

    crearLista = () => {
        const nuevaLista = [];
        this.setState({
            listaDeportes: [],
        });
        for (let i = 0; i < this.state.listaDeportes.length; i++) {
            nuevaLista.push(Math.floor(Math.random() * 100));
        }
        this.setState({
            listaDeportes: nuevaLista,
        });
    };

    render() {
        return (
            <div>
                <h1>PadreDeportes</h1>
                <div>
                    <p>Deporte favorito: {this.state.deporteFavorito}</p>
                    <div>
                        {this.state.listaDeportes.map((deporte, index) => {
                            return (
                                <HijoDeporte
                                    key={index}
                                    deporte={deporte}
                                    setDeporteFavorito={this.setDeporteFavorito}
                                />
                            );
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

import React, { Component } from "react";
import HijoNumero from "./HijoNumero";

export default class NumerosPadre extends Component {
    state = {
        suma: 0,
        listaHijoNumeros: [],
    };

    inicializar = () => {
        for (let i = 0; i < 1; i++) {
            this.state.listaHijoNumeros.push(Math.floor(Math.random() * 100));
            this.setState({ listaHijoNumeros: this.state.listaHijoNumeros });
        }
    };

    añadirHijo = () => {
        this.state.listaHijoNumeros.push(Math.floor(Math.random() * 100));
        this.setState({ listaHijoNumeros: this.state.listaHijoNumeros });
    };

    sumarNumero = (valor) => {
        // this.setState((prevState) => {
        //     return { suma: prevState.suma + valor };
        // });

        this.setState({
            suma: this.state.suma + valor,
        });
    };

    componentDidMount() {
        this.inicializar();
    }

    render() {
        return (
            <div>
                <h1>NumerosPadre</h1>
                <h2>La suma es: {this.state.suma}</h2>
                <button onClick={this.añadirHijo}>añadir hijo</button>
                <div>
                    {this.state.listaHijoNumeros.map((numero, index) => {
                        return (
                            <HijoNumero
                                key={index}
                                valor={numero}
                                sumarNumero={this.sumarNumero}
                            />
                        );
                    })}
                </div>
            </div>
        );
    }
}

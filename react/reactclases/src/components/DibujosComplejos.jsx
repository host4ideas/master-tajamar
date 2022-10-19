import React, { Component } from "react";

export default class DibujosComplejos extends Component {
    state = { lista2: ["Lucia", "Diana", "Adrian", "Marcos", "Carlos"] };

    crearLista = () => {
        const nuevaLista = [];
        this.setState({
            lista2: [],
        });
        for (let i = 0; i < this.state.lista2.length; i++) {
            nuevaLista.push(Math.floor(Math.random() * 100));
        }
        this.setState({
            lista2: nuevaLista,
        });
    };

    dibujarNumeros = () => {
        let lista = [];
        for (let i = 0; i < 10; i++) {
            lista.push(<li key={i}>{Math.floor(Math.random() * 100)}</li>);
        }
        return lista;
    };

    render() {
        return (
            <div>
                <h1>DibujosComplejos</h1>
                <p>
                    Con funcion (al pulsar crear lista 2 también cambiará porque
                    se vuelve a renderizar el componente)
                </p>
                <div>{this.dibujarNumeros()}</div>

                <p>Con map</p>
                <div>
                    {this.state.lista2.map((numero, index) => {
                        return <li key={index}>{numero}</li>;
                    })}
                </div>
                <button onClick={this.crearLista}>Crear lista 2 (map)</button>
            </div>
        );
    }
}

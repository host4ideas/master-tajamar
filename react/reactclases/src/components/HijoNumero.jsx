import React, { Component } from "react";

export default class HijoNumero extends Component {
    render() {
        return (
            <div>
                <h1>Número hijo: {this.props.valor}</h1>
                <button
                    onClick={() => {
                        this.props.sumarNumero(this.props.valor);
                    }}
                >
                    Sumar {this.props.valor}
                </button>
            </div>
        );
    }
}

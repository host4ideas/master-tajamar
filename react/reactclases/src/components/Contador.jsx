import { Component } from "react";

export default class Contador extends Component {
    state = { valor: parseInt(this.props.inicio) };

    numero = 0;

    incrementarNumero = () => {
        console.log("Numero " + (this.numero += 1));
    };

    incrementarValor = () => {
        this.setState({ valor: this.state.valor + 1 });
    };

    render() {
        return (
            <div>
                <h1>Componente contador</h1>
                <h2 style={{ color: "blue" }}>Inicio: {this.props.inicio}</h2>
                <h2 style={{ color: "red" }}>
                    Valor del state: {this.state.valor}
                </h2>
                <button onClick={this.incrementarValor}>
                    Incrementar valor state
                </button>
                <button onClick={this.incrementarNumero}>
                    Incrementar valor numero (por consola)
                </button>
            </div>
        );
    }
}

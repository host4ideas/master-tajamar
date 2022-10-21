import React, { Component } from "react";

export default class Collatz extends Component {
    state = {
        listaResultados: [],
    };

    inputNumero = React.createRef();

    handleSubmit = (ev) => {
        ev.preventDefault();

        this.state.listaResultados.splice(0);

        this.setState({
            listaResultados: this.state.listaResultados,
        });

        const num = parseFloat(this.inputNumero.current.value);

        if (num > 1) {
            this.calcular(num);
        }
    };

    calcular = (num) => {
        let resultado = num;

        if (num > 1) {
            const esPar = num % 2 === 0;

            if (esPar) {
                resultado = num / 2;
            } else {
                resultado = num * 3 + 1;
            }

            this.insertarResultado(resultado);

            this.calcular(resultado);
        } else {
            return resultado;
        }
    };

    insertarResultado = (valor) => {
        this.state.listaResultados.push(valor);

        this.setState({
            listaResultados: this.state.listaResultados,
        });
    };

    render() {
        return (
            <div>
                <h1 className="App-header">Clacular secuencia Collatz</h1>
                <div>
                    <h2>Resultado:</h2>
                    <ul>
                        {this.state.listaResultados.map((resultado, index) => {
                            return <li key={index}>{resultado}</li>;
                        })}
                    </ul>
                </div>
                <form action="" onSubmit={this.handleSubmit}>
                    <input
                        type="text"
                        id="inputNumero"
                        ref={this.inputNumero}
                    />
                    <button>Calcular conjetura de Collatz</button>
                </form>
            </div>
        );
    }
}

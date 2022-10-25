import React, { Component } from "react";

export default class Collatz extends Component {
    /*
		Si el número es par, se divide entre 2.
		Si el número es impar, se multiplica por 3 y se suma 1.
	*/

    state = {
        resultados: [],
        operaciones: [],
    };

    calcularCollatz = (num) => {
        let resultado = num;

        if (resultado === 1) {
            return;
        }

        if (num % 2 === 0) {
            resultado = num / 2;
            this.state.resultados.push(resultado);
            this.state.operaciones.push(`${num} / 2`);
            this.calcularCollatz(resultado);
        } else {
            resultado = resultado * 3 + 1;
            this.state.resultados.push(resultado);
            this.state.operaciones.push(`${num} * 3 + 1`);
            this.calcularCollatz(resultado);
        }

        this.setState({
            resultados: this.state.resultados,
        });

        return;
    };

    resetStates = () => {
        this.state.resultados.splice(0);
        this.state.operaciones.splice(0);
        this.setState({
            resultados: this.state.resultados,
            operaciones: this.state.operaciones,
        });
    };

    componentDidMount() {
        this.resetStates();
        this.calcularCollatz(parseInt(this.props.num));
    }

    componentDidUpdate(oldProps) {
        if (oldProps.num !== this.props.num) {
            this.resetStates();
            this.calcularCollatz(parseInt(this.props.num));
        }
    }

    render() {
        return (
            <div>
                <h1 className="App-header">Collatz: {this.props.num}</h1>
                <table
                    className={
                        this.props.theme === "dark"
                            ? "table table-dark"
                            : "table"
                    }
                >
                    <thead>
                        <tr>
                            <th>Operación</th>
                            <th>Resultado</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.resultados.map((resultado, index) => {
                            return (
                                <tr key={index}>
                                    <td>{this.state.operaciones[index]}</td>
                                    <td>{resultado}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        );
    }
}

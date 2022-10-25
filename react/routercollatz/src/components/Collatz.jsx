import React, { Component } from "react";

export default class Collatz extends Component {
    /*
		Si el número es par, se divide entre 2.
		Si el número es impar, se multiplica por 3 y se suma 1.
	*/

    state = {
        resultados: [],
    };

    calcularCollatz = (num) => {
        console.log(num);
        let resultado = num;

        if (resultado < 2) {
            this.state.resultados.push(resultado);
            this.setState({
                resultados: this.state.resultados,
            });
            return;
        }

        if (num % 2 === 0) {
            resultado = num / 2;
            this.state.resultados.push(resultado);
            this.calcularCollatz(resultado);
        } else {
            resultado = resultado * 3 + 1;
            this.state.resultados.push(resultado);
            this.calcularCollatz(resultado);
        }

        this.setState({
            resultados: this.state.resultados,
        });
        return;
    };

    componentDidMount() {
        this.calcularCollatz(this.props.num);
    }

    componentDidUpdate(oldProps) {
        if (oldProps.num !== this.props.num) {
            this.calcularCollatz(this.props.num);
        }
    }

    render() {
        return (
            <div>
                <h1 className="App-header">Collatz: {this.props.num}</h1>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th>Resultado</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.resultados.map((resultado, index) => {
                            return <tr></tr>
                        })}
                    </tbody>
                </table>
            </div>
        );
    }
}

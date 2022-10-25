import React, { Component } from "react";

export default class TablaMultiplicar extends Component {
    constructor(props) {
        super(props);
        console.log("Numero props: " + props.numero);
    }

    state = {
        resultados: [],
    };

    componentDidMount() {
        this.calcularTabla(parseInt(this.props.numero));
    }

    componentDidUpdate(oldProps) {
        if (oldProps.numero !== this.props.numero) {
            this.calcularTabla(parseInt(this.props.numero));
        }
    }

    calcularTabla = (num) => {
        this.state.resultados.splice(0);
        this.setState({
            resultados: this.state.resultados,
        });

        for (let i = 0; i < 11; i++) {
            this.state.resultados.push(
                <tr key={i}>
                    <td>{`${num} x ${i}`}</td>
                    <td>{num * i}</td>
                </tr>
            );
        }

        this.setState({
            resultados: this.state.resultados,
        });
    };

    render() {
        return (
            <div>
                <h1 className="App-header">
                    Tabla de multiplicar {this.props.numero}
                </h1>
                <table className="table table-dark table-striped">
                    <thead>
                        <tr>
                            <th scope="col">Operacion</th>
                            <th scope="col">Resultado</th>
                        </tr>
                    </thead>
                    <tbody>{this.state.resultados}</tbody>
                </table>
            </div>
        );
    }
}

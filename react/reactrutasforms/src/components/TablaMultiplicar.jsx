import React, { Component } from "react";

export default class TablaMultiplicar extends Component {
    state = {
        options: [],
        resultados: [],
    };

    selectNumeros = React.createRef();

    componentDidMount() {
        this.state.options.splice(0);
        this.setState({
            options: this.state.options,
        });

        for (let i = 0; i < 10; i++) {
            const random = Math.floor(Math.random() * 100);
            const option = <option value={random}>{random}</option>;
            this.state.options.push(option);
        }

        this.setState({
            options: this.state.options,
        });
    }

    calcularTabla = () => {
        this.state.resultados.splice(0);
        this.setState({
            resultados: this.state.resultados,
        });

        const num = this.selectNumeros.current.value;

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
                <label htmlFor="selectNumeros">Selecciona un número</label>
                <select
                    name=""
                    id="selectNumeros"
                    ref={this.selectNumeros}
                    onChange={this.calcularTabla}
                >
                    {this.state.options}
                </select>
                <table>
                    <thead>
                        <tr>
                            <th>Operacion</th>
                            <th>Resultado</th>
                        </tr>
                    </thead>
                    <tbody>{this.state.resultados}</tbody>
                </table>
            </div>
        );
    }
}

import React, { Component } from "react";
import axios from "axios";
import Global from "../Global";
import MaestroEmpleados from "./MaestroEmpleados";

export default class MaestroDepartamento extends Component {
    selectRef = React.createRef();

    state = {
        departamentos: [],
        departamento: null,
    };

    setDepartamentos = (departamentos) => {
        this.setState({
            departamentos: departamentos,
        });
    };

    loadDepartamentos = () => {
        axios
            .get(Global.urlDepartamentos + "/api/departamentos")
            .then((res) => {
                this.setDepartamentos(res.data);
            });
    };

    componentDidMount() {
        this.loadDepartamentos();
    }

    handleSelectChange = (ev) => {
        ev.preventDefault();
        this.setState({
            departamento: this.selectRef.current.value,
        });
    };

    render() {
        return (
            <div>
                <h1>Maestro Departamentos</h1>

                <label htmlFor="selectDepartamento">
                    Selecciona un departamento
                </label>
                <select
                    name="selectDepartamento"
                    id="selectDepartamento"
                    ref={this.selectRef}
                    onChange={this.handleSelectChange}
                >
                    {this.state?.departamentos?.map((departamento, index) => {
                        return (
                            <option key={index} value={departamento.Numero}>
                                Nombre: {departamento.Nombre} -- Localidad:{" "}
                                {departamento.Localidad}
                            </option>
                        );
                    })}
                </select>

                <ul>
                    <MaestroEmpleados
                        numDepartamento={this.state.departamento}
                    />
                </ul>
            </div>
        );
    }
}

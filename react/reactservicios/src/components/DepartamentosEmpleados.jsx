import React, { Component } from "react";
import axios from "axios";
import Global from "../Global";

export default class DepartamentosEmpleados extends Component {
    selectRef = React.createRef();

    state = {
        departamentos: [],
        empleados: [],
    };

    setDepartamentos = (departamentos) => {
        this.setState({
            departamentos: departamentos,
        });
    };

    setEmpleados = (empleados) => {
        this.setState({
            empleados: empleados,
        });
    };

    loadEmpleados = (numDepartamento) => {
        axios
            .get(
                Global.urlEmpleados +
                    `/api/Empleados/EmpleadosDepartamento/${numDepartamento}`
            )
            .then((res) => {
                this.setEmpleados(res.data);
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

    render() {
        return (
            <div>
                <h1>DepartamentosEmpleados</h1>

                <label htmlFor="selectDepartamento">
                    Selecciona un departamento
                </label>
                <select
                    name="selectDepartamento"
                    id="selectDepartamento"
                    ref={this.selectRef}
                    onChange={() => {
                        this.loadEmpleados(this.selectRef.current.value);
                    }}
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
                    {this.state?.empleados?.length > 0 &&
                        this.state?.empleados?.map((empleado, index) => {
                            return (
                                <li key={empleado.idEmpleado}>
                                    Apellido: {empleado.apellido}
                                    <br />
                                    Oficio: {empleado.oficio}
                                    <br />
                                    Salario: {empleado.salario}
                                </li>
                            );
                        })}
                </ul>
            </div>
        );
    }
}

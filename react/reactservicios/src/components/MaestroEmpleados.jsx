import React, { Component } from "react";
import axios from "axios";
import Global from "../Global";

export default class MaestroEmpleados extends Component {
    state = {
        empleados: [],
    };

    componentDidUpdate(oldProps) {
        console.log("Actual props: " + this.props.numDepartamento);
        console.log("Old props " + oldProps.numDepartamento);

        // Solo cambiar el render cuando las props han cambiado
        if (this.props.numDepartamento !== oldProps.numDepartamento) {
            console.log("test");
            this.loadEmpleados();
        }
    }

    loadEmpleados = () => {
        axios
            .get(
                Global.urlEmpleados +
                    `/api/Empleados/EmpleadosDepartamento/${this.props.numDepartamento}`
            )
            .then((res) => {
                this.setEmpleados(res.data);
            });
    };

    setEmpleados = (empleados) => {
        this.setState({
            empleados: empleados,
        });
    };

    render() {
        return (
            <div>
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
            </div>
        );
    }
}

import React, { Component } from "react";
import { Routes, Route, BrowserRouter, useParams } from "react-router-dom";
import axios from "axios";
import Global from "../Global";
import Menu from "../components/Menu";
import Departamentos from "../components/Departamentos";
import CreateDepartamento from "../components/CreateDepartamento";
import DetallesDepartamento from "../components/DetallesDepartamento";
import DeleteDepartamento from "../components/DeleteDepartamento";
import UpdateDepartamento from "../components/UpdateDepartamento";
import Empleados from "../components/Empleados";
import DetallesEmpleado from "../components/DetallesEmpleado";

export default class Router extends Component {
    state = {
        departamentos: [],
        loading: true,
    };

    getDepartamentos = () => {
        const request = Global.urlDepartamentos + "/api/Departamentos";
        axios
            .get(request)
            .then((response) => {
                this.setState({
                    loading: false,
                    departamentos: response.data,
                });
            })
            .catch((error) => {
                console.error(error);
                this.setState({
                    loading: false,
                });
            });
    };

    componentDidMount() {
        this.getDepartamentos();
    }

    render() {
        const GetDetallesDepartamento = () => {
            const { numero, nombre, localidad } = useParams();

            return (
                <DetallesDepartamento
                    numero={numero}
                    nombre={nombre}
                    localidad={localidad}
                    theme={this.props.theme}
                />
            );
        };

        const GetDeleteDepartamento = () => {
            const { numero } = useParams();

            return (
                <DeleteDepartamento numero={numero} theme={this.props.theme} />
            );
        };

        const GetUpdateDepartamento = () => {
            const { numero, nombre, localidad } = useParams();

            return (
                <UpdateDepartamento
                    numero={numero}
                    nombre={nombre}
                    localidad={localidad}
                    theme={this.props.theme}
                />
            );
        };

        const GetEmpleados = () => {
            const { departamentoid } = useParams();

            return (
                <Empleados
                    departamentoId={departamentoid}
                    theme={this.props.theme}
                />
            );
        };

        const GetDetallesEmpleado = () => {
            const { empleadoid, apellido, oficio, salario, departamento } = useParams();

            return (
                <DetallesEmpleado
                    empleadoid={empleadoid}
                    apellido={apellido}
                    oficio={oficio}
                    salario={salario}
                    departamento={departamento}
                    theme={this.props.theme}
                />
            );
        };

        return (
            <BrowserRouter>
                <Routes>
                    <Route
                        path="/"
                        element={
                            <Menu
                                loading={this.state.loading}
                                departamentos={this.state.departamentos}
                                theme={this.props.theme}
                                setTheme={this.props.setTheme}
                            />
                        }
                    >
                        <Route
                            path="/"
                            element={
                                <Departamentos
                                    departamentos={this.state.departamentos}
                                    loading={this.state.loading}
                                    theme={this.props.theme}
                                />
                            }
                        />
                        <Route
                            path="createdepartamento"
                            element={
                                <CreateDepartamento theme={this.props.theme} />
                            }
                        />
                        <Route
                            path="details/:numero/:nombre/:localidad"
                            element={<GetDetallesDepartamento />}
                        />
                        <Route
                            path="delete/:numero"
                            element={<GetDeleteDepartamento />}
                        />
                        <Route
                            path="update/:numero/:nombre/:localidad"
                            element={<GetUpdateDepartamento />}
                        />
                        <Route
                            path="empleados/:departamentoid"
                            element={<GetEmpleados />}
                        />
                        <Route
                            path="detallesempleado/:empleadoid/:apellido/:oficio/:salario/:departamento"
                            element={<GetDetallesEmpleado />}
                        />
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
}

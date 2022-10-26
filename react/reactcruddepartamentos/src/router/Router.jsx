import React, { Component } from "react";
import { Routes, Route, BrowserRouter, useParams } from "react-router-dom";
import Menu from "../components/Menu";
import Departamentos from "../components/Departamentos";
import CreateDepartamento from "../components/CreateDepartamento";
import DetallesDepartamento from "../components/DetallesDepartamento";
import DeleteDepartamento from "../components/DeleteDepartamento";
import UpdateDepartamento from "../components/UpdateDepartamento";

export default class Router extends Component {
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

        return (
            <BrowserRouter>
                <Routes>
                    <Route
                        path="/"
                        element={
                            <Menu
                                theme={this.props.theme}
                                setTheme={this.props.setTheme}
                            />
                        }
                    >
                        <Route
                            path="/"
                            element={<Departamentos theme={this.props.theme} />}
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
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
}

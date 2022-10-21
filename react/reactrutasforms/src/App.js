import React, { Component } from "react";
import Layout from "./components/Layout";
import Layout2 from "./components/Layout2";
import Home from "./components/Home";
import Cine from "./components/Cine";
import Music from "./components/Music";
import Error404 from "./components/Error404";
import FormSimple from "./components/FormSimple";
import Collatz from "./components/Collatz";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import TablaMultiplicar from "./components/TablaMultiplicar";

export default class Router extends Component {
    state = {
        user: null,
    };

    userLogin = (nombre, edad) => {
        this.setState({
            user: {
                nombre: nombre,
                edad: edad,
            },
        });
    };

    render() {
        return (
            <div className="App">
                <BrowserRouter>
                    <Routes>
                        <Route
                            path="/"
                            element={<Layout user={this.state.user} />}
                        >
                            <Route
                                path="formulario"
                                element={
                                    <FormSimple
                                        user={this.state.user}
                                        userLogin={this.userLogin}
                                    />
                                }
                            />
                            <Route path="collatz" element={<Collatz />} />
                            <Route
                                path="tablamultiplicar"
                                element={<TablaMultiplicar />}
                            />
                            <Route path="*" element={<Error404 />} />
                        </Route>
                        <Route
                            path="/"
                            element={<Layout2 user={this.state.user} />}
                        >
                            <Route path="home" element={<Home />} />
                            <Route path="cine" element={<Cine />} />
                            <Route path="music" element={<Music />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
}

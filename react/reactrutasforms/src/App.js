import React, { Component } from "react";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Cine from "./components/Cine";
import Music from "./components/Music";
import Error404 from "./components/Error404";
import FormSimple from "./components/FormSimple";
import Collatz from "./components/Collatz";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";

export default class Router extends Component {
    render() {
        return (
            <div className="App">
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<Layout />}>
                            <Route path="/" element={<Home />} />
                            <Route path="home" element={<Home />} />
                            <Route path="cine" element={<Cine />} />
                            <Route path="music" element={<Music />} />
                            <Route path="formulario" element={<FormSimple />} />
                            <Route path="collatz" element={<Collatz />} />
                            <Route path="*" element={<Error404 />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
}

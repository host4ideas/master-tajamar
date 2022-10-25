import React, { Component } from "react";
import { BrowserRouter, Route, Routes, useParams } from "react-router-dom";
import TablaMultiplicar from "./RutasParametros/TablaMultiplicar";
import MenuRutas from "./RutasParametros/MenuRutas";
import Home from "./RutasParametros/Home";
import Error404 from "./RutasParametros/Error404";

export default class Router extends Component {
    render() {
        function GetTablaMultipliar() {
            const { numero } = useParams();
            return <TablaMultiplicar numero={numero} />;
        }

        return (
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MenuRutas />}>
                        <Route
                            path="/tablaMultiplicar/:numero"
                            element={<GetTablaMultipliar />}
                        />
                        <Route path="home" element={<Home />} />
                        <Route path="*" element={<Error404 />} />
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
}

import React, { Component } from "react";
import { Routes, Route, BrowserRouter, useParams } from "react-router-dom";
import Collatz from "../components/Collatz";
import Layout from "../components/Layout";

export default class Router extends Component {
    render() {
        function GetCollatzElement() {
            const { numero } = useParams();

            return <Collatz num={numero} />;
        }

        return (
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Layout />}>
                        <Route
                            path="collatz/:numero"
                            element={<GetCollatzElement />}
                        />
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
}

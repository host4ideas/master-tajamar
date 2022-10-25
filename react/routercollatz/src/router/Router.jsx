import React, { Component } from "react";
import { Routes, Route, BrowserRouter, useParams } from "react-router-dom";
import Collatz from "../components/Collatz";
import Layout from "../components/Layout";

export default class Router extends Component {
    render() {
        const GetCollatzElement = () => {
            const { numero } = useParams();

            return (
                <Collatz
                    theme={this.props.theme}
                    setTheme={this.props.setTheme}
                    num={numero}
                />
            );
        };

        return (
            <BrowserRouter>
                <Routes>
                    <Route
                        path="/"
                        element={
                            <Layout
                                theme={this.props.theme}
                                setTheme={this.props.setTheme}
                            />
                        }
                    >
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

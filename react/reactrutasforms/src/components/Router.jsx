import React, { Component } from "react";
import Layout from "./Layout";
import Home from "./Home";
import Cine from "./Cine";
import Music from "./Music";
import { BrowserRouter, Route, Switch, Routes } from "react-router-dom";

export default class Router extends Component {
    render() {
        return (
            <BrowserRouter>
                <Switch>
                    <Route path="/" component={<Layout />}>
                        <Route path="home" component={<Home />} />
                        <Route path="cine" component={<Cine />} />
                        <Route path="music" component={<Music />} />
                    </Route>
                </Switch>
            </BrowserRouter>
        );
    }
}

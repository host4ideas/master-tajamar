import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";
import homeImage from "../assets/images/home.webp";

export default class Home extends Component {
    render() {
        return (
            <div>
                <h1 className="App-header">Home</h1>
                <img src={homeImage} alt="Home" />
            </div>
        );
    }
}

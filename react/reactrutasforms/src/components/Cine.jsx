import React, { Component } from "react";
import cineImage from "../assets/images/cine.jpg";

export default class Cine extends Component {
    render() {
        return (
            <div>
                <h1 className="App-header">Cine</h1>
                <img src={cineImage} alt="Cine" />
            </div>
        );
    }
}

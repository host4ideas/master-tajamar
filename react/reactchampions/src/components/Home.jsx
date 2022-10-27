import React, { Component } from "react";
import homeImage from "../assets/images/home-image.jpg";

export default class Home extends Component {
    render() {
        return (
            <div>
                <h1>Champions</h1>
                <img width={500} src={homeImage} alt="" />
            </div>
        );
    }
}

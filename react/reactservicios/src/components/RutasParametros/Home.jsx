import React, { Component } from "react";
import homeImage from "../../assets/images/home.webp";

export default class Home extends Component {
    render() {
        return (
            <div>
                <h1>Home</h1>
                <img width={300} src={homeImage} alt="" />
            </div>
        );
    }
}

import React, { Component } from "react";
import error404Image from "../../assets/images/404.jpg";

export default class Error404 extends Component {
    render() {
        return (
            <div>
                <h1 className="App-header">Page not found</h1>
                <img src={error404Image} alt="Error 404" />
            </div>
        );
    }
}

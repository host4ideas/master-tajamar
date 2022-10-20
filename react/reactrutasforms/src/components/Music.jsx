import React, { Component } from "react";
import musicImage from "../assets/images/music.jpg";

export default class Music extends Component {
    render() {
        return (
            <div>
                <h1>Music</h1>
                <img src={musicImage} alt="Music" />
            </div>
        );
    }
}

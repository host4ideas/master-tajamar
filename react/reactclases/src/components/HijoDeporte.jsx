import React, { Component } from "react";

export default class HijoDeporte extends Component {
    render() {
        return (
            <div>
                <h1>HijoDeporte</h1>
                <div>
                    <p>{this.props.deporte}</p>
                    <button
                        onClick={() => {
                            this.props.setDeporteFavorito(this.props.deporte);
                        }}
                    >
                        Marcar como favorito
                    </button>
                </div>
            </div>
        );
    }
}

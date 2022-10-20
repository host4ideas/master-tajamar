import React, { Component } from "react";

export default class Comic extends Component {
    render() {
        return (
            <div>
                <h1 style={{ color: "red" }}>
                    Titulo: {this.props.comic.titulo}
                </h1>
                <h3 style={{ color: "blue" }}>
                    Titulo: {this.props.comic.descripcion}
                </h3>
                <img src={this.props.comic.imagen} alt="Comic"></img>
                <p>Descripcion: {this.props.comic.descripcion}</p>

                <button
                    style={{ color: "red" }}
                    onClick={() => {
                        this.props.borrarComic(this.props.index);
                    }}
                >
                    Eliminar comic
                </button>
                <button
                    style={{ color: "green" }}
                    onClick={() => {
                        this.props.favorito(this.props.index);
                    }}
                >
                    Favorito
                </button>
                <button
                    style={{ color: "orange" }}
                    onClick={() => {
                        this.props.actualizarComic(this.props.index);
                    }}
                >
                    Actualizar comic
                </button>
            </div>
        );
    }
}

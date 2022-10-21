import React, { Component } from "react";

export default class FormSimple extends Component {
    state = {
        user: null,
    };

    inputNombre = React.createRef();
    inputEdad = React.createRef();

    handleSubmit = (ev) => {
        ev.preventDefault();

        this.setState({
            user: {
                nombre: this.inputNombre.current.value,
                edad: this.inputEdad.current.value,
            },
        });
    };

    render() {
        return (
            <div>
                <h1 className="App-header">Ejemplo simple forms</h1>

                {this.state.user && (
                    <div>
                        <h2>
                            Usuario: {this.state.user.nombre}, Edad:{" "}
                            {this.state.user.edad}
                        </h2>
                    </div>
                )}

                <form onChange={this.handleSubmit}>
                    <label htmlFor="inputNombre">Nombre: </label>
                    <input
                        type="text"
                        id="inputNombre"
                        ref={this.inputNombre}
                    />
                    <br />
                    <label htmlFor="inputEdad">Edad: </label>
                    <input type="text" id="inputEdad" ref={this.inputEdad} />
                    <br />
                    <button>Enviar datos</button>
                </form>
            </div>
        );
    }
}

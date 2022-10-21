import React, { Component } from "react";

export default class FormSimple extends Component {
    inputNombre = React.createRef();
    inputEdad = React.createRef();

    handleSubmit = (ev) => {
        ev.preventDefault();

        this.props.userLogin(
            this.inputNombre.current.value,
            this.inputEdad.current.value
        );
    };

    render() {
        return (
            <div>
                <h1 className="App-header">Ejemplo simple forms</h1>

                {this.props.user && (
                    <div>
                        <h2>
                            Usuario: {this.props.user.nombre}, Edad:{" "}
                            {this.props.user.edad}
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

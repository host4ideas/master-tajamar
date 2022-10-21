import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";

export default class Layout2 extends Component {
    render() {
        return (
            <>
                <nav>
                    <h2>Layout 2</h2>
                    <ul>
                        <li>
                            <Link to="/home">Home</Link>
                        </li>
                        <li>
                            <Link to="/cine">Cine</Link>
                        </li>
                        <li>
                            <Link to="/music">Music</Link>
                        </li>
                        <li>
                            <Link to="/formulario">Formulario - Cambiar usuario</Link>
                        </li>
                        <li>
                            <Link to="/collatz">Conjetura de Collatz</Link>
                        </li>
                        <li>
                            <Link to="/tablamultiplicar">
                                Tabla de multiplicar
                            </Link>
                        </li>
                    </ul>
                </nav>

                {this.props.user && (
                    <div>
                        <h3>
                            Usuario: {this.props.user.nombre}, Edad:{" "}
                            {this.props.user.edad}
                        </h3>
                    </div>
                )}

                <Outlet />
            </>
        );
    }
}

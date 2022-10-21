import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";

export default class Layout extends Component {
    render() {
        return (
            <>
                <nav>
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
                            <Link to="/formulario">Formulario</Link>
                        </li>
                        <li>
                            <Link to="/collatz">Conjetura de Collatz</Link>
                        </li>
                    </ul>
                </nav>

                <Outlet />
            </>
        );
    }
}

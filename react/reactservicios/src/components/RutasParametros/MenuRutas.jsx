import React, { Component } from "react";
import { Outlet, Link, NavLink } from "react-router-dom";
import NavLinkButton from "./NavLinkButton";

export default class MenuRutas extends Component {
    render() {
        return (
            <>
                <nav className="App-header">
                    <h2>MenuRutas</h2>
                    {/* <ul>
                        <li>
                            <NavLink to={"home"}></NavLink>
                        </li>
                        <li>
                            <Link to="/home">Home</Link>
                        </li>
                        <li>
                            <Link to="/tablamultiplicar/1">
                                Tabla de multiplicar 1
                            </Link>
                        </li>
                        <li>
                            <Link to="/tablamultiplicar/2">
                                Tabla de multiplicar 2
                            </Link>
                        </li>
                        <li>
                            <Link to="/tablamultiplicar/3">
                                Tabla de multiplicar 3
                            </Link>
                        </li>
                        <li>
                            <Link to="/tablamultiplicar/4">
                                Tabla de multiplicar 4
                            </Link>
                        </li>
                    </ul> */}
                    <div className="btn-group">
                        <NavLinkButton path="home" />
                        
                        <NavLink to={"home"}>
                            <button className="btn btn-primary">Home</button>
                        </NavLink>{" "}
                        <NavLink to={"home"}>
                            <button className="btn  btn-danger">Home</button>
                        </NavLink>{" "}
                        <NavLink to={"home"}>
                            <button className="btn  btn-danger">Home</button>
                        </NavLink>
                    </div>
                </nav>

                <Outlet />
            </>
        );
    }
}

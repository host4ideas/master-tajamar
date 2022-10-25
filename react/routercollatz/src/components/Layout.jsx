import React, { Component } from "react";
import { Outlet, Link } from "react-router-dom";

export default class Layout extends Component {
    render() {
        return (
            <>
                <nav>
                    <Link to={"collatz/1"}>Collatz 1</Link>
                    <Link to={"collatz/2"}>Collatz 2</Link>
                    <Link to={"collatz/3"}>Collatz 3</Link>
                    <Link to={"collatz/4"}>Collatz 4</Link>
                    <Link to={"collatz/5"}>Collatz 5</Link>
                    <Link to={"collatz/6"}>Collatz 6</Link>
                    <Link to={"collatz/7"}>Collatz 7</Link>
                </nav>
                <Outlet />
            </>
        );
    }
}

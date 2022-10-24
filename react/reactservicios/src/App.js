import React, { Component } from "react";
import DepartamentosEmpleados from "./components/DepartamentosEmpleados";
// import BuscadorCustomer from "./components/BuscadorCustomer";

export default class App extends Component {
    render() {
        return (
            <div className="App">
                <DepartamentosEmpleados />
                {/* <BuscadorCustomer /> */}
            </div>
        );
    }
}

import React, { Component } from "react";
// import DepartamentosEmpleados from "./components/DepartamentosEmpleados";
// import BuscadorCustomer from "./components/BuscadorCustomer";
// import MaestroDepartamento from "./components/MaestroDepartamento";
// import TablaMultiplicar from "./components/RutasParametros/TablaMultiplicar";
// import MenuRutas from "./components/RutasParametros/MenuRutas";
import 'bootstrap/dist/css/bootstrap.min.css';

import Router from "./components/Router";
import "./App.css";

export default class App extends Component {
    render() {
        return (
            <div className="App">
                {/* <DepartamentosEmpleados /> */}
                {/* <BuscadorCustomer /> */}
                {/* <MaestroDepartamento /> */}
                {/* <TablaMultiplicar numero={5} />
                <TablaMultiplicar numero={25} /> */}
                {/* <MenuRutas /> */}
                <Router />
            </div>
        );
    }
}

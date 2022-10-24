import React, { Component } from "react";
import MostrarCustomers from "./MostrarCustomers";
import axios from "axios";
import Global from "../Global";

export default class BuscadorCustomer extends Component {
    inputMarca = React.createRef();

    state = {
        customers: [],
    };

    setCustomers = (customers) => {
        this.setState({
            customers: customers,
        });
    };

    loadCustomers = () => {
        axios.get(Global.urlCustomers + "webresources/coches").then((res) => {
            this.setCustomers(res.data);
        });
    };

    componentDidMount() {
        this.loadCustomers();
    }

    filtroPorMarca = () => {
        this.loadCustomers();

        const customers = this.customers.filter((customer, index) => {
            return (
                customer.marca.toLowerCase() ===
                this.inputMarca.current.value.toLowerCase()
            );
        });

        this.setCustomers(customers);
    };

    render() {
        return (
            <div>
                <label htmlFor="inputMarca">Marca: </label>
                <input ref={this.inputMarca} type="text" id="inputMarca" />
                <button onClick={this.filtroPorMarca}>Filtrar coches</button>
                <button onClick={this.loadCustomers}>
                    Cargar todos los coches
                </button>

                <MostrarCustomers
                    customers={this.customers}
                    setCustomers={this.setCustomers}
                    loadCustomers={this.loadCustomers}
                />
            </div>
        );
    }
}

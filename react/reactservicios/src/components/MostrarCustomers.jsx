import React, { Component } from "react";

export default class MostrarCustomers extends Component {
    render() {
        return (
            <div>
                <h1>Customers</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Marca</th>
                            <th>Modelo</th>
                            <th>Dueño</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props?.customers?.length > 0 &&
                            this.props.customers.map((customer, index) => {
                                console.log(customer);
                                return (
                                    <tr key={customer.id}>
                                        <td>{customer.marca}</td>
                                        <td>{customer.modelo}</td>
                                        <td>{customer.conductor}</td>
                                    </tr>
                                );
                            })}
                    </tbody>
                </table>
            </div>
        );
    }
}

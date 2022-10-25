import Button from "react-bootstrap/Button";

import React, { Component } from "react";

export default class NavLinkBtn extends Component {
    render() {
        return (
            <Button
                variant="outline-light"
                size="lg"
                // onClick={() => handleClick(path)}
            >
                {this.props.path}
            </Button>
        );
    }
}

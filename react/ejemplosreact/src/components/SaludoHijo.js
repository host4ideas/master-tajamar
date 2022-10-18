import React from "react";

export default function SaludoHijo({ idHijo, metodoPadre }) {
    return (
        <button onClick={() => metodoPadre("Soy: " + idHijo)}>Saludar</button>
    );
}

import React, { useState } from "react";

export default function Car(props) {
    const coche = {
        marca: props.marca,
        modelo: props.modelo,
        aceleracion: parseInt(props.aceleracion),
        velocidadMaxima: parseInt(props.velocidadMaxima),
    };

    const [arrancado, setArrancado] = useState(false);
    const [velocidad, setVelocidad] = useState(0);

    const acelerarCoche = () => {
        if (!arrancado) {
            alert("El coche está detenido");
            setVelocidad(0);
        } else if (velocidad >= coche.velocidadMaxima) {
            setVelocidad(coche.velocidadMaxima);
        } else {
            setVelocidad(velocidad + coche.aceleracion);
        }
    };

    const handleArrancarBtn = () => {
        setArrancado((arrancado) => !arrancado);
        if (arrancado) {
            setVelocidad(0);
        }
    };

    return (
        <div>
            {html}
            <h1 style={{ color: "fuchsia" }}>
                Component Car {coche.marca}, {coche.modelo}
            </h1>
            <div>
                {arrancado ? (
                    <h2 style={{ color: "green" }}>Encendido</h2>
                ) : (
                    <h2 style={{ color: "red" }}>Apagado</h2>
                )}
            </div>
            <h2>Velocidad actual {velocidad} km/h</h2>
            <button onClick={handleArrancarBtn}>Arrancar/Detener</button>
            <button onClick={acelerarCoche}>Acelerar coche</button>
        </div>
    );
}

import MostrarOperaciones from "./MostrarOperaciones";
import { useState } from "react";

export default function Matematicas({ num, input }) {
    const [resultado, setResultado] = useState(0);

    const multiplicar = () => {
        const multiplicarPor = parseInt(document.getElementById(input).value);

        setResultado(() => parseInt(num) * multiplicarPor);
    };

    return (
        <div>
            <h1>Hijo</h1>
            <button onClick={multiplicar}>Multiplicar por: {num}</button>
            <MostrarOperaciones resultado={resultado} />
        </div>
    );
}

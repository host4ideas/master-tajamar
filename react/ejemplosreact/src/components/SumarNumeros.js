import { useState } from "react";
import image from "../assets/images/image2.jpg";

export default function SumarNumeros({ input1, input2 }) {
    const [suma, setSuma] = useState(0);

    const btnHandler = () => {
        const input1Value = document.getElementById(input1).value;
        const input2Value = document.getElementById(input2).value;
        setSuma(
            (suma) => (suma += parseInt(input1Value) + parseInt(input2Value))
        );
    };

    return (
        <div>
            <img src={image} style={{ width: "300px" }} />
            <p>El resultado es: {suma}</p>
            <button type="button" onClick={btnHandler}>
                Sumar
            </button>
        </div>
    );
}

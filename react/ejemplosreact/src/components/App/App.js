import "./App.css";
import SumarNumeros from "../SumarNumeros";
import SaludoHijo from "../SaludoHijo";
import Matematicas from "../Matematicas";

function App() {
    const metodoPadre = (descripcion) => {
        console.log("Soy: " + descripcion);
    };

    return (
        <div className="App">
            <input id="input1" type={"text"}></input>
            <span>+</span>
            <input id="input2" type={"text"}></input>
            <SumarNumeros input1={"input1"} input2={"input2"} />
            <SaludoHijo idHijo="1" metodoPadre={metodoPadre} />
            <SaludoHijo idHijo="2" metodoPadre={metodoPadre} />
            <SaludoHijo idHijo="3" metodoPadre={metodoPadre} />

            <Matematicas num={7} input={"input3"} />
            <Matematicas num={2} input={"input4"} />
            <Matematicas num={5} input={"input5"} />

            <span>Multiplicar</span>
            <input id="input3" type={"text"}></input>
            <input id="input4" type={"text"}></input>
            <input id="input5" type={"text"}></input>
        </div>
    );
}

export default App;

import axios from "axios";

class EmpleadosService {
    #urlEmpleados = "https://apiempleadosspgs.azurewebsites.net/";

    async findEmpleado(idEmpleado) {
        const request = this.#urlEmpleados + `api/Empleados/${idEmpleado}`;

        try {
            const response = await axios.get(request);
            return response.data;
        } catch (error) {
            console.error(error);
        }
    }

    async getEmpleadosDepartamento(deptno) {
        const request =
            this.#urlEmpleados +
            `api/Empleados/EmpleadosDepartamento/${deptno}`;

        try {
            const response = await axios.get(request);
            return response.data;
        } catch (error) {
            console.error(error);
        }
    }
}

const singletonInstance = new EmpleadosService();

Object.freeze(singletonInstance);

export default singletonInstance;

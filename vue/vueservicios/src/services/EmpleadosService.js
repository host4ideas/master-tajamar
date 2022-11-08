import axios from "axios";

class EmpleadosService {
    #urlEmpleados = "https://apiempleadosfullstack.azurewebsites.net";

    async getEmpleados() {
        const request = this.#urlEmpleados + `/api/Empleados`;

        const response = await axios.get(request);
        return response.data;
    }

    async getEmpleadosOficio(oficio) {
        try {
            const request =
                this.#urlEmpleados + `/api/Empleados/EmpleadosOficio/${oficio}`;

            const response = await axios.get(request);
            return response.data;
        } catch (error) {
            console.error(error);
        }
    }

    async findEmpleado(idEmpleado) {
        try {
            const request = this.#urlEmpleados + `/api/Empleados/${idEmpleado}`;

            const response = await axios.get(request);
            return response.data;
        } catch (error) {
            console.error(error.message);
        }
    }
}

const singletonInstance = new EmpleadosService();

Object.freeze(singletonInstance);

export default singletonInstance;

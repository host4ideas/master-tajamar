import axios from "axios";
// Environment variables
import { environment } from "../environments/environment";

// Para hacerlo global si necesidad de importarlo en app module
class PlantillaService {
    constructor() {}

    /**
     * Petición get para recoger todos los elementos
     * @param {object} config Axios config object
     * @returns Axios promise
     */
    getEmpleados(config) {
        const request = environment.API_PLANTILLA + "/api/Empleados/";
        return axios.get(request, config);
    }

    /**
     * Petición get para recoger solo un elemento
     * @param {string} id ID del elemento para la petición
     * @param {Object} config Axios config object
     * @returns Axios promise
     */
    findEmpleado(id, config) {
        const request = environment.API_PLANTILLA + `/api/Empleados/${id}`;
        return axios.get(request, config);
    }
}

const singletonInstance = new PlantillaService();

Object.freeze(singletonInstance);

export default singletonInstance;

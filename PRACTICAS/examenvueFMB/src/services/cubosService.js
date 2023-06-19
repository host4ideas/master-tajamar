import axios from "axios";
import { environment } from "@/environments/environment";
import { useRouter } from "vue-router";

export class CubosService {
    constructor() {
        this.router = useRouter();
    }

    /**
     * Petición get para recoger todos los cubos
     * @returns  Axios response
     */
    getCubos() {
        const request = environment.API_TIENDAS + "/api/Cubos";
        return axios.get(request);
    }

    /**
     * Petición get para recoger todas las marcas
     * @returns  Axios response
     */
    getMarcas() {
        const request = environment.API_TIENDAS + "/api/Cubos/Marcas";
        return axios.get(request);
    }

    /**
     * Petición get para recoger todas las marcas
     * @param {string} marca Marca de la cual recoger todos sus cubos
     * @returns {Promise<AxiosResponse<any, any>>} Axios response
     */
    getCubosMarca(marca) {
        const request =
            environment.API_TIENDAS + "/api/Cubos/CubosMarca/" + marca;
        return axios.get(request);
    }

    /**
     * Petición get para recoger solo un elemento
     * @param {string} id ID del cubo para la petición
     * @returns  Axios response
     */
    findCubo(id) {
        const request = environment.API_TIENDAS + "/api/Cubos/" + id;
        return axios.get(request);
    }

    /**
     * Petición get para recoger solo un elemento
     * @param {string} idcubo ID del cubo para la petición
     * @returns  Axios response
     */
    getComentariosCubo(idcubo) {
        const request =
            environment.API_TIENDAS +
            "/api/ComentariosCubo/GetComentariosCubo/" +
            idcubo;
        return axios.get(request);
    }

    /**
     * Petición get para recoger todos los elementos
     * @param {HttpHeaders} headers Insertamos los headers en authService para securizar la peticion
     * @returns  Axios response
     */
    getPerfilUsuario(config) {
        const request = environment.API_TIENDAS + "/api/Manage/PerfilUsuario";
        return axios.get(request, config);
    }

    /**
     * Petición get para recoger todas las compras del usuario
     * @param {HttpHeaders} headers Insertamos los headers en authService para securizar la peticion
     * @returns  Axios response
     */
    getComprasUsuario(config) {
        const request = environment.API_TIENDAS + "/api/Compra/ComprasUsuario";
        return axios.get(request, config);
    }

    /**
     * Petición get para recoger todas las compras del usuario
     * @param {string} idcubo ID del cubo para la petición
     * @param {HttpHeaders}  Insertamos los headers en authService para securizar la peticion
     * @returns  Axios response
     */
    realizarCompra(idcubo, config) {
        config.headers["Content-Type"] = "application/json";

        const request =
            environment.API_TIENDAS + "/api/Compra/InsertarPedido/" + idcubo;
        return axios.post(request, null, config);
    }
}

const singletonInstance = new CubosService();

Object.freeze(singletonInstance);

export default singletonInstance;

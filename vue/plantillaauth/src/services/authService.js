import axios from "axios";
// Environment variables
import { environment } from "../environments/environment";

/**
 * Servicio agnostico de otros componentes/servicios. Permite validar cualquier peticion a la API con un header de autenticacion.
 */
class AuthService {
    /**
     * Metodo privado. Interactua con getAuthorizationToken para guardar en el localStorage el nuevo token.
     * @returns {Promise<any>} El valor del nuevo token.
     */
    async setToken() {
        return new Promise((res) => {
            this.getAuthorizationToken().then((response) => {
                const tokenString = response.data.response;
                localStorage.setItem("token", tokenString);
                res(response.data);
            });
        });
    }

    /**
     * Metodo privado. Lee de localStorage el token, sino lo encuentra, lo genera a traves de setToken
     * @returns El valor del nuevo token.
     */
    async getToken() {
        let token = localStorage.getItem("token");

        if (token === null) {
            token = await this.setToken();
        }

        return token;
    }

    /**
     * Recupera un token de autenticacion del servidor.
     * @returns Devuelve la peticion post para recuperar el token del servidor.
     */
    getAuthorizationToken() {
        const request = environment.API_PLANTILLA + "/Auth/Login";

        const credentials = {
            userName: "rey",
            password: "7839",
        };

        return axios.post(request, credentials);
    }

    /**
     * Envuelve la peticion proveyendola de un header de autenticacion.
     * @param {Function} callback Funcion de la peticion del usuario.
     * @param {any[]} args Argumentos para la funcion pasada por parametro.
     * @returns Devuelve una copia de la funcion de la peticion original del usuario con el header de autenticacion.
     */
    async authInterceptor(callback, ...args) {
        const token = await this.getToken();

        const config = {
            headers: {
                Authorization: "bearer " + token,
            },
        };

        const _callback = callback;

        callback = () => {
            return _callback(...args, config);
        };

        return callback;
    }
}

const singletonInstance = new AuthService();

Object.freeze(singletonInstance);

export default singletonInstance;

import axios from "axios";
import { environment } from "@/environments/environment";

export class AuthService {
    /**
     * @param user Objecto usuario
     */
    setUser(user) {
        localStorage.setItem("user", JSON.stringify(user));
    }

    /**
     * Cerrar sesion
     */
    logout(router) {
        localStorage.removeItem("user");
        localStorage.removeItem("token");
        router.push(["/login"]);
    }

    /**
     * Login
     * @param credentials Objecto con las credenciales
     * @returns
     */
    login(credentials) {
        this.getAuthorizationToken(credentials).then((response) => {
            if (response) {
                const tokenString = response.data.response;
                localStorage.setItem("user", JSON.stringify(credentials.email));
                this.setAuthorizationToken(tokenString);
            }
        });
    }

    /**
     * Register
     * @param {User} credentials Objecto con el nuevo usuario
     * @returns
     */
    register(credentials) {
        return new Promise((res) => {
            const request =
                environment.API_TIENDAS + "/api/Manage/RegistroUsuario";

            axios.post(request, credentials).then(() => {
                const tokenCredentials = {
                    email: credentials.email,
                    password: credentials.pass,
                };

                localStorage.setItem(
                    "user",
                    JSON.stringify(tokenCredentials.email)
                );

                this.getAuthorizationToken(tokenCredentials).then((res) => {
                    const tokenString = res.data.response;
                    localStorage.setItem("token", tokenString);
                });
            });

            res();
        });
    }

    /**
     * Metodo privado. Interactua con getAuthorizationToken para guardar en el localStorage el nuevo token.
     * @returns El valor del nuevo token.
     */
    getLocalToken() {
        return new Promise((res) => {
            this.checkUser().then((user) => {
                if (user) {
                    res(localStorage.getItem("token"));
                }
            });
        });
    }

    /**
     * Recupera un token de autenticacion del servidor.
     * @returns Devuelve la peticion post para recuperar el token del servidor.
     */
    getAuthorizationToken(credentials) {
        const request = environment.API_TIENDAS + "/api/Manage/Login";
        return axios.post(request, credentials);
    }

    /**
     * Recupera un token de autenticacion del servidor.
     * @returns Devuelve la peticion post para recuperar el token del servidor.
     */
    setAuthorizationToken(tokenString) {
        localStorage.setItem("token", tokenString);
    }

    /**
     * Metodo privado. Lee de localStorage el user, sino lo encuentra, redirige a login.
     * @returns El valor del nuevo token.
     */
    async checkUser() {
        const user = localStorage.getItem("user");

        if (user === null) {
            return null;
        }

        const parsedUser = JSON.parse(user);

        return parsedUser;
    }

    /**
     * Envuelve la peticion proveyendola de un header de autenticacion.
     * @param {Function} callback Funcion de la peticion del usuario.
     * @param {any[]} args Argumentos para la funcion pasada por parametro.
     * @returns Devuelve una copia de la funcion de la peticion original del usuario con el header de autenticacion.
     */
    async authInterceptor(callback, ...args) {
        const token = await this.getLocalToken();

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

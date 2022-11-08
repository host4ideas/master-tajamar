import axios from "axios";

class CochesService {
    #urlCoches = "https://apicochespaco.azurewebsites.net";

    getCoches3() {
        const request = this.#urlCoches + "/webresources/coches";
        return axios
            .get(request)
            .then((res) => {
                return res.data;
            })
            .catch((error) => {
                console.log(error.message);
            });
    }

    getCoches2() {
        return new Promise((resolve, reject) => {
            const request = this.#urlCoches + "/webresources/coches";
            axios
                .get(request)
                .then((res) => {
                    resolve(res.data);
                })
                .catch((error) => {
                    reject(error.message);
                });
        });
    }

    async getCoches1() {
        const request = this.#urlCoches + "/webresources/coches";
        const response = await axios.get(request);
        return response.data;
    }
}

const singletonInstance = new CochesService();

Object.freeze(singletonInstance);

export default singletonInstance;

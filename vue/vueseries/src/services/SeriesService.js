import axios from "axios";

/**
 * @typedef {Object} Personaje
 * @property
 */

//  {
// 	"idPersonaje": 0,
// 	"nombre": "string",
// 	"imagen": "string",
// 	"idSerie": 0
// 	}

class SeriesService {
    #urlSeries = "https://apiseriespersonajes.azurewebsites.net/";

    async getSeries() {
        try {
            const request = this.#urlSeries + "/api/Series";

            const res = await axios.get(request);
            return res.data;
        } catch (error) {
            console.error(error);
        }
    }

    async findSerie(serieId) {
        try {
            const request = this.#urlSeries + `/api/Series/${serieId}`;
            const res = await axios.get(request);
            return res.data;
        } catch (error) {
            console.error(error);
        }
    }

    async updateSerie(newSerie) {
        try {
            const request = this.#urlSeries + `/api/Series`;

            await axios.put(request, newSerie);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    async createSerie(newSerie) {
        try {
            const request = this.#urlSeries + `/api/Series`;

            await axios.post(request, newSerie);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    async deleteSerie(serieId) {
        try {
            const request = this.#urlSeries + `/api/Series/${serieId}`;

            await axios.delete(request);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    async getPersonajes() {
        const request = this.#urlSeries + "/api/Personajes";

        const res = await axios.get(request);
        return res.data;
    }

    async getPersonajesSerie(serieId) {
        try {
            const request =
                this.#urlSeries + `/api/Series/PersonajesSerie/${serieId}`;

            const res = await axios.get(request);
            return res.data;
        } catch (error) {
            console.error(error);
        }
    }

    /**
     *
     * @param {Personaje} newPersonaje
     * @returns Personaje
     */
    async updatePersonaje(newPersonaje) {
        try {
            const request = this.#urlSeries + "/api/Personajes";

            await axios.put(request, newPersonaje);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    /**
     *
     * @param {Personaje} newPersonaje
     * @returns Personaje
     */
    async createPersonaje(newPersonaje) {
        try {
            const request = this.#urlSeries + "/api/Personajes";

            await axios.post(request, newPersonaje);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    /**
     *
     * @param {Number} personajeId
     * @returns Personaje
     */
    async deletePersonaje(personajeId) {
        try {
            const request = this.#urlSeries + `/api/Personajes/${personajeId}`;

            await axios.delete(request);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }

    async changePersonajeSerie(idpersonaje, idserie) {
        try {
            const request =
                this.#urlSeries + `/api/Personajes/${idpersonaje}/${idserie}`;

            await axios.put(request);
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }
}

const singletonInstance = new SeriesService();

Object.freeze(singletonInstance);

export default singletonInstance;

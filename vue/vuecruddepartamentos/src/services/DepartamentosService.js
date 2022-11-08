import axios from "axios";

class DepartamentosService {
    #urlDepartamentos = "https://apicruddepartamentoscore.azurewebsites.net";

    async getDepartamentos() {
        try {
            const request = this.#urlDepartamentos + "/api/Departamentos";

            const response = await axios.get(request);

            return response.data;
        } catch (error) {
            console.error(error);
        }
    }

    async findDepartamento(idDepartamento) {
        try {
            const request =
                this.#urlDepartamentos + `/api/Departamentos/${idDepartamento}`;

            const response = await axios.get(request);

            return response.data;
        } catch (error) {
            console.error(error);
        }
    }

    async updateDepartamento(departamento) {
        try {
            const request = this.#urlDepartamentos + `/api/Departamentos/`;

            await axios.put(request, departamento);

            console.log(
                `Departamento ${JSON.stringify(departamento)} actualizado`
            );
        } catch (error) {
            console.error(error);
        }
    }

    async createDepartamento(departamento) {
        try {
            const request = this.#urlDepartamentos + `/api/Departamentos/`;

            await axios.post(request, departamento);

            console.log(`Departamento ${JSON.stringify(departamento)} añadido`);
        } catch (error) {
            console.error(error);
        }
    }

    async deleteDepartamento(idDepartamento) {
        try {
            const request =
                this.#urlDepartamentos + `/api/Departamentos/${idDepartamento}`;
            await axios.delete(request);

            console.log(`Departamento ${idDepartamento} borrado`);
        } catch (error) {
            console.error(error);
        }
    }
}

const singletonInstance = new DepartamentosService();

Object.freeze(singletonInstance);

export default singletonInstance;

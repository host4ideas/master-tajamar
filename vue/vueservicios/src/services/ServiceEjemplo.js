class ServiceEjemplo {
    getSaludo(nombre) {
        return "Welcome to my service " + nombre;
    }
}

const singletonInstance = new ServiceEjemplo();

Object.freeze(singletonInstance);

export default singletonInstance;

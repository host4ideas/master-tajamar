<template>
    <section>
        <h1>Directivas</h1>

        <div v-if="series.length > 0">
            <ul>
                <li v-for="serie in series" :key="series.indexOf(serie)">
                    {{ serie }}
                </li>
            </ul>
        </div>

        <label for="inputNumero">Introduzca un número</label>
        <input type="text" id="inputNumero" v-model="numero" />
        <br />
        <h3 v-if="numero > 0" style="color: green">Número mayor que 0</h3>
        <h3 v-else-if="numero < 0" style="color: red">Número menor que 0</h3>

        <label for="inputNombre">Introduzca un nombre</label>
        <input type="text" id="inputNombre" v-model="nombre" />
        <br />
        <h3 v-if="nombre.length > 0" style="color: green">Nombre válido</h3>
        <h3 v-else-if="nombre.length <= 0" style="color: red">
            Introduce un nombre
        </h3>

        <label for="inputEdad">Introduzca una edad</label>
        <input type="text" id="inputEdad" v-model="edad" />
        <br />
        <h3 v-if="edad > 0" style="color: green">Edad mayor que 0</h3>
        <h3 v-else-if="edad <= 0" style="color: red">Edad no válida</h3>

        <h2>Número: {{ numero }}</h2>
        <h2>Nombre: {{ nombre }}</h2>
        <h2>Edad: {{ edad }}</h2>

        <h4><em>Data ($data):</em> {{ $data }}</h4>
    </section>
</template>

<script>
export default {
    name: "DirectivasPage",
    data() {
        return {
            numero: 0,
            nombre: "",
            edad: 0,
            series: [
                "Futurama",
                "Suits",
                "Padre de Familia",
                "The Mandalorian",
                "House",
            ],
        };
    },
};
</script>

<style scoped>
h1 {
    color: orange;
}
</style>

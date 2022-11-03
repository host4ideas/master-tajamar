<template>
    <section>
        <h1>Filters</h1>
        <h2>Minúsculas: {{ nombre }}</h2>
        <h2>Mayúsculas: {{ $filters.mayusculas(nombre) }}</h2>

        <button @click="cambiarNombre">Cambiar nombre</button>
    </section>
</template>

<script>
export default {
    name: "FiltersPage",
    data() {
        return {
            nombre: this.$variables.nombre,
        };
    },
    methods: {
        cambiarNombre() {
            console.log("test");
            if (this.$variables.nombre === "juan") {
                this.$variables.nombre = "pepe";
                this.nombre = this.$variables.nombre;
            } else {
                this.$variables.nombre = "juan";
                this.nombre = this.$variables.nombre;
            }
        },
    },
};
</script>

<style></style>

<template>
    <section>
        <h1>{{ this.saludo }}</h1>
        <button @click="cambiarSaludo">Cambiar saludo</button>
    </section>
</template>

<script>
export default {
    name: "CicloVidaPage",
    data() {
        return {
            saludo: "Hoy es juernes.",
        };
    },
    methods: {
        cambiarSaludo() {
            this.saludo = "Hoy es jueves.";
        },
    },
    mounted() {
        console.log("Componente montado");
    },
    unmounted() {
        console.log("Componente destruido");
    },
    updated() {
        console.log("Componente modificado");
    },
};
</script>

<style scoped> 
    h1 {
        color: brown;
    }
</style>

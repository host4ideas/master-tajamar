<template>
    <div>
        <h1 style="color: red">Hijo deportes V2</h1>
        <h2>Deporte: {{ deporte }}</h2>
        <button @click="marcarFavorito">Marcar favorito</button>
    </div>
</template>

<script>
export default {
    props: {
        deporte: String,
    },
    methods: {
        marcarFavorito() {
            this.$emit("response", this.deporte);
        },
    },
};
</script>

<template>
    <div>
        <h1>Hijo Numero</h1>
        <h3>Valor: {{ valor }}</h3>
        <button @click="enviarValor">Sumar</button>
    </div>
</template>

<script>
export default {
    props: {
        valor: Number,
    },
    methods: {
        enviarValor() {
            this.$emit("response", this.valor);
        },
    },
};
</script>

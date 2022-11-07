<template>
    <div>
        <h1>Doble numero por parametro</h1>
        <h2 v-if="num">{{ num }} X 2 = {{ num * 2 }}</h2>
        <h2 v-else>No hay parámetros</h2>
        <button type="button" @click="redirectToHome">Volver a home</button>
    </div>
</template>

<script>
export default {
    data() {
        return {
            num: null,
        };
    },
    watch: {
        "$route.params.num"(newVar, oldVar) {
            if (oldVar !== newVar) {
                this.num = newVar;
            }
        },
    },
    mounted() {
        this.num = this.$route.params?.num;
    },
    methods: {
        redirectToHome() {
            this.$router.push("/home");
        },
    },
};
</script>

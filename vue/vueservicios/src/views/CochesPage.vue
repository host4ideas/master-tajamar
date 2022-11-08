<template>
    <div>
        <h1>Página coches</h1>
        <div v-for="coche in coches" :key="coche.idcoche">
            <h2 style="color: blue">{{ coche.marca }}, {{ coche.modelo }}</h2>
            <h3 style="color: red">{{ coche.conductor }}</h3>
            <img :src="coche.imagen" alt="Coche" width="150" />
        </div>
    </div>
</template>

<script>
import cochesService from "../services/CochesService";

export default {
    data() {
        return {
            coches: [],
        };
    },
    inject: ["urlCoches"],
    compatConfig: { MODE: 3 },
    methods: {
        async loadCoches() {
            this.coches = await cochesService.getCoches2();
        },
    },
    mounted() {
        this.loadCoches();
    },
};
</script>

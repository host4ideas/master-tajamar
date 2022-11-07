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
import axios from "axios";

export default {
    data() {
        return {
            coches: [],
        };
    },
    inject: ["urlCoches"],
    compatConfig: { MODE: 3 },
    methods: {
        loadCoches() {
            const request = this.urlCoches + "/webresources/coches";

            axios.get(request).then((res) => {
                this.coches = res.data;
            });
        },
    },
    mounted() {
        this.loadCoches();
    },
};
</script>

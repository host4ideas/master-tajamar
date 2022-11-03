<template>
    <section>
        <h1>Propiedad conmutada</h1>
        <ul>
            <li v-for="game in juegos" :key="game">
                {{ game }}
            </li>
        </ul>
        <ul>
            <li v-for="game in juegosRojos" :key="game" v-html="game" />
        </ul>
        <button @click="getJuegosAzules()">Toggle juegos azules</button>
        <ul>
            <li v-for="game in juegosAzules" :key="game" v-html="game"></li>
        </ul>
    </section>
</template>

<script>
export default {
    name: "ConmutadaPage",
    data() {
        return {
            juegos: [
                "Doom Eternal",
                "WoW",
                "Battlefield",
                "COD",
                "Warzone 2100",
            ],
            juegosAzules: [],
        };
    },
    computed: {
        juegosRojos() {
            return this.juegos.map((juego) => {
                return `<span style='color:red;'>${juego}</span>`;
            });
        },
    },
    methods: {
        getJuegosAzules() {
            if (this.juegosAzules.length < 1) {
                this.juegosAzules = this.juegos.map((juego) => {
                    return `<span style='color:blue;'>${juego}</span>`;
                });
            } else {
                this.juegosAzules.splice(0);
            }
        },
    },
};
</script>

<style scoped>
h1 {
    color: black;
}
</style>

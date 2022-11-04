<template>
    <div>
        <h1>Padre Numeros</h1>
        <h2>Suma total: {{ sumaTotal }}</h2>
        <ul>
            <li v-for="numero in numsRandom" :key="numero">
                <HijoNumero @response="sumar" :valor="numero" />
            </li>
        </ul>
    </div>
</template>

<script>
import HijoNumero from "./HijoNumero.vue";

export default {
    components: {
        HijoNumero,
    },
    data() {
        const numsRandom = [];

        for (let i = 0; i < 10; i++) {
            numsRandom.push(Math.floor(Math.random() * 100));
        }

        return {
            sumaTotal: 0,
            numsRandom: numsRandom,
        };
    },
    methods: {
        sumar(numero) {
            this.sumaTotal += numero;
        },
    },
};
</script>

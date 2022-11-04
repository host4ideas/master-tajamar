<template>
    <div>
        <h1>Padre Numeros V2</h1>
        <h2>Suma total: {{ data.sumaTotal }}</h2>
        <ul>
            <li v-for="numero in data.numsRandom" :key="numero">
                <HijoNumero @response="sumar" :valor="numero" />
            </li>
        </ul>
    </div>
</template>

<script setup>
import HijoNumero from "./HijoNumero.vue";

import { reactive } from "vue";

const numsRandom = [];

for (let i = 0; i < 10; i++) {
    numsRandom.push(Math.floor(Math.random() * 100));
}

const data = reactive({
    sumaTotal: 0,
    numsRandom: numsRandom,
});

const sumar = (numero) => {
    data.sumaTotal += numero;
};
</script>

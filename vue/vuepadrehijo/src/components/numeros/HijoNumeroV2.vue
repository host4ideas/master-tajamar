<template>
    <div>
        <h1>Hijo Numero V2</h1>
        <h3>Valor: {{ props.valor }}</h3>
        <button @click="enviarValor">Sumar</button>
    </div>
</template>

<script setup>
import { defineEmits, defineProps } from "vue";

const props = defineProps({
    valor: Number,
});

const emit = defineEmits(["response"]);

const enviarValor = () => {
    emit("response", props.valor);
};
</script>

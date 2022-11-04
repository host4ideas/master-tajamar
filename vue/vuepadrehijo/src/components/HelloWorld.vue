<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <h2>{{ data.mensaje }}</h2>
        <button @click="cambiarMensaje">Cambiar mensaje</button>
    </div>
</template>

<script setup>
import { defineProps, reactive } from "vue";

defineProps({
    msg: String,
});

const data = reactive({
    mensaje: "hola",
});

const cambiarMensaje = () => {
    if (data.mensaje === "hola") {
        data.mensaje = "adiós";
    } else {
        data.mensaje = "hola";
    }
};
</script>

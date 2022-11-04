<template>
    <div>
        <h1 style="color: red">Hijo deportes</h1>
        <h2>Deporte: {{ deporte }}</h2>
        <button @click="marcarFavorito">Marcar favorito</button>
    </div>
</template>

<script setup>
import { defineProps, defineEmits } from "vue";

const props = defineProps({
    deporte: String,
});

const emit = defineEmits(["response"]);

const marcarFavorito = () => {
    emit("response", props.deporte);
};
</script>

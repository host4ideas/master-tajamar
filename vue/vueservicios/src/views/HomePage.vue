<template>
    <div>
        <h1>Home</h1>
        <h2>{{ data.saludo }}</h2>
    </div>
</template>

<script setup>
import serviceEjemplo from "../services/ServiceEjemplo";
import { reactive, onMounted } from "vue";

const data = reactive({
    saludo: "",
});

onMounted(() => {
    data.saludo = serviceEjemplo.getSaludo("Felix");
});
</script>

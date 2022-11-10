<template>
    <MainLayout>
        <router-view></router-view>
    </MainLayout>
</template>

<script setup>
import MainLayout from "./layouts/MainLayout.vue";
import seriesService from "./services/SeriesService";
import { provide, ref, onMounted } from "vue";

const series = ref([]);
const updateSeries = async () => {
    const seriesData = await seriesService.getSeries();
    series.value = seriesData;
};

provide("series", {
    series,
    updateSeries,
});

const personajes = ref([]);
const updatePersonajes = async () => {
    const personajesData = await seriesService.getPersonajes();
    personajes.value = personajesData;
};

provide("personajes", {
    personajes,
    updatePersonajes,
});

onMounted(() => {
    updateSeries();
    updatePersonajes();
});
</script>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}
</style>

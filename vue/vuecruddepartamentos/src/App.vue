<template>
    <MainLayout>
        <router-view></router-view>
    </MainLayout>
</template>

<script setup>
import MainLayout from "./layouts/MainLayout.vue";

import { onMounted, provide, ref } from "vue";
import departamentosService from "./services/DepartamentosService";

const departamentos = ref([]);

const updateDepartamentos = () => {
    departamentosService.getDepartamentos().then((deps) => {
        departamentos.value = deps;
    });
};

provide("departamentos", {
    departamentos,
    updateDepartamentos,
});

onMounted(() => {
    updateDepartamentos();
});
</script>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin: 30px;
}
</style>

<template>
    <nav>
        <router-link to="/tabla-multiplicar">Tabla de multiplicar</router-link>
        <router-link to="/tabla-multiplicar-filters">
            Tabla de multiplicar con filters
        </router-link>
    </nav>
</template>

<script>
export default {
    name: "MenuComponent",
};
</script>

<style scoped>
nav {
    display: flex;
    flex-direction: column;
}
</style>

<template>
    <ul>
        <li>
            <router-link to="/">Home</router-link>
        </li>
        <li>
            <router-link to="/cine">Cine</router-link>
        </li>
        <li>
            <router-link to="/musica">Musica</router-link>
        </li>
        <li>
            <router-link to="/ciclo-vida">Testear ciclo de vida</router-link>
        </li>
        <li>
            <router-link to="/directivas">Directivas</router-link>
        </li>
        <li>
            <router-link to="/propiedad-conmutada">
                Propiedad conmutada
            </router-link>
        </li>
        <li>
            <router-link to="/filters">Filters</router-link>
        </li>
        <li>
            <router-link to="/cualquierRuta">Ruta inventada</router-link>
        </li>
    </ul>
</template>

<script>
export default {
    name: "MenuComponent",
};
</script>

<style scoped>
ul {
    list-style: none;
}
</style>

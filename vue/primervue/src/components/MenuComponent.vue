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
            <router-link to="/cualquierRuta">Ruta inventada</router-link>
        </li>
    </ul>
</template>

<script>
export default {
    name: "MenuComponent",
};
</script>

<style></style>

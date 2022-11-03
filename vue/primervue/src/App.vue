<template>
    <div>
        <h1>ELEMENTO ESTÁTICO</h1>
        <PageLayout>
            <hr />
            <router-view></router-view>
            <hr />
        </PageLayout>
    </div>
</template>

<script>
import PageLayout from "./layouts/PageLayout.vue";

export default {
    name: "App",
    components: { PageLayout },
};
</script>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
}
img {
    width: 300px;
}
@import "./assets/css/global.css";
</style>

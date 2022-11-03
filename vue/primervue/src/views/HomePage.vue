<template>
    <section>
        <router-view></router-view>
        <h1>Home</h1>
        <img src="../assets/images/home.jpg" alt="" />
    </section>
</template>

<script>
export default {
    name: "HomePage",
};
</script>

<style scoped>
h1 {
    color: red;
}
</style>

<template>
    <div class="layout">
        <img alt="Vue logo" src="../assets/logo.png" />
        <div>
            <header>
                <MenuComponent />
                <!-- <MenuComponentV2 /> -->
                <!-- <MenuComponentV3 /> -->
            </header>
            <main>
                <slot></slot>
            </main>
        </div>
    </div>
</template>

<script setup>
import MenuComponent from "../components/MenuComponent.vue";
// import MenuComponentV2 from "../components/MenuComponentV2.vue";
// import MenuComponentV3 from "../components/MenuComponentV3.vue";
</script>

<style scoped>
.layout {
    margin: 60px;
}
</style>

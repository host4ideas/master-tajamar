<template>
    <div class="layout">
        <img alt="Vue logo" src="../assets/logo.png" />
        <div>
            <header>
                <MenuComponent />
            </header>
            <main>
                <slot></slot>
            </main>
        </div>
    </div>
</template>

<script setup>
import MenuComponent from "../components/MenuComponent.vue";
</script>

<style scoped>
.layout {
    margin: 60px;
}
</style>

<template>
    <div>
        <img alt="Vue logo" src="../assets/images/logo.png" />
        <MenuComponent />
        <hr />
        <main>
            <slot></slot>
        </main>
    </div>
</template>

<script setup>
import MenuComponent from "../components/MenuComponent.vue";
</script>

<template>
    <div>
        <header>
			<img alt="Vue logo" src="../assets/images/logo.png">
            <MenuComponent />
        </header>
        <slot></slot>
    </div>
</template>

<script setup>
import MenuComponent from "../components/MenuComponent.vue";
</script>

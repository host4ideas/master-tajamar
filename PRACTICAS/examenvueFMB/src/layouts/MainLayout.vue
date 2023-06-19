<template>
    <div>
        <header>
            <MenuComponent />
        </header>
        <main>
            <slot></slot>
        </main>
    </div>
</template>

<script setup>
import MenuComponent from "@/components/MenuComponent.vue";
</script>

<style></style>

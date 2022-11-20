<template>
    <div>
        <header>
            <MenuComp />
        </header>
        <main>
            <slot></slot>
        </main>
    </div>
</template>

<script setup>
import MenuComp from "../components/MenuComp.vue";
</script>

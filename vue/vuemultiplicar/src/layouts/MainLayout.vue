<template>
    <div>
        <header>
            <MenuComponent />
        </header>
        <slot></slot>
    </div>
</template>

<script>
import MenuComponent from "../components/MenuComponent.vue";

export default {
    name: "MainLayout",
    components: {
        MenuComponent,
    },
};
</script>

<style></style>

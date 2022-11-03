<template>
    <header>
        <h1>Header</h1>
        <MenuComponent />
    </header>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
export default {
    name: "HeaderComponent",
    components: {
        MenuComponent,
    },
};
</script>

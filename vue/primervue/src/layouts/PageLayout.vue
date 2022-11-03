<template>
    <div>
        <HeaderComponent />
        <slot />
        <FooterComponent />
    </div>
</template>

<script>
import HeaderComponent from "../components/HeaderComponent.vue"
import FooterComponent from "../components/FooterComponent.vue";

export default {
    name: "PageLayout",
    components: {
        HeaderComponent,
        FooterComponent,
    },
};
</script>

<template>
    <div>
        <h1>Doble numero por parametro</h1>
        <h2 v-if="data.num">{{ data.num }} X 2 = {{ data.num * 2 }}</h2>
        <h2 v-else>No hay parámetros</h2>
        <button type="button" @click="redirectToHome">Volver a home</button>
    </div>
</template>

<script setup>
import { onMounted, reactive, onUpdated } from "vue";
import { useRoute, useRouter } from "vue-router";

const route = useRoute();
const router = useRouter();

const data = reactive({
    num: route.params?.num,
});

const redirectToHome = () => {
    router.push("/home");
};

onMounted(() => {
    data.num = route.params?.num;
});

onUpdated(() => {
    data.num = route.params?.num;
});
</script>

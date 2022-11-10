<template>
    <div>
        <h1>Serie details</h1>
        <div class="card" style="width: 18rem">
            <img :src="data.serie?.imagen" class="card-img-top" alt="Serie" />
            <div class="card-body">
                <h5 class="card-title">{{ data.serie?.nombre }}</h5>
                <router-link
                    :to="`/personajes/${data.serie?.idSerie}`"
                    class="btn btn-success"
                >
                    Personajes
                </router-link>
            </div>
        </div>
    </div>
</template>

<script setup>
import seriesService from "../services/SeriesService";
import { onMounted, reactive, watchEffect } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();

const data = reactive({
    serie: {},
});

const loadSerie = async () => {
    if (route.params?.serieId) {
        const serie = await seriesService.findSerie(route.params?.serieId);
        data.serie = serie;
    }
};

onMounted(() => {
    loadSerie();
});

watchEffect(() => {
    loadSerie();
});
</script>

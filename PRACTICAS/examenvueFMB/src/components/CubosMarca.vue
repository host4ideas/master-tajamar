<template>
    <div>
        <h1 v-if="data.marca">Cubos de la marca: {{ data.marca }}</h1>
        <div class="card-group">
            <div class="card" v-for="cubo in data.cubos" :key="cubo">
                <img
                    width="300"
                    :src="cubo.imagen"
                    class="card-img-top"
                    alt=""
                />
                <div class="card-body">
                    <h5 class="card-title">{{ cubo.modelo }}</h5>
                    <p class="card-text">{{ cubo.precio }}</p>
                    <router-link
                        class="card-text btn btn-primary"
                        :to="'/cubos-detalles/' + cubo.idCubo"
                        routerLinkActive="router-link-active"
                    >
                        Detalles
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useRoute } from "vue-router";
import cubosService from "@/services/cubosService";

const data = reactive({
    marca: "",
    cubos: [],
});

const route = useRoute();

onMounted(() => {
    const marca = route.params.marca;

    data.marca = marca;

    cubosService.getCubosMarca(marca).then((res) => {
        data.cubos = res.data;
    });
});
</script>

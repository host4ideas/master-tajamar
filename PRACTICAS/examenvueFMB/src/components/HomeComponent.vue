<template>
    <div class="m-3">
        <div class="row row-cols-1 row-cols-md-2 g-4">
            <div class="col" v-for="cubo in data.cubos" :key="cubo">
                <div class="card">
                    <div class="card-body ,-3">
                        <img width="100" :src="cubo.imagen" alt="" />
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
    </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import cubosService from "@/services/cubosService";

const data = reactive({
    cubos: [],
});

onMounted(() => {
    cubosService.getCubos().then((res) => {
        data.cubos = res.data;
    });
});
</script>

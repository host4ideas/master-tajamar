<template>
    <div class="card-container">
        <div v-if="data.cubo" class="card mb-3" style="max-width: 540px">
            <div class="row g-0">
                <div class="col-md-4">
                    <img
                        width="300"
                        :src="data.cubo.imagen"
                        class="img-fluid rounded-start"
                        alt="..."
                    />
                </div>
                <div class="col-md-8">
                    <div class="card-body">
                        <h5 class="card-title">{{ data.cubo.modelo }}</h5>
                        <p class="card-text">Precio: {{ data.cubo.precio }}</p>
                        <p class="card-text">
                            Valoración: {{ data.cubo.valoracion }}
                        </p>
                        <p class="card-text">Precio: {{ data.cubo.precio }}</p>
                        <p
                            class="card-text btn btn-danger"
                            @click="realizarCompra"
                            routerLinkActive="router-link-active"
                        >
                            Comprar modelo
                        </p>
                        <h5>Comentarios</h5>
                        <div
                            style="border: 1px solid black; border-radius: 5px"
                            v-for="comentario in data.comentarios"
                            :key="comentario"
                        >
                            <p class="card-text">
                                {{ comentario.comentario }}
                            </p>
                            <p class="card-text">
                                Fecha:
                                {{ comentario.fechaComentario.split("T")[0] }}
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import cubosService from "@/services/cubosService";
import authService from "@/services/authService";

const data = reactive({
    marca: "",
    cubo: {
        idCubo: "",
    },
    comentarios: [],
});

const route = useRoute();
const router = useRouter();

const realizarCompra = async () => {
    /*
      LLamamos al metodo auth para recoger la funcion copia provista del header.
      Para no perder el contexto de la peticion original, le damos el contexto del service al que pertenece.
    */
    const validatedCall = await authService.authInterceptor(
        cubosService.realizarCompra.bind(cubosService),
        data.cubo.idCubo
    );

    /*
        La funcion copia de auth es la misma que una peticion http.
        Si hay un código existente en localStorage, pero no es válido, devolverá un error 401 y se reseteara el token.
      */
    validatedCall().then(
        () => router.push("/compras-usuario"),
        (err) => {
            if (err.status == 401) router.push("/login");
        }
    );
};

onMounted(() => {
    const idcubo = route.params.idcubo;

    cubosService.findCubo(idcubo).then((res) => {
        data.cubo = res.data;
        cubosService
            .getComentariosCubo(data.cubo.idCubo.toString())
            .then((res) => {
                data.comentarios = res.data;
            });
    });
});
</script>

<style></style>

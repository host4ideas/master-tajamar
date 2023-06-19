<template>
    <div
        v-if="data.perfil"
        style="display: flex; justify-content: center"
        class="mt-5"
    >
        <div class="card" style="width: 18rem">
            <div class="card-body">
                <h5 class="card-title">Estás loggeado</h5>
                <p class="card-text">Email: {{ data.perfil.email }}</p>
                <p class="card-text">Nombre: {{ data.perfil.nombre }}</p>
            </div>
        </div>
    </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import cubosService from "@/services/cubosService";
import authService from "@/services/authService";
import { useRouter } from "vue-router";

const router = useRouter();

const data = reactive({
    perfil: {},
});

/**
 * Carga el perfil del usuario del servidor.
 */
const loadPerfil = async () => {
    /*
      LLamamos al metodo auth para recoger la funcion copia provista del header.
      Para no perder el contexto de la peticion original, le damos el contexto del service al que pertenece.
    */
    const validatedCall = await authService.authInterceptor(
        cubosService.getPerfilUsuario.bind(cubosService)
    );

    /*
      La funcion copia de auth es la misma que una peticion http.
      Si hay un código existente en localStorage, pero no es válido, devolverá un error 401 y se reseteara el token.
    */
    validatedCall().then(
        (res) => {
            data.perfil = res.data;
        },
        (err) => {
            if (err.status == 401) {
                authService.logout();
            }
        }
    );
};

onMounted(() => {
    authService.checkUser().then((user) => {
        if (!user) {
            router.push("/login");
        }
    });
    loadPerfil();
});
</script>

<style></style>

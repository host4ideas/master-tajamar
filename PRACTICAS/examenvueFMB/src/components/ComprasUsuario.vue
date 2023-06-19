<template>
    <table class="table">
        <thead>
            <tr>
                <th>Fecha del pedido</th>
                <th>ID Modelo</th>
                <th>ID Pedido</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="compra in data.compras" :key="compra">
                <td>
                    {{ compra.fechaPedido }}
                </td>
                <td>
                    {{ compra.idCubo }}
                </td>
                <td>
                    {{ compra.idPedido }}
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useRouter } from "vue-router";
import cubosService from "@/services/cubosService";
import authService from "@/services/authService";

const data = reactive({
    compras: [],
});

const router = useRouter();

/**
 * Carga las compras del usuario del servidor.
 */
const loadCompras = async () => {
    /*
      LLamamos al metodo auth para recoger la funcion copia provista del header.
      Para no perder el contexto de la peticion original, le damos el contexto del service al que pertenece.
    */
    const validatedCall = await authService.authInterceptor(
        cubosService.getComprasUsuario.bind(cubosService)
    );

    /*
      La funcion copia de auth es la misma que una peticion http.
      Si hay un código existente en localStorage, pero no es válido, devolverá un error 401 y se reseteara el token.
    */
    validatedCall().then(
        (res) => {
            data.compras = res.data;
        },
        (err) => {
            if (err.status == 401) router.push("/login");
        }
    );
};

onMounted(() => {
    loadCompras();
    authService.checkUser().then((user) => {
        if (!user) {
            router.push("/login");
        }
    });
});
</script>

<style></style>

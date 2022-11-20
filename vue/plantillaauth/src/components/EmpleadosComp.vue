<template>
    <div class="m-3">
        <table class="table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Apellido</th>
                    <th>Oficio</th>
                    <th>Salario</th>
                    <th>Director</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="empleado in data.empleados" :key="empleado">
                    <td>{{ empleado.idEmpleado }}</td>
                    <td>{{ empleado.apellido }}</td>
                    <td>{{ empleado.director }}</td>
                    <td>{{ empleado.oficio }}</td>
                    <td>{{ empleado.salario }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
// Vue
import { reactive, onMounted } from "vue";
// Services
import authService from "../services/authService";
import servicePlantilla from "../services/plantillaService";

const data = reactive({
    empleados: [],
});

/**
 * Carga los empleados del servidor. Actualiza la variable public plantilla para mostrar los empleados al usuario.
 */
async function loadEmpleados() {
    /*
      LLamamos al metodo auth para recoger la funcion copia provista del header.
      Para no perder el contexto de la peticion original, le damos el contexto del service al que pertenece.
    */
    const validatedCall = await authService.authInterceptor(
        servicePlantilla.getEmpleados
    );

    /*
      La funcion copia de auth es la misma que una peticion http.
      Si hay un código existente en localStorage, pero no es válido, devolverá un error 401 y se reseteara el token.
    */
    validatedCall().then(
        (res) => {
            data.empleados = res.data;
        },
        (err) => {
            if (err.response.status == 401)
                authService.setToken().then(() => loadEmpleados());
        }
    );
}

onMounted(() => {
    loadEmpleados();
});
</script>

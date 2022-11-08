<template>
    <div>
        <h1>Empleados por oficio</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>Apellido</th>
                    <th>Salario</th>
                    <th>Departemento</th>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="empleado in data.empleados"
                    :key="empleado.idEmpleado"
                >
                    <td>{{ empleado.apellido }}</td>
                    <td>{{ empleado.salario }}</td>
                    <td>{{ empleado.departamento }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
import { reactive, onMounted, watchEffect } from "vue";
import { useRoute } from "vue-router";
import empleadosService from "../services/EmpleadosService";

const route = useRoute();

// import { inject } from "vue";
// const urlEmpleados = inject("urlEmpleados");

const data = reactive({
    empleados: [],
});

const getEmpladosPorOficio = async () => {
    const oficio = route.params?.oficio;
    data.empleados = await empleadosService.getEmpleadosOficio(oficio);
};

onMounted(() => {
    getEmpladosPorOficio();
});

watchEffect(() => getEmpladosPorOficio());
</script>

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
import { reactive, inject, onMounted, watchEffect } from "vue";
import { useRoute } from "vue-router";
import axios from "axios";

const route = useRoute();

const urlEmpleados = inject("urlEmpleados");

const data = reactive({
    empleados: [],
});

const getEmpladosPorOficio = () => {
    const oficio = route.params?.oficio;

    const request = urlEmpleados + `/api/Empleados/EmpleadosOficio/${oficio}`;

    axios.get(request).then((res) => {
        data.empleados = res.data;
    });
};

onMounted(() => {
    getEmpladosPorOficio();
});

watchEffect(() => getEmpladosPorOficio());
</script>

<template>
    <div>
        <h1>Departamentos</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>Numero</th>
                    <th>Nombre</th>
                    <th>Localidad</th>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="departamento in departamentos"
                    :key="departamento.numero"
                    @click="handleClickDept(departamento.numero)"
                    style="cursor: pointer"
                >
                    <td>{{ departamento.numero }}</td>
                    <td>{{ departamento.nombre }}</td>
                    <td>{{ departamento.localidad }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
import { inject, onMounted } from "vue";
import { useRouter } from "vue-router";

const { departamentos, updateDepartamentos } = inject("departamentos");

const router = useRouter();

const handleClickDept = (numero) => {
    router.push(`/departamento/${numero}`);
};

onMounted(() => {
    updateDepartamentos();
});
</script>

<template>
    <div>
        <h1>Empleados</h1>
        <form @submit.prevent="handleForm" method="POST">
            <select
                class="form-control"
                name="select"
                id="selectEmpleado"
                v-model="data.empleadoID"
            >
                <option
                    v-for="empleado in data.empleados"
                    :key="empleado.idEmpleado"
                    :value="empleado.idEmpleado"
                >
                    {{ empleado.apellido }}
                </option>
            </select>
            <button type="submit" class="btn btn-primary m-3">
                <i class="bi bi-search"></i>
            </button>
        </form>

        <dl v-if="data.empleadoSeleccionado">
            <dt>Apellido</dt>
            <dd>{{ data.empleadoSeleccionado.apellido }}</dd>
            <dt>Oficio</dt>
            <dd>
                <router-link
                    :to="`/empleados-oficio/${data.empleadoSeleccionado.oficio}`"
                >
                    {{ data.empleadoSeleccionado.oficio }}
                </router-link>
            </dd>
            <dt>Salario</dt>
            <dd>{{ data.empleadoSeleccionado.salario }}</dd>
            <dt>Departamento</dt>
            <dd>{{ data.empleadoSeleccionado.departamento }}</dd>
        </dl>
    </div>
</template>

<script setup>
import { inject } from "vue";
import { reactive, onMounted } from "vue";
import axios from "axios";

const urlEmpleados = inject("urlEmpleados");

const data = reactive({
    empleados: [],
    empleadoID: null,
    empleadoSeleccionado: null,
});

onMounted(() => {
    const request = urlEmpleados + "/api/Empleados";
    axios
        .get(request)
        .then((res) => {
            data.empleados = res.data;
        })
        .catch((error) => {
            console.error(error);
        });
});

const handleForm = () => {
    /*
		{
			"idEmpleado": 7782,
			"apellido": "Cerezo",
			"oficio": "DIRECTOR",
			"salario": 9598,
			"departamento": 10
		}
	*/
    const request = urlEmpleados + `/api/Empleados/${data.empleadoID}`;
    axios
        .get(request)
        .then((res) => {
            data.empleadoSeleccionado = res.data;
        })
        .catch((error) => {
            console.error(error);
        });
};
</script>

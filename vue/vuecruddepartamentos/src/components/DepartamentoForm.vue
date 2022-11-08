<template>
    <div>
        <button @click="backBtn" class="btn btn-outline-info mb-3">🔙</button>
        <form @submit.prevent="handleSubmit">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">
                    Numero
                </label>
                <input
                    :readonly="props.oldDepartamento ? true : false"
                    v-model="data.numero"
                    type="text"
                    class="form-control"
                    id="exampleInputEmail1"
                    aria-describedby="emailHelp"
                />
            </div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">
                    Nombre
                </label>
                <input
                    v-model="data.nombre"
                    type="text"
                    class="form-control"
                    id="exampleInputEmail1"
                    aria-describedby="emailHelp"
                />
            </div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">
                    Localidad
                </label>
                <input
                    v-model="data.localidad"
                    type="text"
                    class="form-control"
                    id="exampleInputEmail1"
                    aria-describedby="emailHelp"
                />
            </div>
            <button
                v-if="props.oldDepartamento"
                type="submit"
                class="btn btn-primary"
            >
                Actualizar departamento
            </button>
            <button v-else type="submit" class="btn btn-primary">
                Crear departamento
            </button>
        </form>
    </div>
</template>

<script setup>
import { defineProps, reactive, onMounted, watchEffect } from "vue";
import { useRouter } from "vue-router";
import departamentosService from "../services/DepartamentosService";

const router = useRouter();

const props = defineProps({
    oldDepartamento: Object,
});

const data = reactive({
    numero: props.oldDepartamento ? props.oldDepartamento.numero : null,
    nombre: props.oldDepartamento ? props.oldDepartamento.nombre : null,
    localidad: props.oldDepartamento ? props.oldDepartamento.localidad : null,
});

const updateFromProps = () => {
    if (props.oldDepartamento) {
        data.numero = props.oldDepartamento.numero;
        data.nombre = props.oldDepartamento.nombre;
        data.localidad = props.oldDepartamento.localidad;
    }
};

onMounted(() => {
    updateFromProps();
});

watchEffect(() => {
    updateFromProps();
});

const handleSubmit = () => {
    // Si tenemos el departamento por props, es que queremos actualizar un departamento existente
    if (props.oldDepartamento) {
        const nuevoDepartamento = {
            numero: parseInt(props.oldDepartamento.numero),
            nombre: data.nombre,
            localidad: data.localidad,
        };
        console.log(nuevoDepartamento);
        departamentosService.updateDepartamento(nuevoDepartamento).then(() => {
            router.push("/");
        });
    } else {
        const nuevoDepartamento = {
            numero: parseInt(data.numero),
            nombre: data.nombre,
            localidad: data.localidad,
        };
        departamentosService.createDepartamento(nuevoDepartamento).then(() => {
            router.push("/");
        });
    }
};

const backBtn = () => {
    if (props.oldDepartamento) {
        router.push(`/departamento/${data.numero}`);
    } else {
        router.push("/");
    }
};
</script>

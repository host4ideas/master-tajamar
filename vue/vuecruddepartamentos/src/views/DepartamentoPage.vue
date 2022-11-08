<template>
    <div>
        <h1>Departamento: {{ numero }}</h1>
        <button @click="backBtn" class="btn btn-outline-info">🔙</button>
        <table class="table">
            <thead>
                <tr>
                    <th>Numero</th>
                    <th>Nombre</th>
                    <th>Localidad</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{{ departamento.numero }}</td>
                    <td>{{ departamento.nombre }}</td>
                    <td>{{ departamento.localidad }}</td>
                    <td>
                        <div class="btn-group">
                            <button
                                class="btn btn-warning"
                                @click="handleModificarBtn(departamento.numero)"
                            >
                                ✏️
                            </button>
                            <button
                                class="btn btn-danger"
                                @click="handleBorrarBtn(departamento.numero)"
                            >
                                🗑️
                            </button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import departamentosService from "../services/DepartamentosService";

export default {
    data() {
        return {
            departamento: {},
            numero: this.$route.params?.numero,
        };
    },
    mounted() {
        // Numero not undefined
        if (this.numero) {
            departamentosService.findDepartamento(this.numero).then((dept) => {
                this.departamento = dept;
            });
        }
    },
    methods: {
        handleModificarBtn(numero) {
            this.$router.push(`/modificar-departamento/${numero}`);
        },
        handleBorrarBtn(numero) {
            departamentosService.deleteDepartamento(numero).then(() => {
                this.$router.push(`/`);
            });
        },
        backBtn() {
            this.$router.push(`/`);
        },
    },
    watch: {
        // Watch url params for changes
        "$route.params.numero"(newVar, oldVar) {
            if (oldVar !== newVar) {
                departamentosService.findDepartamento(newVar).then((dept) => {
                    this.departamento = dept;
                });
            }
        },
    },
};
</script>

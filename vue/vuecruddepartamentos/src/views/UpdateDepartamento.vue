<template>
    <div>
        <h1>Actualizar departamento</h1>
        <DepartamentoForm :oldDepartamento="oldDepartamento" />
    </div>
</template>

<script>
import DepartamentoForm from "../components/DepartamentoForm";
import departamentosService from "../services/DepartamentosService";

export default {
    components: {
        DepartamentoForm: DepartamentoForm,
    },
    data() {
        return {
            oldDepartamento: null,
            numero: this.$route.params?.numero,
        };
    },
    mounted() {
        // Numero not undefined
        if (this.numero) {
            departamentosService.findDepartamento(this.numero).then((dept) => {
                this.oldDepartamento = dept;
            });
        }
    },
};
</script>

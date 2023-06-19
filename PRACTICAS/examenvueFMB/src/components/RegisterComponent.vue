<template>
    <form class="m-5" @submit.prevent="register">
        <label>Email</label>
        <input
            type="email"
            class="form-control"
            name="cajaEmail"
            required
            v-model="data.email"
        /><br />
        <label>Nombre</label>
        <input
            type="text"
            class="form-control"
            name="cajaNombre"
            required
            v-model="data.nombre"
        /><br />
        <label>Contraseña</label>
        <input
            type="password"
            class="form-control"
            name="cajaPass"
            v-model="data.pass"
            required
        /><br />
        <button type="submit" class="btn btn-info">Login</button>
    </form>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useRouter } from "vue-router";
import authService from "@/services/authService";

const router = useRouter();

const data = reactive({
    nombre: "",
    email: "",
    pass: "",
});

const register = () => {
    if (data.email && data.pass && data.nombre) {
        const newUser = {
            idUsuario: 0,
            nombre: data.nombre,
            email: data.email,
            pass: data.pass,
        };

        authService.register(newUser).then(() => {
            router.push("/login");
        });
    }
};

onMounted(() => {
    authService.checkUser().then((user) => {
        if (user) {
            router.push("/perfil");
        }
    });
});
</script>

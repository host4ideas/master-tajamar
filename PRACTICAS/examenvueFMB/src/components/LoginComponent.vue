<template>
    <form class="m-5" @submit.prevent="login">
        <label>Usuario</label>
        <input
            type="text"
            class="form-control"
            name="cajaUsuario"
            required
            v-model="data.email"
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
    email: "",
    pass: "",
});

const login = () => {
    if (data.email && data.pass) {
        const loginUser = {
            email: data.email,
            password: data.pass,
        };

        authService.login(loginUser);
        router.push("/perfil");
    }
};

onMounted(() => {
    authService.checkUser().then((user) => {
        if (user) {
            router.push("/perfil");
        } else {
            router.push("/login");
        }
    });
});
</script>

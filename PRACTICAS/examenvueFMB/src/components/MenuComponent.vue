<template>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <router-link
                class="navbar-brand"
                to="/"
                routerLinkActive="router-link-active"
            >
                <img width="100" src="../assets/images/home-icon.png" alt="" />
            </router-link>
            <button
                class="navbar-toggler"
                type="button"
                data-bs-toggle="collapse"
                data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent"
                aria-expanded="false"
                aria-label="Toggle navigation"
            >
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item dropdown">
                        <a
                            class="nav-link dropdown-toggle"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                        >
                            Marcas
                        </a>
                        <ul class="dropdown-menu">
                            <li v-for="marca in data.marcas" :key="marca">
                                <router-link
                                    :to="'/cubos-marca/' + marca"
                                    class="dropdown-item"
                                >
                                    {{ marca }}
                                </router-link>
                            </li>
                        </ul>
                    </li>
                    <li class="nav-item dropdown">
                        <a
                            class="nav-link dropdown-toggle"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                        >
                            Modelos
                        </a>
                        <ul class="dropdown-menu">
                            <li v-for="cubo in data.cubos" :key="cubo">
                                <router-link
                                    class="dropdown-item"
                                    :to="'/cubos-detalles/' + cubo.idCubo"
                                >
                                    {{ cubo.modelo }}
                                </router-link>
                            </li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/compras-usuario">
                            Ver tus compras
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/login">
                            Login
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/register">
                            Register
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <a
                            style="cursor: pointer"
                            class="nav-link"
                            @click="logout"
                        >
                            Logout
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script setup>
import cubosService from "@/services/cubosService";
import authService from "@/services/authService";
import { onMounted, reactive } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();

const data = reactive({
    marcas: [],
    cubos: [],
});

const logout = () => {
    authService.logout();
    router.push("/");
};

onMounted(() => {
    cubosService.getMarcas().then((res) => (data.marcas = res.data));
    cubosService.getCubos().then((res) => (data.cubos = res.data));
});
</script>

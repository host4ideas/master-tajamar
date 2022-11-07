<template>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
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
                    <li class="nav-item">
                        <router-link
                            class="nav-link active"
                            aria-current="page"
                            to="/coches"
                        >
                            Coches
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link
                            class="nav-link active"
                            aria-current="page"
                            to="/empleados"
                        >
                            Empleados
                        </router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <a
                            class="nav-link dropdown-toggle"
                            href="#"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                        >
                            Oficios
                        </a>
                        <!-- <li v-for="oficio in data.oficios" :key="oficio">
                                <router-link
                                    class="dropdown-item"
                                    :to="`/empleados-oficio/${oficio}`"
                                >
                                    {{ oficio }}
                                </router-link>
                            </li> -->
                        <ul class="dropdown-menu" v-html="oficiosLinks"></ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script setup>
import { onMounted, inject, reactive, computed } from "vue";
import axios from "axios";

const urlEmpleados = inject("urlEmpleados");

const data = reactive({
    oficios: [],
});

const getOficios = () => {
    const request = urlEmpleados + `/api/Empleados/oficios`;

    axios.get(request).then((res) => {
        data.oficios = res.data;
    });
};

const oficiosLinks = computed(() => {
    return data.oficios
        .map((oficio) => {
            return `
                <li v-for="oficio in data.oficios" :key="oficio">
                    <router-link
                        class="dropdown-item"
                        :to="/empleados-oficio/${oficio}"
                    >
                        ${oficio}
                    </router-link>
                </li>
            `;
        })
        .join("");
});

onMounted(() => {
    getOficios();
});
</script>

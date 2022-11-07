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
                    <li class="nav-item" id="links">
                        {{ oficiosLinks }}
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script>
import axios from "axios";
// import { createVNode } from "vue";
import { compile, h } from "vue/dist/vue.esm-bundler.js";

export default {
    data() {
        return {
            oficios: [],
            compile: compile,
            h: h,
        };
    },
    inject: ["urlEmpleados"],
    methods: {
        getOficios() {
            const request = this.urlEmpleados + `/api/Empleados/oficios`;

            axios.get(request).then((res) => {
                this.oficios = res.data;
            });
        },
    },
    computed: {
        oficiosLinks() {
            const links = this.oficios.map((oficio) => {
                return h(
                    compile(
                        `<router-link to="/empleados-oficio/${oficio}">${oficio}</router-link>`
                    )
                );
            });
            console.log(links);
            return links;
        },
    },
    mounted() {
        this.getOficios();
    },
};
</script>

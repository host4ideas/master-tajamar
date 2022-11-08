<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/"> CRUD </router-link>
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
                            class="nav-link"
                            aria-current="page"
                            to="/"
                        >
                            Home
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link
                            class="nav-link"
                            aria-current="page"
                            to="/crear-departamento"
                        >
                            Crear departamento
                        </router-link>
                    </li>
                    <li class="nav-item dropdown">
                        <router-link
                            v-if="departamentos.length > 0"
                            class="nav-link dropdown-toggle"
                            to="#"
                            id="navbarDropdown"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                        >
                            Departamentos
                        </router-link>
                        <div v-else class="spinner-border mt-1" role="status">
                            <span class="visually-hidden">Loading...</span>
                        </div>
                        <ul
                            class="dropdown-menu"
                            aria-labelledby="navbarDropdown"
                        >
                            <li
                                v-for="departamento in departamentos"
                                :key="departamento.numero"
                            >
                                <router-link
                                    class="dropdown-item"
                                    :to="`/departamento/${departamento.numero}`"
                                >
                                    {{ departamento.nombre }}
                                </router-link>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script setup>
import { inject } from "vue";

const { departamentos } = inject("departamentos");
</script>

<template>
    <div>
        <h1>
            Personajes serie
            {{
                series.filter(
                    (serie) => route.params?.serieId == serie.idSerie
                )[0]?.nombre
            }}
        </h1>
        <button class="btn btn-outline-info" @click="handleBackBtn">🔙</button>
        <table>
            <thead>
                <tr>
                    <th>Personaje</th>
                    <th>Imagen</th>
                    <th>Options</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="personaje in data.personajes" :key="personaje">
                    <td>{{ personaje.nombre }}</td>
                    <td>
                        <img
                            :src="personaje.imagen"
                            alt="Personaje"
                            width="200"
                        />
                    </td>
                    <td class="btn-group">
                        <button
                            class="btn btn-warning"
                            @click="handleModificarBtn(personaje.idPersonaje)"
                        >
                            ✏️
                        </button>
                        <button
                            class="btn btn-danger"
                            @click="handleBorrarBtn(personaje.idPersonaje)"
                        >
                            🗑️
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
import { onMounted, reactive, inject } from "vue";
import { useRoute, useRouter } from "vue-router";
import seriesService from "../services/SeriesService";
import Swal from "sweetalert2";

const route = useRoute();
const router = useRouter();

const data = reactive({
    personajes: [],
});

const { series } = inject("series");

const getPersonajesSerie = async () => {
    const personajes = await seriesService.getPersonajesSerie(
        route.params?.serieId
    );
    data.personajes = personajes;
};

const handleBorrarBtn = (idPersonaje) => {
    Swal.fire({
        title: "¿Estás seguro de que quieres borrar el personaje?",
        showDenyButton: true,
        confirmButtonText: "Borrar",
        denyButtonText: `Cancelar`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            seriesService.deletePersonaje(idPersonaje).then(() => {
                Swal.fire({
                    position: "top-end",
                    icon: "success",
                    title: "Personaje borrado",
                    showConfirmButton: false,
                    timer: 1500,
                });
                getPersonajesSerie();
            });
        } else if (result.isDenied) {
            Swal.fire("Personaje no borrado", "", "info");
        }
    });
};

const handleModificarBtn = (idPersonaje) => {
    router.push(`/modificar-personajes/${idPersonaje}`);
};

const handleBackBtn = () => {
    router.push(`/serie/${route.params?.serieId}`);
};

onMounted(() => {
    getPersonajesSerie();
});
</script>

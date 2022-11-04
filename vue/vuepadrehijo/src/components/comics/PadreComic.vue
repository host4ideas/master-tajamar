<template>
    <div>
        <h1>Padre comic</h1>

        <div>
            <HijoComic :isFav="true" :comic="favorito" />
        </div>

        <form @submit.prevent="crearComic()">
            <label for="inputTitulo">Titulo</label>
            <input type="text" id="inputTitulo" v-model="comicForm.titulo" />

            <label for="inputUrl">Imagen</label>
            <input type="text" id="inputUrl" v-model="comicForm.imagen" />

            <label for="inputDesc">Decripción</label>
            <input type="text" id="inputDesc" v-model="comicForm.descripcion" />

            <label for="inputAnyo">Año</label>
            <input type="text" id="inputAnyo" v-model="comicForm.year" />

            <button type="submit">Crear comic</button>
        </form>

        <div id="comics" v-for="(comic, index) in comics" :key="comic">
            <HijoComic
                @fav="seleccionarFav"
                @eliminar="eliminarComic"
                :isFav="false"
                :index="index"
                :comic="comic"
            />
        </div>
    </div>
</template>

<script>
import HijoComic from "./HijoComic.vue";
import comics from "../../assets/comics.json";

export default {
    components: {
        HijoComic,
    },
    data() {
        return {
            comics: comics,
            comicForm: {
                titulo: "",
                imagen: "",
                descripcion: "",
                year: "",
            },
            favorito: {},
        };
    },
    methods: {
        crearComic() {
            this.comics.push({ ...this.comicForm });
        },
        seleccionarFav(comic) {
            this.favorito = comic;
        },
        eliminarComic(index) {
            this.comics.splice(index, 1);
        },
    },
};
</script>

<style scoped>
@import "../../assets/css/comic.css";
</style>

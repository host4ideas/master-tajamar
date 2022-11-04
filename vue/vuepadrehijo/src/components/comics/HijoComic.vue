<template>
    <div>
        <div style="cursor: pointer" @click="borrarComic" title="Borrar comic">
            <p>{{ comic.titulo }}</p>
            <p :class="{ rojo: comic.year <= 2000, verde: comic.year > 2000 }">
                {{ comic.year }}
            </p>
            <img :src="comic.imagen" alt="" />
            <p>{{ comic.descripcion }}</p>
        </div>
        <button v-if="!isFav" @click="marcarFav">Favorito</button>
    </div>
</template>

<script>
export default {
    props: {
        isFav: Boolean,
        index: Number,
        comic: Object,
    },
    methods: {
        marcarFav() {
            this.$emit("fav", this.comic);
        },
        borrarComic() {
            this.$emit("eliminar", this.index);
        },
    },
};
</script>

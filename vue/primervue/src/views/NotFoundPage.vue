<template>
    <section>
        <router-view></router-view>
        <div class="hello">
            <h1>{{ this.msg }}</h1>
        </div>
    </section>
</template>

<script>
export default {
    name: "NotFoundPage",
    props: {
        msg: String,
    },
    data() {
        return {
            nombre: "Alumno",
            numero: 14,
            miArray: [],
        };
    },
};
</script>

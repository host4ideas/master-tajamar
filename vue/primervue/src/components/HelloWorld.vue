<template>
    <router-view></router-view>
    <div class="hello">
        <h1>{{this.msg}}</h1>
        <img src="../assets/images/home.jpg" alt="" />
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
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

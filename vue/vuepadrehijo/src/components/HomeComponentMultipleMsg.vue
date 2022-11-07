<template>
    <div class="hello">
        <h1>Home Multiple msg</h1>
        <h2>{{ msg }}</h2>
    </div>
</template>

<script>
export default {
    data() {
        return {
            msg: this.$route.params?.msg,
        };
    },
};
</script>

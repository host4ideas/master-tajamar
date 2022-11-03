<template>
    <main>
        <label for="inputNumero"></label>
        <input type="text" id="inputNumero" v-model="numero" />
        <table>
            <thead>
                <tr>
                    <th>Numero</th>
                    <th>Operación</th>
                    <th>Resultado</th>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="multiplicador in 10"
                    :key="multiplicador"
                >
                    <td>{{ numero }}</td>
                    <td>{{ multiplicador }} X {{ numero }}</td>
                    <td>
                        {{ $filters.getMultiplicacion(multiplicador, numero) }}
                    </td>
                </tr>
            </tbody>
        </table>
    </main>
</template>

<script>
export default {
    name: "TablaMultiplicarFiltersPage",
    data() {
        return {
            numero: 0,
        };
    },
};
</script>

<style></style>

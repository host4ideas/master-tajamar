<template>
    <main>
        <label for="inputNumero"></label>
        <input
            type="text"
            id="inputNumero"
            v-model="numero"
            @keypress.enter="mostrarTabla"
        />
        <table>
            <thead>
                <tr>
                    <th>Operación</th>
                    <th>Resultado</th>
                </tr>
            </thead>
            <tbody v-html="resultados"></tbody>
        </table>
        <button @click="mostrarTabla">Mostrar tabla de multiplicar</button>
    </main>
</template>

<script>
export default {
    name: "TablaMultiplicarPage",
    data() {
        return {
            numero: 0,
            resultados: "",
        };
    },
    methods: {
        mostrarTabla() {
            this.resultados = "";

            for (let i = 0; i <= 10; i++) {
                this.resultados += `
                <tr>
                  <td>${this.numero} X ${i}</td>
                  <td>${this.numero * i}</td>
                </tr>
            `;
            }
        },
    },
};
</script>

<style></style>

<script>
import Vue from "vue";

Vue.component("dynamic-link", {
    template: `<component v-bind:is="transformed" /></component>`,

    data() {
        return {
            text: `
      <router-link to="/foo">
        <button class="button is-link is-outlined">
          Go to Foo (compiled router-link)
        </button>
      </router-link>
      `,
        };
    },

    computed: {
        transformed() {
            return { template: this.text };
        },
    },
});
</script>

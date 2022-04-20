<template>
  <error-informations :status="status" />
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import ErrorInformations from "@/components/errors/ErrorInformations.vue";

@Component({
  components: {
    ErrorInformations
  }
})
export default class Alert extends Vue {
  get status() {
    return this.$route.params.status;
  }
}
</script>

<template>
  <div class="hello"></div>
</template>

<script>
import api from "@/utilities/api";

import toastProperties from "@/utilities/toastProperties";

export default {
  name: "HelloWorld",

  data() {
    return {};
  },
  mounted() {
    this.$toast.success("Default toast", toastProperties);
  },
  methods: {
    async saveSolicitud() {
      if (this.editingForm) {
        const response = await api.put(
          `api/SolicitudSoporte?idSolicitud=${this.modelSolicitud.idSolicitud}`,
          this.modelSolicitud
        );
        if (response.data.Success) {
          this.loadMisSolicitudes();
          this.$toast.success("Default toast", toastProperties);
        } else {
          this.toast.warning(response.data.Message, toastProperties);
        }
      } else {
        const response = await api.post(
          "api/SolicitudSoporte",
          this.modelSolicitud
        );
        if (response.data.Success) {
          this.loadMisSolicitudes();
          this.modelSolicitud = response.data.Data;
          this.toast.success(response.data.Message, toastProperties);
        } else {
          this.toast.warning(response.data.Message, toastProperties);
        }
      }
    },
    async sendSolicitud() {
      const response = await api.put(
        `/api/SolicitudesSoporte/Enviar?idSolicitud=${this.modelSolicitud.idSolicitud}`
      );
      if (response.data.Success) {
        this.loadMisSolicitudes();
        this.solicitudDialog = false;
        this.modelSolicitud = {
          Mensaje: "",
        };
        this.toast.success(response.data.Message, toastProperties);
      } else {
        this.toast.warning(response.data.Message, toastProperties);
      }
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

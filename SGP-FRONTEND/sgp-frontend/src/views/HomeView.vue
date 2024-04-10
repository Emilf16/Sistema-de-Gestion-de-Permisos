<template>
  <div>
    <b-container fluid>
      <b-row class="mb-3 justify-content-end">
        <b-col cols="">
          <b-form-input
            v-model="nombre"
            placeholder="Buscar por Nombre"
            class="mr-2"
          ></b-form-input>
        </b-col>
        <b-col cols="auto">
          <b-button @click="getPermisos()" variant="primary">Buscar</b-button>
        </b-col>
        <b-col cols="auto">
          <b-button @click="goToCreateVue()" variant="success"
            >Registrar Permiso</b-button
          >
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <b-card class="text-center">
            <b-table
              :items="permisos"
              :fields="headers"
              :busy="cargandoPermisos"
            >
              <template #cell(fecha)="row">
                {{ formatearFecha(row.item.fecha) }}
              </template>
              <template #cell(permiso)="row">
                {{ getTipoPermisoLabel(row.item.permiso) }}
              </template>
              <template #cell(actions)="row">
                <b-button
                  variant="primary"
                  @click="editItem(row.item.id)"
                  class="mx-2"
                >
                  Editar
                </b-button>
                <b-button variant="danger" @click="openDeleteModal(row.item)">
                  Eliminar
                </b-button>
              </template>
              <template #table-busy>
                <div class="text-center text-danger my-2">
                  <b-spinner class="align-middle"></b-spinner>
                  <strong> Loading...</strong>
                </div>
              </template>
            </b-table>
            <!-- MODAL DE CONFIRMACIÓN -->
            <b-modal
              ref="modal"
              v-model="showDeleteModal"
              no-footer
              hide-header
            >
              <div class="d-flex justify-content-between mb-3">
                <h4 class="text-left">¿Estás seguro?</h4>
                <b-button variant="light" @click="hideDeleteModal()">
                  <b-icon icon="x-lg" aria-hidden="true"></b-icon>
                </b-button>
              </div>
              <p class="text-left">
                Estás a punto de borrar el registro del permiso de
                <strong>{{
                  deleteItem.nombre + " " + deleteItem.apellido
                }}</strong>
                del día <strong>{{ formatearFecha(deleteItem.fecha) }}</strong
                >.
              </p>
              <template #modal-footer>
                <b-button variant="secondary" @click="hideDeleteModal()"
                  >Cerrar</b-button
                >
                <b-button variant="danger" @click="deletePermiso()"
                  >Eliminar</b-button
                >
              </template>
            </b-modal>
          </b-card>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import api from "@/utilities/api";
import toastProperties from "@/utilities/toastProperties";

export default {
  name: "HomeView",
  data() {
    return {
      tipoPermisoList: [],
      permisos: [],
      headers: ["nombre", "apellido", "permiso", "fecha", "Actions"],
      nombre: "",
      cargandoPermisos: false,
      showDeleteModal: false,
      deleteItem: {
        id: 0,
        nombre: "",
        apellido: "",
        permiso: null,
        fecha: "",
      },
    };
  },
  async mounted() {
    await this.getPermisos();
    await this.getTipoPermisos();
  },
  methods: {
    formatearFecha(fechaISO) {
      if (!fechaISO) return ""; // Manejar casos donde la fecha es null o undefined

      const fechaDate = new Date(fechaISO);
      if (isNaN(fechaDate)) return ""; // Manejar casos donde la fecha no es válida

      const fechaFormateada = fechaDate.toISOString().split("T")[0];
      return fechaFormateada;
    },
    async editItem(id) {
      this.$router.push(`/edit/${id}`);
    },
    goToCreateVue() {
      this.$router.push("/create");
    },
    async getPermisos() {
      try {
        this.cargandoPermisos = true;
        const response = await api.get(`/Permisos?nombre=${this.nombre}`);
        this.permisos = response.data.data;

        if (response.data.success) {
          this.$toast.success(response.data.message, toastProperties);
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
        this.cargandoPermisos = false;
      } catch (error) {
        console.error("Error al realizar la búsqueda:", error);
        this.cargandoPermisos = false;
      }
    },
    async getTipoPermisos() {
      try {
        const response = await api.get(`/TipoPermiso`);

        if (response.data.success) {
          //   this.$toast.success(response.data.message, toastProperties);
          this.tipoPermisoList = response.data.data;
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
      } catch (error) {
        console.error("Error al realizar la búsqueda:", error);
      }
    },
    getTipoPermisoLabel(tipoPermisoId) {
      let retorno = "";
      if (this.tipoPermisoList) {
        if (tipoPermisoId != 0) {
          const filtro = this.tipoPermisoList.filter(
            (x) => x.id == tipoPermisoId
          );
          if (filtro.length > 0) {
            retorno = filtro[0].nombreTipoPermiso;
          } else {
            retorno = "N/A";
          }
        }
      } else {
        retorno = "N/A";
      }

      return retorno;
    },
    openDeleteModal(value) {
      this.showDeleteModal = true;
      Object.assign(this.deleteItem, value);
    },
    hideDeleteModal() {
      this.showDeleteModal = false;
    },
    async deletePermiso() {
      try {
        // Realizar una solicitud Delete para actualizar el permiso
        const response = await api.delete(
          `/Permisos/Borrar/${this.deleteItem.id}`
        );
        if (response.data.success) {
          this.$toast.success(response.data.message, toastProperties);

          await this.getPermisos();
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
      } catch (error) {
        this.$toast.warning("Error al eliminar el permiso", toastProperties);
      }
      this.hideDeleteModal();
    },
  },
};
</script>

<style scoped>
.mb-3 {
  margin-bottom: 1.5rem;
}
</style>

<template>
  <div>
    <h2>Editar Permiso</h2>
    <b-card>
      <b-form>
        <b-row class="mb-3">
          <b-col cols="12" md="6">
            <b-form-group
              label="Nombre:"
              label-for="nombre-input"
              :state="!nombreValid ? false : null"
              invalid-feedback="Este campo es obligatorio"
            >
              <b-form-input
                placeholder="Nombre"
                id="nombre-input"
                v-model.trim="permiso.nombre"
                required
              ></b-form-input>
            </b-form-group>
          </b-col>
          <b-col cols="12" md="6">
            <b-form-group
              label="Apellido:"
              label-for="apellido-input"
              :state="!apellidoValid ? false : null"
              invalid-feedback="Este campo es obligatorio"
            >
              <b-form-input
                placeholder="Apellido"
                id="apellido-input"
                v-model.trim="permiso.apellido"
                required
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
        <b-row class="mb-3">
          <b-col cols="12" md="6">
            <b-form-group
              label="Tipo Permiso:"
              label-for="tipo-permiso-input"
              :state="!permisoValid ? false : null"
              invalid-feedback="Este campo es obligatorio"
            >
              <b-form-select
                id="ipo-permiso-input"
                v-model="permiso.permiso"
                :options="tipoPermisoList"
                class="form-select"
                value-field="id"
                text-field="nombreTipoPermiso"
                disabled-field="notEnabled"
              ></b-form-select>
            </b-form-group>
          </b-col>
          <b-col cols="12" md="6">
            <b-form-group
              label="Fecha de Solicitud de Permiso:"
              label-for="fecha-solicitud-input"
              :state="!permiso.fecha ? false : null"
              invalid-feedback="Este campo es obligatorio"
            >
              <b-form-input
                id="fecha-solicitud-input"
                type="date"
                v-model="permiso.fecha"
                required
              ></b-form-input>
            </b-form-group>
          </b-col>
        </b-row>
        <b-row class="mb-3 justify-content-end">
          <b-col cols="auto">
            <b-button @click="putPermiso()" variant="primary"
              >Actualizar</b-button
            >
          </b-col>
        </b-row>
      </b-form>
    </b-card>
  </div>
</template>

<script>
import api from "@/utilities/api";
import toastProperties from "@/utilities/toastProperties";

export default {
  data() {
    return {
      tipoPermisoList: [],
      permiso: {
        id: 0,
        nombre: "",
        apellido: "",
        permiso: null,
        fecha: "",
      },
      nombreValid: true,
      apellidoValid: true,
      permisoValid: true,
    };
  },
  async mounted() {
    // Llamar a la función para cargar los detalles del permiso cuando el componente está montado
    await this.getPermiso();
    await this.getTipoPermisos();
  },

  methods: {
    async getPermiso() {
      try {
        // Obtener el ID del permiso de los parámetros de la URL
        const idPermiso = this.$route.params.id;
        // Realizar una solicitud GET para obtener los detalles del permiso
        const response = await api.get(`/Permisos/${idPermiso}`);
        // Asignar los datos del permiso a la propiedad de datos

        if (response.data.success) {
          this.$toast.success(response.data.message, toastProperties);
          this.permiso = response.data.data;
          const fechaDate = new Date(this.permiso.fecha);
          this.permiso.fecha = fechaDate
            .toISOString()
            .split("T")[0]
            .substr(0, 10);
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
      } catch (error) {
        console.error("Error al cargar el permiso:", error);
      }
    },
    async putPermiso() {
      if (!this.validarCampos()) {
        this.$toast.error("Formulario incompleto.", toastProperties);
        return;
      } else {
        try {
          // Realizar una solicitud PUT para actualizar el permiso
          const response = await api.put(
            `/Permisos/${this.permiso.id}`,
            this.permiso
          );
          if (response.data.success) {
            this.$toast.success(response.data.message, toastProperties);
            this.$router.push("/");
          } else {
            this.$toast.warning(response.data.message, toastProperties);
          }
        } catch (error) {
          console.error("Error al actualizar el permiso:", error);
        }
      }
    },
    validarCampos() {
      this.nombreValid = this.permiso.nombre.trim() !== "";
      this.apellidoValid = this.permiso.apellido.trim() !== "";

      this.permisoValid =
        this.permiso.permiso !== undefined && this.permiso.permiso !== null;

      // Return true only if all fields are valid
      return (
        this.nombreValid &&
        this.apellidoValid &&
        this.permisoValid  
      );
    },
    async getTipoPermisos() {
      try {
        const response = await api.get(`/TipoPermiso`);

        if (response.data.success) {
          //   this.$toast.success(response.data.message, toastProperties);
          this.tipoPermisoList = response.data.data;
          this.tipoPermisoList.unshift({
            id: null,
            nombreTipoPermiso: "SELECCIONAR",
          });
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
      } catch (error) {
        console.error("Error al realizar la búsqueda:", error);
      }
    },
  },
};
</script>

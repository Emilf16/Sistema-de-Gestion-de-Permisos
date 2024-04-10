<template>
  <div>
    <h2>Crear Permiso</h2>
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
                id="tipo-permiso-input"
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
            <b-button @click="postPermiso()" variant="primary"
              >Guardar</b-button
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
        fecha: new Date().toISOString().split("T")[0].substr(0, 10),
      },
      nombreValid: true,
      permisoValid: true,
      apellidoValid: true,
    };
  },
  async mounted() {
    await this.getTipoPermisos();
  },
  methods: {
    async postPermiso() {
      if (!this.validarCampos()) {
        this.$toast.error("Formulario incompleto.", toastProperties);
        return;
      } else {
        try {
          const response = await api.post(`/Permisos`, this.permiso);
          if (response.data.success) {
            this.$toast.success(response.data.message, toastProperties);
            this.$router.push("/");
          } else {
            this.$toast.warning(response.data.message, toastProperties);
          }
        } catch (error) {
          console.error("Error al crear el permiso:", error);
        }
      }
    },
    async getTipoPermisos() {
      try {
        const response = await api.get(`/TipoPermiso`);
        if (response.data.success) {
          this.tipoPermisoList = response.data.data;
          this.tipoPermisoList.unshift({
            id: null,
            nombreTipoPermiso: "SELECCIONAR",
          });
        } else {
          this.$toast.warning(response.data.message, toastProperties);
        }
      } catch (error) {
        console.error("Error al obtener los tipos de permiso:", error);
      }
    },
    validarCampos() {
      this.nombreValid = this.permiso.nombre.trim() !== "";
      this.apellidoValid = this.permiso.apellido.trim() !== "";

      this.permisoValid =
        this.permiso.permiso !== undefined && this.permiso.permiso !== null;

      // Retorno true si todos los campos estan validos
      return (
        this.nombreValid &&
        this.apellidoValid &&
        this.permisoValid  
      );
    },
  },
};
</script>

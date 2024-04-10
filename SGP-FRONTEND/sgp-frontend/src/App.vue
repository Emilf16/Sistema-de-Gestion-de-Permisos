<template>
  <div id="app">
    <header>
      <h2 @click="goHome()">Sistema de Gestión de Permisos</h2>
    </header>

    <main>
      <router-view />
    </main>

    <footer class="footer bg-dark text-white">
      <div class="container">
        <p class="text">
          Un sistema para gestionar permisos de usuarios. &copy;
          {{ getCurrentYear() }} Todos los derechos reservados.
        </p>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  methods: {
    getCurrentYear() {
      return new Date().getFullYear();
    },
    goHome() {
      // Verificar si la ruta actual no es la raíz "/"
      if (this.$route.path !== "/") {
        this.$router.push("/");
      }
    },
  },
};
</script>

<style scoped>
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

header {
  background-color: #333;
  color: #fff;
  padding: 10px 20px;
}

header h2 {
  font-size: 1.5rem;
}

main {
  flex: 1;
  padding: 20px;
}

.footer {
  background-color: #333;
  color: #fff;
  padding: 10px 20px;
}
</style>

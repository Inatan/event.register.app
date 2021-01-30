<template>
  <div id="app">
    <inadev-cadastro/>
    <inadev-footer/>
  </div>
 
</template>

<script>
import Footer from './components/shared/footer/Footer.vue';
import Cadastro from './components/cadastro/Cadastro.vue';

export default {

components: {
    'inadev-footer': Footer, 
    'inadev-cadastro': Cadastro,
  },
  name: 'app',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 0px;
  padding: 0px;
}

h1, h2 {
  font-weight: normal;
}


div {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
    }


</style>

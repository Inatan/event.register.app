<template>

  <div>
    <h1 class="centralizado">Cadastro</h1>
    <h2 class="centralizado">Inclusão</h2>

    <form @submit.prevent="grava()" >
        <div class="controle">
            <label for="nome">Nome</label>
            <input name="nome" v-model="participante.nome" id="nome" autocomplete="off" >
        </div>

        <div class="controle">
            <label for="cpf">CPF</label>
            <input name="cpf" v-model="participante.cpf" id="cpf" autocomplete="off" >
        </div>

        <div class="controle">
            <label for="email">E-mail</label>
            <input name="email" v-model="participante.email" id="email" autocomplete="off" >
        </div>

        <div class="controle">
            <label for="nascimento">Nascimento</label>
            <input name="nascimento" v-model="participante.nascimento" id="nascimento" autocomplete="off" >
        </div>

        <div class="controle">
            <label for="cidade">Cidade</label>
            <input name="cidade" v-model="participante.cidade" id="cidade" autocomplete="off" >
        </div>
      

      <div class="centralizado">
        <inadev-botao rotulo="GRAVAR" tipo="submit"/>
      </div>

    </form>
  </div>
</template>

<script>

import Botao from '../shared/botao/Botao.vue';
import Participante from '../../domain/participante/Participante.js';
import ParticipanteService from '../../domain/participante/ParticipanteServices.js';

export default {

  components: {

    'inadev-botao': Botao
  },

  methods:{
     grava() {

        this.$validator
          .validateAll()
          .then(success => {
            if(success) {

              this.service
                .cadastra(this.participante)
                .then(() => {
                  this.participante = new Participante()
                }, 
                err => console.log(err));
            }
        });
    }

  },

  data() {
    return {
      participante: new Participante(),
    }
  },

  created() {
    this.service = new ParticipanteService(this.$resource);
  }
}

</script>
<style scoped>
    div {
        margin: 0;
    }
    form{
        max-width: 600px;
        
    }

    input[type=text], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

  .centralizado {
    text-align: center;
  }
  .controle {
    font-size: 1.2em;
    margin-bottom: 20px;

  }
  .controle label {
    display: block;
    font-weight: bold;
  }

 .controle label + input, .controle textarea {
    width: 100%;
    font-size: inherit;
    border-radius: 5px
  }

  .centralizado {
    text-align: center;
  }

  .erro {
    color: red;
  }

</style>
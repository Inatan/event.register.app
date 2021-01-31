<template>

  <div>
    <h1 class="centralizado">Cadastro do Evento</h1>
    <h2 class="centralizado">Dados para participar</h2>
    <p v-show="mensagem" class="centralizado erro">{{ mensagem }}</p>

    <form @submit.prevent="grava()" >
        <inadev-input :nome="nome" titulo="Nome"  v-model="participante.nome"/>

        <inadev-input :nome="cpf" titulo="CPF"  v-model="participante.cpf"/>

        <inadev-input :nome="email" titulo="E-mail"  v-model="participante.email"/>

        <inadev-input :nome="nascimento" titulo="Nascimento"  v-model="participante.nascimento" :tipo="'data'"/>

        <!-- <inadev-input :nome="cidade" titulo="Cidade" v-model="participante.cidade"/> -->

        <div class="controle">
            <label for="cidade">Cidade</label>
            <input  name="cidade"  id="cidade"  v-model="participante.cidade" autocomplete="off" > 
            <!-- v-model="campoNome" -->
        </div>

        <div class="centralizado">
            <inadev-botao rotulo="GRAVAR" tipo="submit"/>
        </div>

    </form>
  </div>
</template>

<script>

import Botao from '../shared/botao/Botao.vue';
import Input from '../shared/input/Input.vue';
import Participante from '../../domain/participante/Participante.js';
import ParticipanteService from '../../domain/participante/ParticipanteServices.js';

export default {

  components: {

    'inadev-botao': Botao,
    'inadev-input' : Input,
  },

  methods:{
     grava() {
        console.log(this.participante);
        this.mensagem = this.participante.nome;

        this.service
            .cadastra(this.participante)
            .then(() => {
                this.mensagem = 'Participante incluído no evento com sucesso'
                this.participante = new Participante();
            }, 
            err =>this.mensagem = err.message);
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
<style >
    h1{
        color: rgba(6,3,141,1);
        font-weight: 700;
    }
    div {
        margin: 0;
    }
    form{
        max-width: 600px;
        margin: auto;
    }


  .centralizado {
    text-align: center;
  }


  .centralizado {
    text-align: center;
  }

  .erro {
    color: red;
  }

</style>
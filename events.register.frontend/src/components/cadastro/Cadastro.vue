<template>

  <div>
    <h1 class="centralizado">Cadastro do Evento</h1>
    <h2 class="centralizado">Dados para participar</h2>
    <p v-show="mensagem" class="centralizado erro pre-formatted">{{ mensagem }}</p>

    <form @submit.prevent="grava" >
        <div class="controle">
            <label for="nome">Nome</label>
            <input name="nome" v-model="participante.nome" id="nome" autocomplete="off" v-validate data-vv-rules="required|min:3|alpha_spaces" >
            <span class="erro"  v-show="errors.has('nome')">{{ errors.first('nome') }}</span>
        </div>

        <div class="controle">
            <label for="cpf">CPF</label>
            <input name="cpf" v-model="participante.cpf" id="cpf" autocomplete="off" v-validate data-vv-rules="required|min:11|max:14" >
            <span class="erro"  v-show="errors.has('cpf')">{{ errors.first('cpf') }}</span>
        </div>
        

        <div class="controle">
            <label for="email">E-mail</label>
            <input name="email" v-model="participante.email" id="email" autocomplete="off" v-validate data-vv-rules="required|email" >
            <span class="erro"  v-show="errors.has('email')">{{ errors.first('email') }}</span>
        </div>

        <div class="controle">
            <label for="nascimento">Nascimento</label>
            <inadev-datapicker :language="ptBR" format="dd/MM/yyyy" v-model="participante.nascimento"  name="nascimento"></inadev-datapicker>
            
        </div>

        <div class="controle">
            <label for="cidade">Cidade</label>
            <input name="cidade" v-model="participante.cidade" id="cidade" autocomplete="off" v-validate data-vv-rules="required|min:3|alpha_num" >
            <span class="erro"  v-show="errors.has('cidade')">{{ errors.first('cidade') }}</span>
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
import Datepicker from 'vuejs-datepicker';
import ptBR from '../../pt-BR.js';
export default {

  components: {

    'inadev-botao': Botao,
    'inadev-datapicker' : Datepicker,
  },

    methods:{
        async grava() {
            var self = this;
            self.mensagem = "";

            await this.$validator
            .validateAll()
            .then(success => {
                if(success) {
                     self.axios.post('http://localhost:5000/api/v1/ParticipanteEvento/',self.participante)
                    .then((response) => {
                        console.log(response);
                        self.participante = new Participante()
                    }).catch(function (error) {
                        var errorBody = error.response.data ;
                        var errosTxt = ""; 
                        Object.keys(errorBody.errors).forEach(function(key) {
                            console.log(errorBody.errors[key][0]);
                            errosTxt += errorBody.errors[key][0] + " \n"; 
                        });
                        self.mensagem = errosTxt;
                    });
                }
            });
        }

    },

  data() {
    return {
      participante: new Participante(),
      ptBR: ptBR,
      mensagem: "",
    }
  },

    created() {
        this.axios.get('http://localhost:5000/api/v1/ParticipanteEvento/').then((response) => {
            console.log(response.data)
        });
    // this.service = new ParticipanteService(this.$resource);
    // this.service.lista()
    //   .then(participante => console.log(participante), err => this.mensagem = err.message);
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

    .vdp-datepicker{
        padding:0;
    }
    .vdp-datepicker div{
        padding:0;
    }

    input {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        text-align: center;
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

    .pre-formatted {
        white-space: pre;
    }

</style>
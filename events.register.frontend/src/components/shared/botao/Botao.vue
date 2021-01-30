
<template>
    <button class="botao" :class="estiloDoBotao" :type="tipo" @click="disparaAcao()">{{ rotulo }}</button>
</template>

<script>
export default {
      props: {
            tipo: {
                required: true,
                type: String
            },

            rotulo: {
                required: true,
                type: String
            },

            confirmacao: {
                required: false,
                default: false,
                type: Boolean
            },

            estilo: {
                required: false,
                default: 'padrao',
                type: String
            }
        },

    methods: {
        disparaAcao() {
            if(this.confirmacao) {
               if(confirm('Confirma operacao?')) {
                    this.$emit('botaoAtivado');
               }
               return;
           }
           this.$emit('botaoAtivado');
        }
    },

    computed: {

       estiloDoBotao() {

           if(this.estilo == 'padrao' || !this.estilo) 
                return 'botao botao-padrao';
       }
   }
}
</script>

<style>
    .botao {
        display: inline-block;
        padding: 15px 30px;
        border-radius: 3px;
        margin: 10px;
        font-size: 1.2em;
        border-radius: 15px;
        box-shadow: 7px 7px 5px #999;
    }

    .botao-padrao {
        background: linear-gradient(45deg,rgba(0,32,96,1) 0,rgba(6,3,141,1) 43%,rgba(163,35,142,1) 100%);
        color: #ddd;
        font-weight: bold;
    }

    .botao-padrao:hover {
        background: linear-gradient(45deg,rgb(0, 16, 65) 0,rgba(0,32,96,1) 43%,rgb(60, 35, 172) 100%);
        color: #fff;
        font-weight: bold;
    }
</style>

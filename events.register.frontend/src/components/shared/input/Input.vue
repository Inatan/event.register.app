
<template>
    <div class="controle">
        <label :for="nome">{{ titulo }}</label>
        <inadev-datapicker v-if="tipo == 'data'" :language="ptBR" format="dd/MM/yyyy" v-model="campoNome"  :name="nome"></inadev-datapicker>
        <input  v-else  :name="nome"  :id="nome" autocomplete="off" > 
        <!-- v-model="campoNome" -->
    </div>
</template>

<script>

import Datepicker from 'vuejs-datepicker';
import ptBR from '../../../pt-BR.js';
export default {

    components: {
        'inadev-datapicker' : Datepicker,
    },

    props: {

        nome: {
            required: true,
            type: String
        },

        titulo: {
            required: true,
            type: String
        },

        campoNome: {
            required: true,
            type: String
        },

        tipo:{
            required: false,
            default: 'text',
            type: String
        },
            
    },

    data() {
        return {
            ptBR: ptBR,
        }
    },
}
</script>



<style>
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
</style>

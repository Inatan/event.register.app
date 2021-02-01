import Vue from 'vue'
import App from './App.vue'
import VueAxios from 'vue-axios';
import axios from 'axios';
import VeeValidate from 'vee-validate';
import msg from './validate_pt_BR';


Vue.use(VueAxios, axios);

Vue.use(VeeValidate, {
  locale: 'pt_BR',
  dictionary: {
    pt_BR: {
      messages: msg
    }
  }
});


new Vue({
  el: '#app',
  render: h => h(App)
})

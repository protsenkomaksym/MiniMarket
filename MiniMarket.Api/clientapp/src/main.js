import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue3 from 'bootstrap-vue-3'
import bootstrap from 'bootstrap'
import { createPinia } from 'pinia'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css'

const pinia = createPinia()

createApp(App)
.use(router)
.use(BootstrapVue3)
.use(bootstrap)
.use(pinia)
.mount('#app')

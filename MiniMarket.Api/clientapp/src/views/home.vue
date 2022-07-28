<template>
    <h4>This is home</h4>
    <br>
    App state: <b>{{ store.counter }}, {{ store.doubleCounter }}</b>
    <button @click="store.increase">+</button>
    <button @click="store.decrease">-</button>
    <input v-model="store.counter" type="number"/>
    <hr/>
    <CategoryList title="Categories"/>
</template>
<script>

import CategoryList from '../components/CategoryList.vue'
import { useCounterStore } from '@/stores/store'

export default ({
    name: "home-component",
    components: {
        CategoryList
    },
    setup() {
        const store = useCounterStore();
        //const { counter } = storeToRefs (store);

        return {
            store
        }
    }
})
</script>
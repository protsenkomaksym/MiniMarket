<template>
    <h4>This is about</h4>
    <br>
    App state: <b>{{ store.counter }}, {{ store.doubleCounter }}</b>
    <button @click="store.increase">+</button>
    <button @click="store.decrease">-</button>
    <hr/>
    About this page
</template>
<script>

//import { storeToRefs  } from 'pinia'
import { useCounterStore } from '@/stores/store'

export default ({
    name: "about-component",
    setup() {
        const store = useCounterStore();
        //const { counter } = storeToRefs (store);

        return {
            store
        }
    }
})
</script>
<template>
    <b>{{ title }}</b>
    <div>{{ idSelected }}</div>
    <b-list-group v-for="i in items" :key="i">
        <b-list-group-item>{{ i.name }}</b-list-group-item>
    </b-list-group>
</template>
<script>
import { ref, onMounted, watch } from "vue"
import axios from "axios"

export default {
    name: "item-component",
    props: {
        title: String,
        idSelected: Number
    },
    setup(props){
        var items = ref([]);
        //const selected = ref(props.idSelected);

        watch(() => props.idSelected, (selection, prevSelection) => {
            console.log(selection + ", " + prevSelection);
            GetItemList();
        });

        const GetItemList = () => {
            //console.log(props.idSelected);
            if(props.idSelected != null){
                axios.get('https://localhost:44312/api/Home/GetItemsByCategory/' + props.idSelected)
                .then(x => items.value = x.data)
                .then(x => console.log(x))
                .catch(y => console.log('Error: ' + y));
            }
        }

        onMounted(() => {
            GetItemList();
        });

        return {
            items,
            GetItemList
        }
    }
}
</script>
<style>
.tdCustom{
    color: green;
}
</style>
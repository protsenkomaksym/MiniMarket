<template>
    <b>{{ title }}</b>
    <b-table-simple responsive>
        <b-thead head-variant="dark">
            <b-tr>
                <b-th>Category name</b-th>
            </b-tr>
        </b-thead>
        <b-tbody>
            <b-tr v-for="c in categories" :key="c">
                <b-td @click="SearchItemsByCategory(c.id)" class="tdCustom">{{ c.name }}</b-td>
            </b-tr>
        </b-tbody>
    </b-table-simple>
    <ItemList title="Items" :idSelected="idSelected"/>
</template>
<script>
import { ref, onMounted  } from "vue"
import axios from "axios"
import ItemList from './ItemList.vue'

export default {
    name: "category-component",
    props: ["title"],
    components: {
        ItemList
    },
    setup(){
        var categories = ref([]);
        var idSelected = ref(null);

        const GetCategoryList = () => {
            axios.get('https://localhost:44312/api/Home/GetCategories')
                .then(x => categories.value = x.data)
                .catch(y => console.log('Error: ' + y));
        }

        const SearchItemsByCategory = (id) => {
            idSelected.value = id;
            //console.log(idSelected.value);
        }

        onMounted(() => {
            GetCategoryList();
        });

        return {
            categories,
            GetCategoryList,
            SearchItemsByCategory,
            idSelected
        }
    }
}
</script>
<style>

</style>
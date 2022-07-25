<template>
    <h4>This is home</h4>
    <hr/>
    <CategoryList title="Categories"/>
</template>
<script>

import CategoryList from '../components/CategoryList.vue'

export default ({
    name: "home-component",
    components: {
        CategoryList
    }
})
</script>
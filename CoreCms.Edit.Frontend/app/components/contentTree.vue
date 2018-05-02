<template>
    <div>
        <v-container flex>
        <ul class="content-tree__root-list">
            <content-tree-item :element="root()"></content-tree-item>
        </ul>
        </v-container>
    </div>
</template>

<script>
    import Vue from 'vue'

    export default Vue.component('content-tree',{
        props: ['contentType'],
        data: function () {
            return {}
        },

        methods: {
            root() {
                let tree = this.$store.getters.getContentTree(this.contentType);
                return tree.root;
            }
        },
        created(){
            this.$store.dispatch('loadContentTree', this.contentType);
        }
    })
</script>

<style lang="scss">
    .content-tree{
        &__root-list{
            margin:0;
            padding:0;
        }
    }
</style>
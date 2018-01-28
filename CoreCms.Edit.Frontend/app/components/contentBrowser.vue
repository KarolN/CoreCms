<template>
    <div class="content-browser__container">
        <md-card>
            <md-tabs>
                <md-tab v-for="type in contentTypes" :key="type.contentType" :md-label="type.name">
                    <content-tree :key="type.contentType" :content-type="type.contentType"></content-tree>
                </md-tab>
            </md-tabs>
        </md-card>
    </div>
</template>

<script>
    import Vue from 'vue'

    export default Vue.extend({
        data: function(){
            return {}
        },
        computed: {
            contentTypes(){
                return this.$store.state.contentTypes;
            }
        },
        created(){
            this.$store.dispatch('loadContentTypes')
        }
    })
</script>

<style>
    .content-browser__container{
        width: 100%;
    }
</style>
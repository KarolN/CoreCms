<template>
    <article class="editor__outer">
    <v-card>
        <v-card-title primary-title>
            <h1>{{editableContent.name}}</h1>
        </v-card-title>
        <v-card-text>

        </v-card-text>
    </v-card>
    </article>
</template>

<script>
    import Vue from 'vue';

    export default Vue.extend({
        computed: {
            editableContent(){
                return this.$store.state.editableContent;
            }
        }
    })

</script>

<style lang="scss">
    .editor{
        &__outer{
            padding: 20px;
        }
    }
</style>
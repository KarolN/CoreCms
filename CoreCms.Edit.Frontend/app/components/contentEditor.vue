<template>
    <article class="editor__outer">
    <md-card>
        <md-card-header>
            <div class="md-title">{{editableContent.name}}</div>
        </md-card-header>
        <md-card-content>

        </md-card-content>
    </md-card>
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
<template>
    <div class="content-browser__container">
        <v-card>
            <v-tabs>
                <v-tabs-bar class="primary" dark>
                    <v-tabs-item v-for="type in contentTypes" :key="type.contentType"
                                 :href="'#' + type.contentType" ripple >
                        {{type.name}}
                    </v-tabs-item>
                    <v-tabs-slider color="white"></v-tabs-slider>
                </v-tabs-bar>
                <v-tabs-items>
                    <v-tabs-content v-for="type in contentTypes" :key="type.contentType" :id="type.contentType">
                        <content-tree :contentType="type.contentType"></content-tree>
                    </v-tabs-content>
                </v-tabs-items>
            </v-tabs>
        </v-card>
    </div>
</template>

<script>
    import Vue from 'vue'

    export default Vue.extend({
        data: function () {
            return {}
        },
        computed: {
            contentTypes() {
                return this.$store.state.contentTypes;
            }
        },
        created() {
            this.$store.dispatch('loadContentTypes')
        }
    })
</script>

<style>
    .content-browser__container {
        width: 100%;
    }
</style>
<template>
    <v-container grid-list-md>
        <v-layout row>
            <v-flex xs12>
                <v-card>
                    <v-card-title primary-title>
                        <h1>{{editableContent.name}}</h1>
                    </v-card-title>
                    <v-card-text>
                        <div>Name: {{editableContent.name}}</div>
                        <div>Id: {{editableContent.contentId}}</div>
                    </v-card-text>
                    <v-card-actions>
                        <v-layout justify-end>
                           <v-flex xs2>
                               <v-btn color="primary" flat :disabled="!editableState.changes" @click="saveChanges()">Save changes</v-btn>
                           </v-flex>
                        </v-layout>
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>

        <v-layout row>
            <v-flex xs12>
                <v-card class="mt">

                    <v-card-text>
                        <v-container>
                            <v-layout v-for="property in editableContent.properties" :key="property.name">
                                <v-flex xs12 class="editor-property__outer">
                                    <v-layout>
                                        <v-flex xs2>
                                            {{property.name}}:
                                        </v-flex>
                                        <v-flex s10>
                                            <component :is="getPropertyEditorName(property.type)" :property="property"></component>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout>
                                        <v-divider></v-divider>
                                    </v-layout>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
        <new-content-modal></new-content-modal>
    </v-container>
</template>

<script>
    import Vue from 'vue';
    import _ from 'lodash';
    import stringEditor from '~/components/propertyEditors/stringEditor.vue'

    export default Vue.extend({
        computed: {
            editableContent() {
                return this.$store.state.editableContent;
            },
            editableState(){
                return this.$store.state.editableState;
            }
        },

        methods: {
            getPropertyEditorName(type){
                let setting = _.find(this.$store.state.propertyEditorsSettings, x => x.typeName === type);
                if(setting){
                    return setting.editorComponentName;
                }
                return 'string-editor';
            },

            saveChanges(){
                this.$store.dispatch('saveEditableContent', this.$store.state.editableContent);
            }
        },

        created(){
            if(this.$store.state.propertyEditorsSettings.length === 0){
                this.$store.dispatch('loadPropertyEditorsSettings')
            }
        },

        components:{
            'string-editor': stringEditor
        }
    })

</script>

<style lang="scss">
    .editor-property {
        &__outer {
            min-height: 40px;
        }
    }
</style>
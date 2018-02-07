<template>
    <v-form>
        <v-text-field :label="property.name" v-model="propertyValue"></v-text-field>
    </v-form>
</template>

<script>
    import Vue from 'vue'

    export default Vue.extend({
        props: ['property'],
        data: function(){
            return {}
        },
        computed:{
            propertyValue:{
                get(){
                    return this.property.value;
                },
                set(value){
                    this.property.value = value;
                    this.$store.dispatch('updateEditableProperty', this.property );
                }
            }
        }
    });
</script>
<template>
    <li class="content-tree-list__item">
        <div>
            <div class="content-tree-list__item-content">
                <v-layout row :class="{'content-tree-list__item-content--selected': isSelected}">
                    <v-flex class="content-tree-list__expand-icon" xs1>
                        <div class="content-tree-list__expand-icon-inner"
                             v-if="element.children && element.children.length > 0" v-on:click.stop="toggleExpand()">
                            <v-icon v-show="!isExpanded">keyboard_arrow_right</v-icon>
                            <v-icon v-show="isExpanded">keyboard_arrow_down</v-icon>
                        </div>
                    </v-flex>
                    <v-flex xs9 class="content-tree-list__item-name">
                        <div v-on:click="select()">
                        {{element.name}}
                        </div>
                    </v-flex>
                    <v-flex xs1>
                        <v-menu>
                            <v-btn icon slot="activator">
                                <v-icon>menu</v-icon>
                            </v-btn>
                            <v-list>
                                <v-list-tile>
                                    <v-list-tile-title>Add child</v-list-tile-title>
                                </v-list-tile>
                                <v-list-tile>
                                    <v-list-tile-title>Remove</v-list-tile-title>
                                </v-list-tile>
                            </v-list>
                        </v-menu>
                    </v-flex>
                </v-layout>
            </div>
            <ul class="content-tree-list__list" v-if="isExpanded">
                <content-tree-item v-for="child in element.children" :element="child"
                                   :key="child.id"></content-tree-item>
            </ul>
        </div>
    </li>
</template>

<script>
    import Vue from 'vue'

    export default Vue.component('content-tree-item', {
        props: ['element'],
        data: function () {
            return {
                isExpanded: false
            }
        },

        computed: {
            isSelected(){
                return this.$store.state.selectedContentNode.id === this.element.id;
            }
        }

        ,
        methods: {
            toggleExpand: function () {
                this.isExpanded = !this.isExpanded;
            },
            select: function () {
                this.$store.dispatch('selectContentNode', this.element);
            }
        }
    })
</script>

<style lang="scss">
    .content-tree-list {
        &__item {
            margin-top: 0 !important;
            list-style: none;
            list-style-type: none;
            width: 100%;
            cursor: pointer;
        }
        &__list {
            margin-left: 10px;
            padding: 0;
        }

        &__item-content {
            padding: 5px 5px;

            &--selected {
                background-color: #cbcbcb;
            }
        }

        &__item-name {
            padding: 8px;
            height: 40px;
            font-size: 16px;
            &:hover {
                color: #c0c0c0;
            }

            & > div{
                width:100%;
            }
        }

        &__expand-icon {
            cursor: pointer;
            &:hover {
                color: #919191;
            }
        }
        &__expand-icon-inner {
            height: 40px;
            padding: 8px;
        }

        li ul {
            margin-left: 10px !important;
        }
    }
</style>
<template>
    <li class="content-tree-list__item">
        <div>
            <div class="content-tree-list__item-content">
                <md-layout md-align="end" md-gutter="10">
                    <md-layout class="content-tree-list__expand-icon" md-flex="10">
                        <div class="content-tree-list__expand-icon-inner"
                             v-if="element.children && element.children.length > 0" v-on:click.stop="toggleExpand()">
                            <md-icon v-show="!isExpanded">keyboard_arrow_right</md-icon>
                            <md-icon v-show="isExpanded">keyboard_arrow_down</md-icon>
                        </div>
                    </md-layout>
                    <md-layout md-flex="80" class="content-tree-list__item-name"
                               :class="{'content-tree-list__item-content--selected': isSelected}">
                        <div v-on:click="select()">
                        {{element.name}}
                        </div>
                    </md-layout>
                    <md-layout md-flex="10">
                        <md-menu>
                            <md-button class="md-icon-button" md-menu-trigger>
                                <md-icon>menu</md-icon>
                            </md-button>
                            <md-menu-content>
                                <md-menu-item>
                                    <span>Add child</span>
                                </md-menu-item>
                                <md-menu-item>
                                    <span>Remove</span>
                                </md-menu-item>
                            </md-menu-content>
                        </md-menu>
                    </md-layout>
                </md-layout>
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
            padding: 15px 10px;

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
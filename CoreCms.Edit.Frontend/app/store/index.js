import Vue from "vue"
import Vuex from "vuex"
import {state} from "./state.js"
import {mutations} from "./mutations.js"
import {actions} from "./actions.js"
import {newContentModule} from "./addContentModule.js"
Vue.use(Vuex);

export default new Vuex.Store({
    state,
    actions,
    mutations,
    getters: {
        getContentTree: (state) => (contentType) => {
            let contentTree = state.contentTrees.filter(tree => tree.contentType === contentType);
            if(contentTree[contentTree.length - 1]){
                return contentTree[contentTree.length - 1].tree;
            }
            return {root: {children:[]}}
        }
    },

    modules:{
        newContentModule: newContentModule
    }
});
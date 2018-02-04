import Vue from "vue"
import Vuex from "vuex"
import {state} from "./state.js"
import {mutations} from "./mutations.js"
import {actions} from "./actions.js"

Vue.use(Vuex);

export default new Vuex.Store({
    state,
    actions,
    mutations,
    getters: {
        getContentTree: (state) => (contentType) => {
            let contentTree = state.contentTrees.filter(tree => tree.contentType === contentType);
            if(contentTree[0]){
                return contentTree[0].tree;
            }
            return {root: {children:[]}}
        }
    }
});
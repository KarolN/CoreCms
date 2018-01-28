

export const mutations = {
    initContentTypes(state, types){
        state.contentTypes = types;
    },

    loadContentTree(state, contentTree){
        state.contentTrees.push(contentTree);
    },

    selectContentNode(state, contentNode){
        state.selectedContentNode = contentNode;
    },

    loadEditableContent(state, editable){
        state.editableContent = editable;
    }
}
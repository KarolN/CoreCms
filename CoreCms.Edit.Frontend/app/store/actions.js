import contentTreeDataService from "~/services/contentTreeDataService"

export const actions = {
    loadContentTypes : function(context){
        contentTreeDataService.getContentTypes().then(function(response) {
            context.commit('initContentTypes', response.data);
        });
    },

    loadContentTree : function(context, contentType){
        contentTreeDataService.getContentTree(contentType).then(function(response) {
            context.commit('loadContentTree', {contentType, tree: response.data});
        });
    },

    selectContentNode(context, contentNode){
        context.commit('selectContentNode', contentNode);

        let editable = {name: contentNode.name};
        context.commit('loadEditableContent', editable)
    }
};
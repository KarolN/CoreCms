import contentTreeDataService from "~/services/contentTreeDataService"

export const actions = {
    loadContentTypes : function(context){
        const types = contentTreeDataService.getContentTypes();
        context.commit('initContentTypes', types)
    },

    loadContentTree : function(context, contentType){
        const tree = contentTreeDataService.getContentTree(contentType);
        context.commit('loadContentTree', {contentType, tree});
    },

    selectContentNode(context, contentNode){
        context.commit('selectContentNode', contentNode);

        var editable = {name: contentNode.name};
        context.commit('loadEditableContent', editable)
    }
}
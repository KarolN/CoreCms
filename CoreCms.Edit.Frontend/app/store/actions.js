import contentTreeDataService from "~/services/contentTreeDataService"
import editableContentService from "~/services/editableContentService"

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

    selectContentNode(context, contentNode) {
        context.commit('selectContentNode', contentNode);

        editableContentService.getEditableContent(contentNode.contentReference).then(function (response) {
            context.commit('loadEditableContent', response.data)
        });
    },

    updateEditableProperty(context, property){
        context.commit('updateEditableProperty', property);
    },

    loadPropertyEditorsSettings(context){
        editableContentService.getPropertyEditorsSettings().then(function(response){
            context.commit('loadPropertyEditors', response.data);
        })
    },

    saveEditableContent(context, content){
        editableContentService.saveEditableContent(content).then(function(response){
            context.commit('loadEditableContent', response.data);
        });
    },

    createNewContent(context){
        let newContent = {
            name: context.state.newContentModule.newContentName,
            parentId: context.state.newContentModule.newContentModalData.parentId,
            contentTemplate: context.state.newContentModule.selectedTemplate
        };

        editableContentService.createNewContent(newContent).then(response => {
            context.dispatch('loadContentTree', response.data.contentType);
            let contentNode = {
                contentReference: response.data
            };
            context.dispatch('selectContentNode', contentNode);
            context.dispatch('newContentModule/closeNewContentModal')
        });
    }
};
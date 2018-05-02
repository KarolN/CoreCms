import _ from 'lodash'

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
        state.originalContent = _.cloneDeep(editable);
        state.editableState = {changes: false, editedProps:[]}
    },

    updateEditableProperty(state, property){
        let prop = _.find(state.editableContent.properties, (x => x.name === property.name));
        prop.value = property.value;
        let originalProp = _.find(state.originalContent.properties, (x => x.name === property.name));
        if(prop.value === originalProp.value){
            _.remove(state.editableState.editedProps, x => x === prop.name);
            state.editableState.changes = state.editableState.editedProps.length > 0;
        }
        else{
            if(!_.find(state.editableState.editedProps, x => x === prop.name)) {
                state.editableState.editedProps.push(prop.name);
                state.editableState.changes = true;
            }
        }
    },

    loadPropertyEditors(state, editors) {
        state.propertyEditorsSettings = editors;
    }
};
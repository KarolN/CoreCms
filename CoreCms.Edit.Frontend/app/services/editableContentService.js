import axios from 'axios';
import {httpConfig} from '~/httpConfig'

var client = axios.create(httpConfig);
export default  {
    getEditableContent(contentReference){
        return client.get('editableContent', {params: contentReference});
    },

    getPropertyEditorsSettings(){
        return client.get('propertyEditors');
    },

    saveEditableContent(content){
        return client.put('editableContent', content);
    },

    createNewContent(content){
        return client.post('content', content);
    }
};
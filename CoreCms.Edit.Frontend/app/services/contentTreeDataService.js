import axios from 'axios';
import {httpConfig} from '~/httpConfig'

var client = axios.create(httpConfig);
export default  {
    getContentTypes: function(){
        return client.get('contentTypes')
    },
    getContentTree: function(contentType){
        return client.get('contentTree', {params:{contentType: contentType}});
    },
    getContentTemplates: function(contentType){
        return client.get('contentTemplates', {params:{contentType: contentType}})
    }
};
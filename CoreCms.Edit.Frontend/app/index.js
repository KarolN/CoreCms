import Vue from 'vue';
import Vuetify from 'vuetify'
import ContentBrowser from './components/contentBrowser.vue'
import ContentTree from './components/contentTree.vue'
import ExpandableList from './components/contentTreeItem.vue'
import ContentEditor from './components/contentEditor.vue'
import Store from './store/index'

Vue.use(Vuetify);

const vm = new Vue({
    el: '#app',
    components: {
        'content-browser': ContentBrowser,
        'content-editor': ContentEditor
    },
    store: Store
});
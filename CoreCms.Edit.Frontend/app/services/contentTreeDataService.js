
export default  {
    getContentTypes: function(){
        return [
            {
                name: "Pages",
                contentType: "page",
            },
            {
                name: "Images",
                contentType: "image"
            }];
    },
    getContentTree: function(contentType){
        let tree = {
            root: {
                id: 1,
                name: 'root',
                children: [
                    {
                        id: 2,
                        name: 'elem1'
                    },
                    {
                        id: 3,
                        name: 'elem2'
                    }
                ]
            }
        }
        if(contentType === 'page'){
            tree.root.children.push({
                id: 4,
                name: 'elem5'
            })
        }
        return tree;
    }
};



var vm1 = new Vue({
    el: '#appp',
    data: {
        endpoint: 'api/missions/get',
        posts: [],
        post: {

        },
        search:''


    },



    methods: {
        deleteData: function (post) {
            
            this.$http.delete('api/missions/delete/' + post.id).then(function (response) {


                               
            }, function (error) {

            })

        },

     
     


    getAllPosts: function () {
        this.$http.get(this.endpoint).then(function (response) {
            this.posts = response.data
        }, function (error) {

        })
    }
    },
    computed: {
        filteredPosts: function () {
            return this.posts.filter((post) => {
                return post.name.match(this.search);
            });
        }
    },




    
    created: function () {
        this.getAllPosts()
           
    }
})

var vm2 = new Vue({
    el: '#app',
    data() {
        return {
            input: "ast",
            id:"",
            name: "",
            tegs: "",
            description: "",
            complate: ""
        }
    }  
    ,
    methods: {
        saveData: function () {
            
            var name = this.name;
           var tegs = this.tegs;
            var description = this.description;
            var complate = this.complate;
            this.$http.post('api/missions/post', {  name, tegs, description, complate }).then(function (response) {

            }, function (response) {

            })
        },
        reset: function () {
            this.id = '';
            this.name = '';
            this.tegs = '';
            this.description = '';
            this.complate = '';



        },

    }
})
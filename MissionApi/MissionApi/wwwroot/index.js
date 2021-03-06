﻿var vm1 = new Vue({
    el: '#app',
    data: {
        endpoint: 'api/missions/get',
        posts: [],
        post: {

        },
        search: '',
        input: "ast",
        id: "",
        name: "",
        tegs: "",
        description: "",
        complate: ""


    },



    methods: {
        deleteData: function (post) {
            var index = this.posts.indexOf(post);

            this.$http.delete('api/missions/delete/' + post.id).then(function (response) {

                this.posts.splice(index, 1);

            }, function (error) {

            })

        },
        saveData: function () {

            var name = this.name;
            var tegs = this.tegs;
            var description = this.description;
            var complate = this.complate;
            this.$http.post('api/missions/post', { name, tegs, description, complate }).then(function (response) {

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
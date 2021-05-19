
import { HttpService } from './httpservice.js'

export class PostComponent {
    getUsers(url) {
        let $http = new HttpService();
        $http.get(url).then(function (data) {
            console.log(data)
            let length = data.length;
            console.log(length)
            let tbody = document.querySelector("tbody");
            for (var i = 0; i < length; i++) {
                let tr = `<tr><td>${data[i].id}</td><td>${data[i].userName}</td><td>${data[i].password}</td></tr>`
                tbody.innerHTML = tbody.innerHTML + tr
            }
        });
    }
    getBooks(url) {
        let $http = new HttpService();
        $http.get(url).then(function (data) {
            console.log(data)
            let length = data.length;
            console.log(length)
            let tbody = document.querySelector("tbody");
            for (var i = 0; i < length; i++) {
                let tr = `<tr><td>${data[i].id}</td><td>${data[i].title}</td><td>${data[i].description}</td></tr>`
                tbody.innerHTML = tbody.innerHTML + tr
            }
        });
    }

    getAuthors(url) {
        let $http = new HttpService();
        $http.get(url).then(function (data) {
            console.log(data)
            let length = data.length;
            console.log(length)
            let tbody = document.querySelector("tbody");
            for (var i = 0; i < length; i++) {
                let tr = `<tr><td>${data[i].id}</td><td>${data[i].idBook}</td><td>${data[i].firstName}</td><td>${data[i].lastName}</td></tr>`
                tbody.innerHTML = tbody.innerHTML + tr
            }
        });
    }
}
/*
 * "id": 0,
    "title": "string",
    "description": "string",
    "pageCount": 0,
    "excerpt": "string",
    "publishDate": "2021-05-19T04:24:11.143Z"
 * 
 * */



let btn = document.querySelector('[value="Show Users"]')
if (btn != null) {
    btn.addEventListener("click", function () {

        let p = new PostComponent();
        p.getUsers("https://fakerestapi.azurewebsites.net/api/v1/Users")
    })
}


btn = document.querySelector('[value="Show Books"]')
if (btn != null) {
    btn.addEventListener("click", function () {

        let p = new PostComponent();
        p.getBooks("https://fakerestapi.azurewebsites.net/api/v1/Books")
    })
}

btn = document.querySelector('[value="Show Authors"]')
if (btn != null) {
    btn.addEventListener("click", function () {

        let p = new PostComponent();
        p.getAuthors("https://fakerestapi.azurewebsites.net/api/v1/Authors")
    })
}
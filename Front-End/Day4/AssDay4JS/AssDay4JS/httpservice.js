export class HttpService {
    get(url) {
        let x =   fetch(url).then(function (response) {
            return response.json();
        })
        return x;
    }
}

"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const Observable_1 = require("rxjs/Observable");
const http_1 = require("@angular/http");
// Observable class extensions
require("rxjs/add/observable/of");
require("rxjs/add/observable/throw");
// Observable operators
require("rxjs/add/operator/catch");
require("rxjs/add/operator/debounceTime");
require("rxjs/add/operator/distinctUntilChanged");
require("rxjs/add/operator/do");
require("rxjs/add/operator/filter");
require("rxjs/add/operator/map");
require("rxjs/add/operator/switchMap");
let AddressService = class AddressService {
    constructor(_httpService) {
        this._httpService = _httpService;
        this.addresses = new Array();
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });
        this.options = new http_1.RequestOptions({ headers: this.headers });
    }
    getAddressesFromDatabase() {
        return this._httpService
            .get("http://localhost:60000/api/address", this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getUsersFromDatabase() {
        return this._httpService
            .get("http://localhost:60000/api/userdetail", this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getZipsFromDatabase() {
        return this._httpService
            .get("http://localhost:60000/api/zip", this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getServiceById(url) {
        return this._httpService
            .get(url, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    deleteServiceWithId(url, key, val) {
        return this._httpService
            .delete(url + '/?' + key + '=' + val, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    updateService(url, param) {
        let body = JSON.stringify(param);
        console.log(body);
        return this._httpService
            .put(url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    createService(url, param) {
        let body = JSON.stringify(param);
        return this._httpService
            .post(url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    extractData(res) {
        let body = res.json();
        return body || {};
    }
    handleError(error) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable_1.Observable.throw(errMsg);
    }
};
AddressService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], AddressService);
exports.AddressService = AddressService;
//getAddressesFromDatabase() {
//    fetch("http://localhost:60000/api/address").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.addresses = res.data
//            }));
//    console.log("Iz servisa adresee" + this.addresses);
//    return this.addresses;
//}
//    fetch("http://localhost:60000/api/userdetail").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.users = res.data
//        }));
//        return this.users;
//    }
//getZipsFromDatabase() {
//    fetch("http://localhost:60000/api/zip").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.zips = res.data
//        }));
//    return this.zips;
//getAddressesFromDatabase() : Observable<Address[]> {
//     return this._httpService.get('http://localhost:60000/api/address').
//        map(function (res) {
//            var data = res.json();
//            this.getUsersForAddresses;
//            for (let i = 0; i < data.length; i++) {
//                if (data[i].isDeleted == true) 
//                {
//                    data.splice(i, 1);
//                }
//            }
//            console.log(data);
//            return data;
//        });
//}
//getUsersForAddresses() {
//    fetch("http://localhost:60000/api/userdetail").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.usersForAddresses = res.data
//            }));
//}
//returnIfUserIsDeleted(id: number) {
//    return this.usersForAddresses.find(x => x.userId == id).isDeleted;
//}
//getAddressById(id: number) {
//    return this._httpService.get('http://localhost:60000/api/address/' + id)
//        .map(res => res.json())
//}
//getUsersFromDatabase() : Observable<User[]> { 
//    return this._httpService.get('http://localhost:60000/api/userdetail').
//        map(function (res) {
//            var data = res.json();
//            for (let i = 0; i < data.length; i++) {
//                if (data[i].isDeleted == true) {
//                    data.splice(i, 1);
//                }
//            }
//            return data;
//        });
//}
//getZipsFromDatabase(): Observable<Zip[]> {
//    return this._httpService.get('http://localhost:60000/api/zip')
//        .map(res => res.json())
//} 
//# sourceMappingURL=address.service.js.map
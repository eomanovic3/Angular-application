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
const address_service_1 = require("../../shared/services/address.service");
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
let UsersListComponent = class UsersListComponent {
    constructor(addressService, _httpService) {
        this.addressService = addressService;
        this._httpService = _httpService;
        this.users = [];
        this.zips = [];
        this.searchText = '';
    }
    ngOnInit() {
        Observable_1.Observable.forkJoin([this.addressService.getZipsFromDatabase()])
            .mergeMap((data) => {
            this.zips = data[0];
            console.log('proba' + this.zips[0].zipCode);
            return this.addressService.getUsersFromDatabase();
        })
            .subscribe(data => {
            this.users = data;
        });
    }
    OnSearchChange() {
        this.initializeFilteredArray();
    }
    initializeFilteredArray() {
        this.users = this.getUsersBySearch(this.searchText);
    }
    getUsersBySearch(input) {
        if (this.searchText == '') {
            Observable_1.Observable.forkJoin([this.addressService.getZipsFromDatabase()])
                .mergeMap((data) => {
                this.zips = data[0];
                console.log('proba' + this.zips[0].zipCode);
                return this.addressService.getUsersFromDatabase();
            })
                .subscribe(data => {
                this.users = data;
                return this.users;
            });
        }
        return this.users.filter(x => (x.firstName || x.lastName).toLowerCase().includes(input.toLowerCase())).slice();
    }
    deleteUser(id, index) {
        this.users.find(x => x.userId == id).isDeleted = true;
        this.addressService
            .updateService('http://localhost:60000/api/userdetail/' + id, this.users.find(x => x.userId == id))
            .subscribe(result => console.log("6. deleteUser: " + result));
        this.users.splice(index, 1);
    }
};
UsersListComponent = __decorate([
    core_1.Component({
        selector: 'app-users-lists',
        templateUrl: './app/users/users-list/users-list.component.html',
        styleUrls: ['../app/users/users-list/users-list.component.css']
    }),
    __metadata("design:paramtypes", [address_service_1.AddressService, http_1.Http])
], UsersListComponent);
exports.UsersListComponent = UsersListComponent;
//# sourceMappingURL=users-list.component.js.map
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
const address_service_1 = require("../../shared/services/address.service");
const router_1 = require("@angular/router");
const Observable_1 = require("rxjs/Observable");
const http_1 = require("@angular/http");
require("rxjs/add/observable/forkJoin");
// Observable class extensions
require("rxjs/add/observable/of");
require("rxjs/add/observable/throw");
require("rxjs/add/operator/mergeMap");
// Observable operators
require("rxjs/add/operator/catch");
require("rxjs/add/operator/debounceTime");
require("rxjs/add/operator/distinctUntilChanged");
require("rxjs/add/operator/do");
require("rxjs/add/operator/filter");
require("rxjs/add/operator/map");
require("rxjs/add/operator/switchMap");
require("rxjs/add/operator/mergeMap");
let AddressesListComponent = class AddressesListComponent {
    constructor(addressesService, _httpService, route) {
        this.addressesService = addressesService;
        this._httpService = _httpService;
        this.route = route;
        this.users = new Array();
        this.usersNew = new Array();
        this.addresses = new Array();
        this.zips = new Array();
        this.searchText = "";
    }
    OnSearchChange() {
        this.initializeFilteredArray();
    }
    initializeFilteredArray() {
        this.addresses = this.getAddressesBySearch(this.searchText);
    }
    getAddressesBySearch(input) {
        if (this.searchText == '') {
            Observable_1.Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                .mergeMap((data) => {
                this.zips = data[0];
                this.users = data[1];
                return this.addressesService.getServiceById("http://localhost:60000/api/address");
            })
                .subscribe(data => {
                this.addresses = data;
                return this.addresses;
            });
        }
        return this.addresses.filter(x => (x.address1 || x.address2).toLowerCase().includes(input.toLowerCase())).slice();
    }
    ngOnInit() {
        Observable_1.Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
            .mergeMap((data) => {
            this.zips = data[0];
            this.users = data[1];
            return this.addressesService.getServiceById("http://localhost:60000/api/address");
        })
            .subscribe(data => {
            this.addresses = data;
        });
    }
    deleteAddress(id, index) {
        this.addresses.find(x => x.addressId == id).isDeleted = true;
        this.addressesService
            .updateService('http://localhost:60000/api/address/' + id, this.addresses.find(x => x.addressId == id))
            .subscribe(result => console.log("6. deleteAddress: " + result), error => this.errorMessage = error);
        this.addresses.splice(index, 1);
    }
};
AddressesListComponent = __decorate([
    core_1.Component({
        selector: 'app-addresses-list',
        templateUrl: './app/addresses/addresses-list/addresses-list.component.html',
        styleUrls: ['./app/addresses/addresses-list/addresses-list.component.css']
    }),
    __metadata("design:paramtypes", [address_service_1.AddressService, http_1.Http, router_1.ActivatedRoute])
], AddressesListComponent);
exports.AddressesListComponent = AddressesListComponent;
//# sourceMappingURL=addresses-list.component.js.map
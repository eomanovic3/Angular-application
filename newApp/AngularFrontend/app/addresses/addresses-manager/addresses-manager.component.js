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
const forms_1 = require("@angular/forms");
const zip_model_1 = require("../../shared/models/zip.model");
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
let AddressesManagerComponent = class AddressesManagerComponent {
    constructor(addressesService, route) {
        this.addressesService = addressesService;
        this.route = route;
        this.addresses = [];
        this.zips = new Array();
        this.zipOne = new zip_model_1.Zip();
        this.users = new Array();
        this.idAddress = null;
        this.error = false;
        this.success = false;
        this.clicked = false;
    }
    ngOnInit() {
        this.route.params.subscribe((params) => {
            if (params.id) {
                this.idAddress = params.id;
            }
        });
        if (this.idAddress) {
            this.initFormEdit();
        }
        else {
            this.initFormAdd();
        }
        fetch("http://localhost:60000/api/zip").then(response => response.json().then(data => ({
            data: data,
            status: response.status
        })).then(res => {
            this.zips = res.data;
        }));
        fetch("http://localhost:60000/api/userdetail").then(response => response.json().then(data => ({
            data: data,
            status: response.status
        })).then(res => {
            this.users = res.data;
        }));
    }
    initFormEdit() {
        this.addressesService.getServiceById('http://localhost:60000/api/address/' + this.idAddress)
            .subscribe(data => {
            this.addressForEditing = data,
                this.rForm = new forms_1.FormGroup({
                    addressId: new forms_1.FormControl(Number(this.idAddress)),
                    address1: new forms_1.FormControl(this.addressForEditing.address1, [forms_1.Validators.required]),
                    address2: new forms_1.FormControl(this.addressForEditing.address2, forms_1.Validators.required),
                    zipId: new forms_1.FormControl(this.addressForEditing.zipId, [forms_1.Validators.required]),
                    userId: new forms_1.FormControl(this.addressForEditing.userId, forms_1.Validators.required),
                    isDeleted: new forms_1.FormControl(this.addressForEditing.isDeleted, [forms_1.Validators.required])
                });
        });
    }
    initFormAdd() {
        this.addressesService.getAddressesFromDatabase()
            .subscribe(data => {
            this.rForm = new forms_1.FormGroup({
                addressId: new forms_1.FormControl(0, [forms_1.Validators.required]),
                address1: new forms_1.FormControl('', [forms_1.Validators.required]),
                address2: new forms_1.FormControl('', forms_1.Validators.required),
                zipId: new forms_1.FormControl('', [forms_1.Validators.required]),
                userId: new forms_1.FormControl('', forms_1.Validators.required),
                isDeleted: new forms_1.FormControl(false, [forms_1.Validators.required])
            });
        });
    }
    validateForm(form) {
        var address1 = form.get('address1').value;
        var address2 = form.get('address2').value;
        var zipId = form.get('zipId').value;
        var userId = form.get('userId').value;
        if (address1 != '' && address2 != '' && zipId != '' && userId != '') {
            console.log('probaaa');
            return true;
        }
        return false;
    }
    onSubmit() {
        if (this.idAddress != null) {
            this.addressesService.updateService('http://localhost:60000/api/address/' + this.idAddress, this.rForm.value)
                .subscribe(result => {
                console.log("6. edit: " + result),
                    Observable_1.Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                        .mergeMap((data) => {
                        this.zips = data[0];
                        this.users = data[1];
                        return this.addressesService.getAddressesFromDatabase();
                    })
                        .subscribe(data => {
                        this.addresses = data;
                    });
            });
        }
        else {
            this.addressesService.createService('http://localhost:60000/api/address', this.rForm.value)
                .subscribe(result => {
                console.log("6. edit: " + result),
                    Observable_1.Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                        .mergeMap((data) => {
                        this.zips = data[0];
                        this.users = data[1];
                        return this.addressesService.getAddressesFromDatabase();
                    })
                        .subscribe(data => {
                        this.addresses = data;
                    });
            });
            this.rForm.reset();
        }
    }
};
AddressesManagerComponent = __decorate([
    core_1.Component({
        selector: 'app-addresses-manager',
        templateUrl: './app/addresses/addresses-manager/addresses-manager.component.html',
        styleUrls: ['./app/addresses/addresses-manager/addresses-manager.component.css']
    }),
    __metadata("design:paramtypes", [address_service_1.AddressService, router_1.ActivatedRoute])
], AddressesManagerComponent);
exports.AddressesManagerComponent = AddressesManagerComponent;
//# sourceMappingURL=addresses-manager.component.js.map
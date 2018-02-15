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
const forms_1 = require("@angular/forms");
let UsersManagerComponent = class UsersManagerComponent {
    constructor(addressesService, route) {
        this.addressesService = addressesService;
        this.route = route;
        this.users = new Array();
        this.idUser = null;
        this.error = false;
        this.success = false;
        this.clicked = false;
    }
    ngOnInit() {
        this.route.params.subscribe((params) => {
            if (params.id) {
                this.idUser = params.id;
            }
        });
        if (this.idUser) {
            this.initFormEdit();
        }
        else {
            this.initFormAdd();
        }
    }
    initFormEdit() {
        this.addressesService.getServiceById('http://localhost:60000/api/userdetail/' + this.idUser)
            .subscribe(data => {
            this.userForEditing = data,
                this.rForm = new forms_1.FormGroup({
                    userId: new forms_1.FormControl(Number(this.idUser)),
                    firstName: new forms_1.FormControl(this.userForEditing.firstName, [forms_1.Validators.required]),
                    lastName: new forms_1.FormControl(this.userForEditing.lastName, forms_1.Validators.required),
                    userName: new forms_1.FormControl(this.userForEditing.userName, [forms_1.Validators.required]),
                    isDeleted: new forms_1.FormControl(this.userForEditing.isDeleted, forms_1.Validators.required)
                });
        });
    }
    initFormAdd() {
        this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
            .subscribe(data => {
            let lastUser = data.slice(-1)[0];
            this.idUserNew = lastUser.userId;
            ++this.idUserNew;
            this.rForm = new forms_1.FormGroup({
                userId: new forms_1.FormControl(this.idUserNew, [forms_1.Validators.required]),
                firstName: new forms_1.FormControl('', [forms_1.Validators.required]),
                lastName: new forms_1.FormControl('', forms_1.Validators.required),
                userName: new forms_1.FormControl('', [forms_1.Validators.required]),
                isDeleted: new forms_1.FormControl(false, forms_1.Validators.required)
            });
        });
    }
    onSubmit() {
        if (this.idUser != null) {
            this.addressesService.updateService('http://localhost:60000/api/userdetail/' + this.idUser, this.rForm.value)
                .subscribe(result => {
                console.log("6. addd: " + result),
                    this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
                        .subscribe(data => {
                        this.users = data;
                    });
            });
        }
        else {
            this.addressesService.createService('http://localhost:60000/api/userdetail', this.rForm.value)
                .subscribe(result => {
                console.log("6. addd: " + result),
                    this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
                        .subscribe(data => {
                        this.users = data;
                    });
            });
            this.rForm.reset();
        }
    }
};
UsersManagerComponent = __decorate([
    core_1.Component({
        selector: 'app-users-manager',
        templateUrl: './app/users/users-manager/users-manager.component.html',
        styleUrls: ['../app/users/users-manager/users-manager.component.css']
    }),
    __metadata("design:paramtypes", [address_service_1.AddressService, router_1.ActivatedRoute])
], UsersManagerComponent);
exports.UsersManagerComponent = UsersManagerComponent;
//# sourceMappingURL=users-manager.component.js.map
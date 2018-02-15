"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const platform_browser_1 = require("@angular/platform-browser");
const router_1 = require("@angular/router");
const forms_1 = require("@angular/forms");
const http_1 = require("@angular/http");
const app_component_1 = require("./app.component");
const home_component_1 = require("./home/home.component");
const addresses_list_component_1 = require("./addresses/addresses-list/addresses-list.component");
const addresses_manager_component_1 = require("./addresses/addresses-manager/addresses-manager.component");
const users_list_component_1 = require("./users/users-list/users-list.component");
const users_manager_component_1 = require("./users/users-manager/users-manager.component");
const address_service_1 = require("./shared/services/address.service");
const header_component_1 = require("./header.component");
const ams_component_1 = require("./ams/ams.component");
const app_routing_1 = require("./app.routing");
const appRoutes = [
    { path: 'addresses', component: addresses_list_component_1.AddressesListComponent },
    { path: 'addressesManager', component: addresses_manager_component_1.AddressesManagerComponent },
    { path: 'addressesManager/:id', component: addresses_manager_component_1.AddressesManagerComponent }
];
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpModule,
            forms_1.FormsModule,
            app_routing_1.routing,
            forms_1.ReactiveFormsModule,
            router_1.RouterModule.forRoot(appRoutes, { useHash: true, })
        ],
        declarations: [
            app_component_1.AppComponent,
            ams_component_1.AmsComponent,
            home_component_1.HomeComponent,
            header_component_1.HeaderComponent,
            addresses_list_component_1.AddressesListComponent,
            addresses_manager_component_1.AddressesManagerComponent,
            users_list_component_1.UsersListComponent,
            users_manager_component_1.UsersManagerComponent
        ],
        bootstrap: [
            app_component_1.AppComponent
        ],
        providers: [address_service_1.AddressService
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map
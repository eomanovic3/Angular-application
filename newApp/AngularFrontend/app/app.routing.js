"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const router_1 = require("@angular/router");
const addresses_list_component_1 = require("./addresses/addresses-list/addresses-list.component");
const addresses_manager_component_1 = require("./addresses/addresses-manager/addresses-manager.component");
const users_list_component_1 = require("./users/users-list/users-list.component");
const users_manager_component_1 = require("./users/users-manager/users-manager.component");
const home_component_1 = require("./home/home.component");
const APP_ROUTES = [
    { path: 'addresses', component: addresses_list_component_1.AddressesListComponent },
    { path: 'users', component: users_list_component_1.UsersListComponent },
    { path: 'addressesManager', component: addresses_manager_component_1.AddressesManagerComponent },
    { path: 'usersManager', component: users_manager_component_1.UsersManagerComponent },
    { path: 'addressesManager/:id', component: addresses_manager_component_1.AddressesManagerComponent },
    { path: 'usersManager/:id', component: users_manager_component_1.UsersManagerComponent },
    { path: 'home', component: home_component_1.HomeComponent },
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    { path: '**', component: addresses_list_component_1.AddressesListComponent }
];
exports.routing = router_1.RouterModule.forRoot(APP_ROUTES);
//# sourceMappingURL=app.routing.js.map
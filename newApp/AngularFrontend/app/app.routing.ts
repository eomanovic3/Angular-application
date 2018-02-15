import { Routes, RouterModule } from '@angular/router';

import { AddressesListComponent } from './addresses/addresses-list/addresses-list.component';
import { AddressesManagerComponent } from './addresses/addresses-manager/addresses-manager.component';

import { UsersListComponent } from './users/users-list/users-list.component';
import { UsersManagerComponent } from './users/users-manager/users-manager.component';

import { HomeComponent } from './home/home.component';

const APP_ROUTES: Routes = [
    { path: 'addresses', component: AddressesListComponent },
    { path: 'users', component: UsersListComponent },

    { path: 'addressesManager', component: AddressesManagerComponent },
    { path: 'usersManager', component: UsersManagerComponent },

    { path: 'addressesManager/:id', component: AddressesManagerComponent },
    { path: 'usersManager/:id', component: UsersManagerComponent },


    { path: 'home', component: HomeComponent },

    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    { path: '**', component: AddressesListComponent }
];

export const routing = RouterModule.forRoot(APP_ROUTES);
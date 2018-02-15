import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { AddressesListComponent } from './addresses/addresses-list/addresses-list.component';
import { AddressesManagerComponent } from './addresses/addresses-manager/addresses-manager.component';

import { UsersListComponent } from './users/users-list/users-list.component';
import { UsersManagerComponent } from './users/users-manager/users-manager.component';

import { AddressService } from './shared/services/address.service';
import { HeaderComponent } from './header.component'

import { Address } from './shared/models/address.model'; 
import { City } from './shared/models/city.model'; 
import {County} from './shared/models/county.model'; 
import { State} from './shared/models/state.model'; 
import { Zip } from './shared/models/zip.model';
 
import {AmsComponent} from './ams/ams.component';
import { routing } from './app.routing';


const appRoutes: Routes = [
    { path: 'addresses', component: AddressesListComponent },
    { path: 'addressesManager', component: AddressesManagerComponent },
    { path: 'addressesManager/:id', component: AddressesManagerComponent }
];



@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        routing,        
        ReactiveFormsModule,
        RouterModule.forRoot(appRoutes, { useHash: true, })
    ],
    declarations: [
        AppComponent,
        AmsComponent,
        HomeComponent,
        HeaderComponent,       
        AddressesListComponent,       
        AddressesManagerComponent,
        UsersListComponent,
        UsersManagerComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [AddressService
    ]
})
export class AppModule {
}
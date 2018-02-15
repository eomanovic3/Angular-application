import { Component, OnInit, NgModule } from '@angular/core';
import { Address } from '../../shared/models/address.model';
import { AddressService } from '../../shared/services/address.service';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../shared/models/user.model';
import { Zip } from '../../shared/models/zip.model';

import { Observable } from 'rxjs/Observable';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';

import { FormsModule, FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { forkJoin } from "rxjs/observable/forkJoin";
import 'rxjs/add/observable/forkJoin';

// Observable class extensions
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/mergeMap';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';

@Component({
    selector: 'app-addresses-list',
    templateUrl: './app/addresses/addresses-list/addresses-list.component.html',
    styleUrls: ['./app/addresses/addresses-list/addresses-list.component.css']
})
export class AddressesListComponent implements OnInit {
    errorMessage: any;

    users: User[] = new Array<User>();
    usersNew: User[] = new Array<User>();
    addresses: Address[] = new Array<Address>();
    address: Address; user: User;
    zips: Zip[] = new Array<Zip>();
    searchText: string = "";

    OnSearchChange() {
        this.initializeFilteredArray();
    }
    public initializeFilteredArray(): void {
        this.addresses = this.getAddressesBySearch(this.searchText);        
    }

    public getAddressesBySearch(input: string): Address[] {
        if (this.searchText == '') {
            Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                .mergeMap((data: any[]) => {
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

    constructor(private addressesService: AddressService, private _httpService: Http, private route: ActivatedRoute) { }

    ngOnInit() {
        Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
            .mergeMap((data: any[]) => {
                this.zips = data[0];
                this.users = data[1];
                return this.addressesService.getServiceById("http://localhost:60000/api/address");
            })
            .subscribe(data => {
                this.addresses = data
            });    
    }
  

    deleteAddress(id: number, index: number) {
        this.addresses.find(x => x.addressId == id).isDeleted = true;
        this.addressesService
            .updateService('http://localhost:60000/api/address/' + id, this.addresses.find(x => x.addressId == id))
            .subscribe(
            result => console.log("6. deleteAddress: " + result),
            error => this.errorMessage = <any>error
            );
        this.addresses.splice(index, 1);
    }
}
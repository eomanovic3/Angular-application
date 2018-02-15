import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AddressService } from '../../shared/services/address.service';
import { Address } from '../../shared/models/address.model';
import { Zip } from '../../shared/models/zip.model';
import { User } from '../../shared/models/user.model';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';

// Observable class extensions
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'app-users-lists',
    templateUrl: './app/users/users-list/users-list.component.html',
    styleUrls: ['../app/users/users-list/users-list.component.css']

})
export class UsersListComponent implements OnInit {
    
    data: string;
    loading: boolean;
    user: User;
    users: User[] = [];
    zips: Zip[] = [];
    searchText: string = '';

    constructor(private addressService: AddressService, private _httpService: Http) { }  
    
    ngOnInit() {
        Observable.forkJoin([this.addressService.getZipsFromDatabase()])
            .mergeMap((data: any[]) => {
                this.zips = data[0];
                console.log('proba' + this.zips[0].zipCode);
                return this.addressService.getUsersFromDatabase();
            })
            .subscribe(data => {
                this.users = data
            }); 

    }
    OnSearchChange() {
        this.initializeFilteredArray();
    }
    public initializeFilteredArray(): void {
        this.users = this.getUsersBySearch(this.searchText);
    }

    public getUsersBySearch(input: string): User[] {
        if (this.searchText == '') {
            Observable.forkJoin([this.addressService.getZipsFromDatabase()])
                .mergeMap((data: any[]) => {
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
    deleteUser(id: number, index: number) {
        this.users.find(x => x.userId == id).isDeleted = true;
        this.addressService
            .updateService('http://localhost:60000/api/userdetail/' + id, this.users.find(x => x.userId == id))
            .subscribe(
            result => console.log("6. deleteUser: " + result)
            );
        this.users.splice(index, 1);
    }
}
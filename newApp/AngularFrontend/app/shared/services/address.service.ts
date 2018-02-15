import { EventEmitter, Injectable, OnInit } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';
import { Address } from "../models/address.model";
import { User } from "../models/user.model";
import { Zip } from "../models/zip.model";

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


@Injectable()
export class AddressService {

    addresses: Address[] = new Array<Address>();
    users: User[];
    usersForAddresses: User[];
    zips: Zip[];
    headers: Headers;
    options: RequestOptions;

    constructor(private _httpService: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });
        this.options = new RequestOptions({ headers: this.headers });
    }

    getAddressesFromDatabase(): Observable<Address[]> {
        return this._httpService
            .get("http://localhost:60000/api/address", this.options)
            .map(this.extractData)
            .catch(this.handleError);
     }
    getUsersFromDatabase(): Observable<any> {
        return this._httpService
            .get("http://localhost:60000/api/userdetail", this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getZipsFromDatabase(): Observable<any> {
        return this._httpService
            .get("http://localhost:60000/api/zip", this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getServiceById(url: string): Observable<any> {
        return this._httpService
            .get(url, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    deleteServiceWithId(url: string, key: string, val: string): Observable<any> {
        return this._httpService
            .delete(url + '/?' + key + '=' + val, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    updateService(url: string, param: any): Observable<any> {
        let body = JSON.stringify(param);
        console.log(body);
        return this._httpService
            .put(url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    createService(url: string, param: any): Observable<any> {
        let body = JSON.stringify(param);
        return this._httpService
            .post(url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}




//getAddressesFromDatabase() {
    //    fetch("http://localhost:60000/api/address").then(response =>
    //        response.json().then(data => ({
    //            data: data,
    //            status: response.status
    //        })
    //        ).then(res => {
    //            console.log(res.data),
    //                this.addresses = res.data
    //            }));
    //    console.log("Iz servisa adresee" + this.addresses);
    //    return this.addresses;
    //}
//    fetch("http://localhost:60000/api/userdetail").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.users = res.data
//        }));
//        return this.users;
//    }

//getZipsFromDatabase() {

//    fetch("http://localhost:60000/api/zip").then(response =>
//        response.json().then(data => ({
//            data: data,
//            status: response.status
//        })
//        ).then(res => {
//            console.log(res.data),
//                this.zips = res.data
//        }));
//    return this.zips;


    //getAddressesFromDatabase() : Observable<Address[]> {

    //     return this._httpService.get('http://localhost:60000/api/address').
    //        map(function (res) {
    //            var data = res.json();
    //            this.getUsersForAddresses;
    //            for (let i = 0; i < data.length; i++) {
    //                if (data[i].isDeleted == true) 
    //                {
    //                    data.splice(i, 1);
    //                }
    //            }

    //            console.log(data);
    //            return data;
    //        });
    //}
    //getUsersForAddresses() {
    //    fetch("http://localhost:60000/api/userdetail").then(response =>
    //        response.json().then(data => ({
    //            data: data,
    //            status: response.status
    //        })
    //        ).then(res => {
    //            console.log(res.data),
    //                this.usersForAddresses = res.data
    //            }));
    //}
    //returnIfUserIsDeleted(id: number) {
    //    return this.usersForAddresses.find(x => x.userId == id).isDeleted;
    //}
    //getAddressById(id: number) {
    //    return this._httpService.get('http://localhost:60000/api/address/' + id)
    //        .map(res => res.json())
    //}
    //getUsersFromDatabase() : Observable<User[]> { 
    //    return this._httpService.get('http://localhost:60000/api/userdetail').
    //        map(function (res) {
    //            var data = res.json();
    //            for (let i = 0; i < data.length; i++) {
    //                if (data[i].isDeleted == true) {
    //                    data.splice(i, 1);
    //                }
    //            }
    //            return data;
    //        });
    //}
    //getZipsFromDatabase(): Observable<Zip[]> {
    //    return this._httpService.get('http://localhost:60000/api/zip')
    //        .map(res => res.json())
    //}
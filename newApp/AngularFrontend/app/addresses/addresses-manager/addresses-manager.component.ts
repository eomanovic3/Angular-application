import { Component, OnInit, NgModule } from '@angular/core';
import { Address } from '../../shared/models/address.model';
import { AddressService } from '../../shared/services/address.service';
import { ActivatedRoute } from '@angular/router';


import { Observable } from 'rxjs/Observable';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';
import { FormsModule, FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser'
import { Zip } from "../../shared/models/zip.model";
import { User } from "../../shared/models/user.model";
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
    selector: 'app-addresses-manager',
    templateUrl: './app/addresses/addresses-manager/addresses-manager.component.html',
    styleUrls: ['./app/addresses/addresses-manager/addresses-manager.component.css']
})
export class AddressesManagerComponent implements OnInit {

    addresses: Address[] = [];

    zips: Zip[] = new Array<Zip>();
    zipOne: Zip = new Zip();

    users: User[] = new Array<User>();
    userOne: User;

    addressForEditing: Address;
    idAddress: number = null;
    idAddressNew: number;

    error: boolean = false;
    success: boolean = false;
    message: string;
    rForm: FormGroup;

    ngOnInit() {
        this.route.params.subscribe((params: any) => {
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
        fetch("http://localhost:60000/api/zip").then(response =>
            response.json().then(data => ({
                data: data,
                status: response.status
            })
            ).then(res => {
                this.zips = res.data
            }));
        fetch("http://localhost:60000/api/userdetail").then(response =>
            response.json().then(data => ({
                data: data,
                status: response.status
            })
            ).then(res => {
                this.users = res.data
            }));

    }


    clicked: boolean = false;
    constructor(private addressesService: AddressService, private route: ActivatedRoute) { }

    private initFormEdit() {
        this.addressesService.getServiceById('http://localhost:60000/api/address/' + this.idAddress)
            .subscribe(data => {
                this.addressForEditing = data,
                    this.rForm = new FormGroup({
                        addressId: new FormControl(Number(this.idAddress)),
                        address1: new FormControl(this.addressForEditing.address1, [Validators.required]),
                        address2: new FormControl(this.addressForEditing.address2, Validators.required),
                        zipId: new FormControl(this.addressForEditing.zipId, [Validators.required]),
                        userId: new FormControl(this.addressForEditing.userId, Validators.required),
                        isDeleted: new FormControl(this.addressForEditing.isDeleted, [Validators.required])
                    })
            });
    }

    private initFormAdd() {
        this.addressesService.getAddressesFromDatabase()
            .subscribe(data => {
                this.rForm = new FormGroup({
                    addressId: new FormControl(0, [Validators.required]),
                    address1: new FormControl('', [Validators.required]),
                    address2: new FormControl('', Validators.required),
                    zipId: new FormControl('', [Validators.required]),
                    userId: new FormControl('', Validators.required),
                    isDeleted: new FormControl(false, [Validators.required])
                })
            });
    }
    private validateForm(form: FormGroup) {
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
        if (this.idAddress != null){
            this.addressesService.updateService('http://localhost:60000/api/address/' + this.idAddress, this.rForm.value)
                .subscribe(
                result => {
                    console.log("6. edit: " + result),
                         Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                            .mergeMap((data: any[]) => {
                                this.zips = data[0];
                                this.users = data[1];
                                return this.addressesService.getAddressesFromDatabase();
                            })
                            .subscribe(data => {
                                this.addresses = data
                            });
                      }
                );
        }

        else {
            this.addressesService.createService('http://localhost:60000/api/address', this.rForm.value)
                .subscribe(
                result => {
                    console.log("6. edit: " + result),
                        Observable.forkJoin([this.addressesService.getZipsFromDatabase(), this.addressesService.getUsersFromDatabase()])
                            .mergeMap((data: any[]) => {
                                this.zips = data[0];
                                this.users = data[1];
                                return this.addressesService.getAddressesFromDatabase();
                            })
                            .subscribe(data => {
                                this.addresses = data
                            });
                      }
                );
            this.rForm.reset();
        }
    }

}


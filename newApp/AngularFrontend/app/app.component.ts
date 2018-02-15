import { Component, Input, OnInit } from '@angular/core';

//our root app component
import { NgModule } from '@angular/core'
import { FormsModule, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser'
import { Configuration } from '../app/app.constants';
import { Observable } from 'rxjs/Observable';
import { AddressService } from '../app/shared/services/address.service';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Address } from "./shared/models/address.model";

@Component({
    selector: 'my-app',
    templateUrl: '../app/app.component.html',
    styleUrls: ['../app/app.component.css']
})
export class AppComponent implements OnInit {

    constructor(private _httpService: Http, private serviceAddress:AddressService) { }
    
    ngOnInit() {
    }    
}  
    
   

   


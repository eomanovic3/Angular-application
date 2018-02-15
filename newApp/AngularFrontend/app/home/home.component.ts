import { Component, OnInit, NgModule } from '@angular/core';
import { Address } from '../shared/models/address.model';
import { AddressService } from '../shared/services/address.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: './app/home/home.component.html',
    styleUrls: ['./app/home/home.component.css']
})
export class HomeComponent implements OnInit {

    ngOnInit(): void {

    }
}
import { Component, OnInit, Input } from '@angular/core';
import { AddressService } from '../../shared/services/address.service';
import { Address } from '../../shared/models/address.model';
import { Zip } from '../../shared/models/zip.model';
import { User } from '../../shared/models/user.model';
import { Http, Response, Headers } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { FormsModule, FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';


@Component({
    selector: 'app-users-manager',
    templateUrl: './app/users/users-manager/users-manager.component.html',
    styleUrls: ['../app/users/users-manager/users-manager.component.css']

})
export class UsersManagerComponent {


    users: User[] = new Array<User>();
    userForEditing: User;
    userOne: User;

    idUser: number = null;
    error: boolean = false;
    success: boolean = false;
    message: string;
    idUserNew: number;
    rForm: FormGroup;

    ngOnInit() {

        this.route.params.subscribe((params: any) => {
            if (params.id) {
                this.idUser = params.id;
            }
        });

        if (this.idUser) {
            this.initFormEdit();
        }
        else {
            this.initFormAdd();
        }
    }


    clicked: boolean = false;
    constructor(private addressesService: AddressService, private route: ActivatedRoute) { }

    private initFormEdit() {
        this.addressesService.getServiceById('http://localhost:60000/api/userdetail/' + this.idUser)
            .subscribe(data => {
                this.userForEditing = data,
                    this.rForm = new FormGroup({
                        userId: new FormControl(Number(this.idUser)),
                        firstName: new FormControl(this.userForEditing.firstName, [Validators.required]),
                        lastName: new FormControl(this.userForEditing.lastName, Validators.required),
                        userName: new FormControl(this.userForEditing.userName, [Validators.required]),
                        isDeleted: new FormControl(this.userForEditing.isDeleted, Validators.required)
                    })
            });
    }

    private initFormAdd() {
        this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
            .subscribe(data => {
                let lastUser = data.slice(-1)[0];
                this.idUserNew = lastUser.userId;
                ++this.idUserNew;

                this.rForm = new FormGroup({
                    userId: new FormControl(this.idUserNew, [Validators.required]),
                    firstName: new FormControl('', [Validators.required]),
                    lastName: new FormControl('', Validators.required),
                    userName: new FormControl('', [Validators.required]),
                    isDeleted: new FormControl(false, Validators.required)
                })
            });
    }

    onSubmit() {
        if (this.idUser != null)
        {
            this.addressesService.updateService('http://localhost:60000/api/userdetail/' + this.idUser, this.rForm.value)
                .subscribe(
                result => {
                    console.log("6. addd: " + result),
                        this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
                            .subscribe(data => {
                                this.users = data
                            });
                });
        }
        else
        {

            this.addressesService.createService('http://localhost:60000/api/userdetail', this.rForm.value)
                .subscribe(
                result => {
                    console.log("6. addd: " + result),
                        this.addressesService.getServiceById('http://localhost:60000/api/userdetail')
                            .subscribe(data => {
                                this.users = data
                            });
                });
            this.rForm.reset();
        }
    }
}



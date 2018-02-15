import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

@Injectable()
export class Configuration {
    
    public Server = 'http://localhost:6000/';
    public ApiUrl = 'api/';
    public ServerWithApiUrl = this.Server + this.ApiUrl;    

   
}

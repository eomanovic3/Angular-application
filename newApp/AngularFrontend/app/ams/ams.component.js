"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
//import { AccordionModule } from '../node_modules/bootstrap/ngx-bootstrap/accordion';
//@NgModule({
//    imports: [AccordionModule.forRoot(), ...]
//})
//export class AppModule(){}
let AmsComponent = class AmsComponent {
    constructor() { }
    //log(event: boolean) {
    //    console.log(`Accordion has been ${event ? 'opened' : 'closed'}`);
    //}
    ngOnInit() {
    }
};
AmsComponent = __decorate([
    core_1.Component({
        selector: 'app-ams',
        templateUrl: './app/ams/ams.component.html',
        styleUrls: ['./app/ams/ams.component.css']
    }),
    __metadata("design:paramtypes", [])
], AmsComponent);
exports.AmsComponent = AmsComponent;
//# sourceMappingURL=ams.component.js.map
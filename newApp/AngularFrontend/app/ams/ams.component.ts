import { Component, OnInit } from '@angular/core';
//import { AccordionModule } from '../node_modules/bootstrap/ngx-bootstrap/accordion';

//@NgModule({
//    imports: [AccordionModule.forRoot(), ...]
//})
//export class AppModule(){}
@Component({
  selector: 'app-ams',
  templateUrl: './app/ams/ams.component.html',
  styleUrls: ['./app/ams/ams.component.css']
})
export class AmsComponent implements OnInit {

  constructor() { }

  //log(event: boolean) {
  //    console.log(`Accordion has been ${event ? 'opened' : 'closed'}`);
  //}
  ngOnInit() {

  }
}

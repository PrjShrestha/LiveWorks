//import { Component,Inject } from '@angular/core';
//import { Item } from "../../EntityDto/Item";
//import { Http } from '@angular/http';

//@Component({
//    selector: 'app',
//    templateUrl: './app.component.html',
//    styleUrls: ['./app.component.css']
//})

//export class AppComponent {

//    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
//        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
//            this.items = result.json() as Item[];
//        }, error => console.error(error));
//    }

//    items: Item[];
//    pageNumber: number = 1;

//    ngOnInit() {
//        this.items = [
//            new Item(1, "Hello", 20, "Guitar", "20x40", 5, 5, "30 Dec 2017")
//        ]
//    }

//    sort(key) {
//        this.key = key;
//        this.reverse = !this.reverse;
//    }

//}

import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Item } from '../../../EntityDto/item';

@Component({
    selector: 'app-item-list',
    templateUrl: './item-list.component.html'
})
export class ItemListComponent implements OnInit {
    public items: Item[];
    pageNumber: 1;

    ngOnInit() {
        this.items = [
            new Item(1,'Guitar', 2,'music',4,'desc',
                '5x2', 'Ktm', 5, new Date(), 3),
            new Item(2, 'Guitar', 2, 'music', 4, 'desc',
                '5x2', 'Ktm', 5, new Date(), 3),
            new Item(3, 'Guitar', 2, 'music', 4, 'desc',
                '5x2', 'Ktm', 5, new Date(), 3),
            new Item(4, 'Guitar', 2, 'music', 4, 'desc',
                '5x2', 'Ktm', 5, new Date(), 3),
            new Item(5, 'Guitar', 2, 'music', 4, 'desc',
                '5x2', 'Ktm', 5, new Date(), 3),
            new Item(6, 'Guitar', 2, 'music', 4, 'desc',
                '5x2', 'Ktm', 5, new Date(), 3)
        
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //},
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //},
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //},
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //},
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //},
            //{
            //    id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
            //    dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
            //}
        ]

        console.log(this.items);
    }


    // constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //     console.log(baseUrl);
    //     // http.get(baseUrl + 'api/Item/').subscribe(result => {
    //     //     this.items = result.json() as Item[];
    //     // }, error => console.error(error));

    //     this.items = [
    //         new Item(1, 'Guitar', 2, 'hello', 4, 'desc', '5x2', 'Ktm', 5, new Date(), 3),
    //         new Item(2, 'Guitar', 2, 'hello', 4, 'desc', '5x2', 'Ktm', 5, new Date(), 3)
    //     ]
    // }
}


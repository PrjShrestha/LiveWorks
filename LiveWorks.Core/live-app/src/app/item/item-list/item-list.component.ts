import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Item } from '../../EntityDto/item';
import { ItemService } from '../itemService';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ItemAddEditComponent } from '../item-add-edit/item-add-edit.component';

@Component({
    selector: 'app-item-list',
    templateUrl: './item-list.component.html',
    styleUrls: ['./item-list.component.sass']
})
export class ItemListComponent implements OnInit {
    errorMessage: string;
    public items: Item[];
    pageNumber: 1;
    response: any;
    key = 'name';
    reverse = false;
    item: Item;

    constructor(
        protected itemservice: ItemService,
        private router: Router,
        private modalService: NgbModal
    ) { }

    ngOnInit() {

        this.itemservice.getAll().subscribe(
            filteredResponse => {
                this.items = filteredResponse.value as Item[];
            },
            error => {
                console.log(error);
            }

        );

        console.log(this.items);
    }

    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;
    }

    openAddEditItem(item?: Item) {
        if (item != null) {
            this.itemservice.getById(item.id).subscribe(
                filteredResponse => {
                    this.item = filteredResponse.value as Item;
                    const itemAddEditInstance = this.getItemAddEditInstance(this.item);
                    itemAddEditInstance.onItemEditEvent.subscribe(
                        data => {
                            this.updateGridAfterEdit(data);
                        },
                        error => {
                            this.setErrorMessage('Error while adding Item.', error.message)
                        }
                    )
                }

            );
        } else {
            const itemAddEditInstance = this.getItemAddEditInstance(this.item = new Item());
            itemAddEditInstance.onItemAddEvent.subscribe(
                data => {
                    this.items.push(data);
                },
                error => {
                    this.setErrorMessage('Error while adding Item.', error.message)
                }
            )
        }
    }

    setErrorMessage(message, error) {
        this.errorMessage = `${message}\n Server Response: ${error.message}`;
    }

    getItemAddEditInstance(item: Item) {
        const modalRef = this.modalService.open(ItemAddEditComponent);
        const itemAddEditInstance = modalRef.componentInstance;
        itemAddEditInstance.item = this.item;
        itemAddEditInstance.addMode = item.id == null;
        return itemAddEditInstance;
    }

    private updateGridAfterEdit(item) {
        const indexToUpdate = this.items.findIndex((i: Item) => i.id === item.id);

        if (indexToUpdate > - 1) {
            this.items[indexToUpdate] = item;
        }
    }

    deleteItem(item) {
        if (window.confirm('Are you sure you want to delete this Item?')) {
            this.itemservice.delete(item.id).subscribe(
                response => {
                    const itemIndex = this.items.findIndex(i => i.id === item.id);
                    if (itemIndex > -1) {
                        this.items.splice(itemIndex, 1);
                    }
                    window.alert('Item was successfully deleted');
                },
                error => {
                    this.setErrorMessage('Error while adding Item.', error.message);
                }

            )
        }
    }
}



            // this.items = [
        //     {
        //         id: 1, name: 'Amp', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
        //     },
        //     {id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 4
        //     },
        //     {
        //         id: 1, name: 'Zoom', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
        //     },
        //     {
        //         id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 2
        //     },
        //     {
        //         id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
        //     },
        //     {
        //         id: 1, name: 'Guitar', price: 2, type: 'music', rentalPrice: 4, description: 'desc',
        //         dimension: '5x2', supplier: 'Ktm', availableQuantity: 5, restockDate: new Date(), restockQuantity: 3
        //     }
        // ]


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



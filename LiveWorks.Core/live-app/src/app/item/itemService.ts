import { Injectable } from '@angular/core';
import { HttpCrudService } from '../shared/http-crud.service';
import { Item } from '../EntityDto/item';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class ItemService extends HttpCrudService<Item> {

    constructor(protected http: HttpClient ) {
        super(http);

    }
    protected getBaseEndPoint(): string {
       return 'item';
    }

}
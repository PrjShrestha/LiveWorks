import { Injectable } from '@angular/core';
import { HttpCrudService } from '../shared/http-crud.service';
import { Category } from '../EntityDto/category';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class CategoryService extends HttpCrudService<Category> {

    constructor(protected http: HttpClient ) {
        super(http);

    }
    protected getBaseEndPoint(): string {
       return 'category';
    }

}
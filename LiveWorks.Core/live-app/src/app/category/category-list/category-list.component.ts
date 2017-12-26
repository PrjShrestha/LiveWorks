import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Category } from '../../EntityDto/category';
import { CategoryService } from '../categoryService';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoryAddEditComponent } from '../category-add-edit/category-add-edit.component';

@Component({
    selector: 'app-category-list',
    templateUrl: './category-list.component.html',
    styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
    errorMessage: string;
    public categories: Category[];
    pageNumber: 1;
    response: any;
    key = 'name';
    reverse = false;
    category: Category;

    constructor(
        protected categoryService: CategoryService,
        private router: Router,
        private modalService: NgbModal
    ) { }

    ngOnInit() {

        this.categoryService.getAll().subscribe(
            filteredResponse => {
                this.categories = filteredResponse.value as Category[];
            },
            error => {
                console.log(error);
            }

        );

        console.log(this.categories);
    }

    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;
    }

    openAddEditcategory(category?: Category) {
        if (category != null) {
            this.categoryService.getById(category.id).subscribe(
                filteredResponse => {
                    this.category = filteredResponse.value as Category;
                    const categoryAddEditInstance = this.getcategoryAddEditInstance(this.category);
                    categoryAddEditInstance.oncategoryAddEvent.subscribe(
                        data => {
                            this.updateGridAfterEdit(data);
                        },
                        error => {
                            this.setErrorMessage('Error while adding category.', error.message)
                        }
                    )
                }

            );
        } else {
            const categoryAddEditInstance = this.getcategoryAddEditInstance(this.category = new Category());
            categoryAddEditInstance.oncategoryEditEvent.subscribe(
                data => {
                    this.categories.push(data);
                },
                error => {
                    this.setErrorMessage('Error while adding category.', error.message)
                }
            )
        }
    }

    setErrorMessage(message, error) {
        this.errorMessage = `${message}\n Server Response: ${error.message}`;
    }

    getcategoryAddEditInstance(category: Category) {
        const modalRef = this.modalService.open(CategoryAddEditComponent);
        const categoryAddEditInstance = modalRef.componentInstance;
        categoryAddEditInstance.category = this.category;
        categoryAddEditInstance.addMode = category.id == null;
        return categoryAddEditInstance;
    }

    private updateGridAfterEdit(category) {
        const indexToUpdate = this.categories.findIndex((i: Category) => i.id === category.id);

        if (indexToUpdate > - 1) {
            this.categories[indexToUpdate] = category;
        }
    }

    deletecategory(category) {
        if (window.confirm('Are you sure you want to delete this category?')) {
            this.categoryService.delete(category.id).subscribe(
                response => {
                    const categoryIndex = this.categories.findIndex(i => i.id === category.id);
                    if (categoryIndex > -1) {
                        this.categories.splice(categoryIndex, 1);
                    }
                    window.alert('category was successfully deleted');
                },
                error => {
                    this.setErrorMessage('Error while adding category.', error.message);
                }

            )
        }
    }
}






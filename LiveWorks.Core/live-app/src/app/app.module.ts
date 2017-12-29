import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetchdata/fetchdata.component';
import { CounterComponent } from './counter/counter.component';
import { ItemListComponent } from './item/item-list/item-list.component';
import { ItemService } from './item/item.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ItemAddEditComponent } from './item/item-add-edit/item-add-edit.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryAddEditComponent } from './category/category-add-edit/category-add-edit.component';
import { CategoryService } from './category/categoryService';
import { AddEditStockInComponent } from './stockIn/add-edit-stock-in/add-edit-stock-in.component';
import { StockInListComponent } from './stockIn/stock-in-list/stock-in-list.component';
import { StockOutListComponent } from './stockOut/stock-out-list/stock-out-list.component';
import { AddEditStockOutComponent } from './stockOut/add-edit-stock-out/add-edit-stock-out.component';
import { StockListComponent } from './stock/stock-list/stock-list.component';
import { AddEditStockComponent } from './stock/add-edit-stock/add-edit-stock.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    ItemListComponent,
    HomeComponent,
    ItemAddEditComponent,
    CategoryListComponent,
    CategoryAddEditComponent,
    AddEditStockInComponent,
    StockInListComponent,
    StockOutListComponent,
    AddEditStockOutComponent,
    StockListComponent,
    AddEditStockComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    OrderModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'item-list', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'item-list', component: ItemListComponent },
      { path: 'category-list', component: CategoryListComponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
    ItemService,
    CategoryService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ItemAddEditComponent
  ]
})
export class AppModule { }

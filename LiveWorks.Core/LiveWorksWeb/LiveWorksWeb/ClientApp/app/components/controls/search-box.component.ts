﻿// ======================================
// Author: liveworks  
// Email:  info@liveworks.com
// Copyright (c) 2017 www.liveworks.com
// 
// ==> Gun4Hire: contact@liveworks.com
// ======================================

import { Component, ViewChild, ElementRef, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'search-box',
    templateUrl: './search-box.component.html',
    styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent {

    @Input()
    placeholder: string = "Search...";

    @Output()
    searchChange = new EventEmitter<string>();

    @ViewChild("searchInput")
    searchInput: ElementRef;


    onValueChange(value: string) {
        setTimeout(() => this.searchChange.emit(value));
    }


    clear() {
        this.searchInput.nativeElement.value = '';
        this.onValueChange(this.searchInput.nativeElement.value);
    }
}
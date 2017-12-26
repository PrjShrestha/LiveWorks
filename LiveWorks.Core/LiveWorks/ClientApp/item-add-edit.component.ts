//import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
//import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
//import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

//@Component({
//  selector: 'app-item-add-edit',
//  templateUrl: './item-add-edit.component.html',
//  styleUrls: ['./item-add-edit.component.sass']
//})
//export class itemAddEditComponent implements OnInit {

//  addMode: boolean;
//  versions: string[];
//  defaultVersionValue: string;
//  btnText: string;
//  modalTitle: string;
//  @Input() item: item;
//  @Output() onAdditemEvent: EventEmitter<any> = new EventEmitter<any>();
//  @Output() onEdititemEvent: EventEmitter<any> = new EventEmitter<any>();


//  // getting all item types from enum and reading from html
//  types(): Array<string> {
//    var keys = Object.keys(this.itemType);
//    return keys.slice(keys.length / 2);
//  }
//  schemeTypes(): Array<string> {
//    var keys = Object.keys(this.priceType);
//    return keys.slice(keys.length / 2);
//  }
//  constructor(
//    private activeModal: NgbActiveModal,
//    private itemService: itemService

//  ) { }

//  ngOnInit() {
//    this.types();
//    this.schemeTypes();
//    this.item.price=this.addMode ?this.price.GenerateFull: this.item.price;
//    this.btnText = this.addMode ? "Save" : "Update";
//    this.modalTitle = this.addMode ? "Add New item" : `Edit item ${this.item.name}`;
//    this.itemService.getBasedOnStandardVersionList().subscribe(res => this.versions = res);
//  }

//  saveModel(item: item) {
//    if (item.id == null) {
//      this.itemService.add(item).subscribe(
//        response => {
//          this.onAdditemEvent.emit(response.value as item)
//        })

//    }
//    else {
//      this.itemService.update(item).subscribe(
//        response => {
//          this.onEdititemEvent.emit(response.value as item)
//        })
//    }
//    this.activeModal.close();
//  }

//  dismissActiveModal(parm)
//  {
//    this.activeModal.dismiss(parm);
//  }

//}

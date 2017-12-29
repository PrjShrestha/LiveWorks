import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {NgModel, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { NgbActiveModal, ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { ItemService } from '../item.service';
import { Item } from '../../EntityDto/item';

@Component({
  selector: 'app-item-add-edit',
  templateUrl: './item-add-edit.component.html',
  styleUrls: ['./item-add-edit.component.scss']
})
export class ItemAddEditComponent implements OnInit {

  addMode: boolean;
  btnText: string;
  modalTitle: string;
  @Input() item: Item;
  @Output() onItemEditEvent: EventEmitter<any> = new EventEmitter<any>();
  @Output() onItemAddEvent: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private activeModal: NgbActiveModal,
    private itemService: ItemService

  ) { }

  ngOnInit() {
    this.btnText = this.addMode ? 'Save' : 'Update';
    this.modalTitle = this.addMode ? 'Add New Item' : `Edit Item ${this.item.name}`;
  }

  saveItem(item: Item){
     if(item.id == null){
       this.itemService.add(item).subscribe(
         response => {
           this.onItemAddEvent.emit(response.value as Item);
         }
       )
     } else {
       this.itemService.update(item).subscribe(
         reponse => {
           this.onItemEditEvent.emit(reponse.value as Item);
         }
       )
     }
     this.activeModal.close();
  }

  public dismissActiveModal(parm){
    this.activeModal.dismiss(parm);
  }
}

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModuleType } from '../../enums/module-type';
import { MdxGenerationScheme } from '../../enums/mdx-generation-scheme-type';
import { Module } from '../../model/module';
import { ModuleService } from '../../services/module.service';
var ModuleAddEditComponent = (function () {
    function ModuleAddEditComponent(activeModal, moduleService) {
        this.activeModal = activeModal;
        this.moduleService = moduleService;
        this.moduleType = ModuleType;
        this.mdxGenerationSchemeType = MdxGenerationScheme;
        this.type = ModuleType;
        this.mdxGenerationScheme = MdxGenerationScheme;
        this.onAddmoduleEvent = new EventEmitter();
        this.onEditModuleEvent = new EventEmitter();
    }
    // getting all module types from enum and reading from html
    ModuleAddEditComponent.prototype.types = function () {
        var keys = Object.keys(this.moduleType);
        return keys.slice(keys.length / 2);
    };
    ModuleAddEditComponent.prototype.schemeTypes = function () {
        var keys = Object.keys(this.mdxGenerationSchemeType);
        return keys.slice(keys.length / 2);
    };
    ModuleAddEditComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.types();
        this.schemeTypes();
        this.module.mdxGenerationScheme = this.addMode ? this.mdxGenerationScheme.GenerateFull : this.module.mdxGenerationScheme;
        this.btnText = this.addMode ? "Save" : "Update";
        this.modalTitle = this.addMode ? "Add New Module" : "Edit Module " + this.module.name;
        this.moduleService.getBasedOnStandardVersionList().subscribe(function (res) { return _this.versions = res; });
    };
    ModuleAddEditComponent.prototype.saveModel = function (module) {
        var _this = this;
        if (module.id == null) {
            this.moduleService.add(module).subscribe(function (response) {
                _this.onAddmoduleEvent.emit(response.value);
            });
        }
        else {
            this.moduleService.update(module).subscribe(function (response) {
                _this.onEditModuleEvent.emit(response.value);
            });
        }
        this.activeModal.close();
    };
    ModuleAddEditComponent.prototype.dismissActiveModal = function (parm) {
        this.activeModal.dismiss(parm);
    };
    return ModuleAddEditComponent;
}());
__decorate([
    Input(),
    __metadata("design:type", typeof (_a = typeof Module !== "undefined" && Module) === "function" && _a || Object)
], ModuleAddEditComponent.prototype, "module", void 0);
__decorate([
    Output(),
    __metadata("design:type", EventEmitter)
], ModuleAddEditComponent.prototype, "onAddmoduleEvent", void 0);
__decorate([
    Output(),
    __metadata("design:type", EventEmitter)
], ModuleAddEditComponent.prototype, "onEditModuleEvent", void 0);
ModuleAddEditComponent = __decorate([
    Component({
        selector: 'app-module-add-edit',
        templateUrl: './module-add-edit.component.html',
        styleUrls: ['./module-add-edit.component.sass']
    }),
    __metadata("design:paramtypes", [typeof (_b = typeof NgbActiveModal !== "undefined" && NgbActiveModal) === "function" && _b || Object, typeof (_c = typeof ModuleService !== "undefined" && ModuleService) === "function" && _c || Object])
], ModuleAddEditComponent);
export { ModuleAddEditComponent };
var _a, _b, _c;
//# sourceMappingURL=item-add-edit.component.js.map
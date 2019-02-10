var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { DataService } from './../../shared/data.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
var CheckoutComponent = /** @class */ (function () {
    function CheckoutComponent(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
    }
    CheckoutComponent.prototype.ngOnInit = function () {
    };
    CheckoutComponent.prototype.onCheckout = function () {
        var _this = this;
        this.data.checkout().subscribe(function (success) {
            if (success) {
                _this.router.navigate([""]);
            }
        }, function (err) { return _this.errorMessage = "Failed to checout."; });
    };
    CheckoutComponent = __decorate([
        Component({
            selector: 'app-checkout',
            templateUrl: './checkout.component.html',
            styleUrls: ['./checkout.component.css']
        }),
        __metadata("design:paramtypes", [DataService, Router])
    ], CheckoutComponent);
    return CheckoutComponent;
}());
export { CheckoutComponent };
//# sourceMappingURL=checkout.component.js.map
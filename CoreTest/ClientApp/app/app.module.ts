import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { DataService } from './shared/data.service';
import { CartComponent } from './product/cart/cart.component';
import { ShopComponent } from './product/shop/shop.component';
import { CheckoutComponent } from './product/checkout/checkout.component';
import { LoginComponent } from './login/login.component';

let routes = [
{path: "", component: ShopComponent},
{path:"checkout", component:CheckoutComponent},
{path:"login", component:LoginComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    CartComponent,
    ShopComponent,
    CheckoutComponent,
    LoginComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(routes, {
        useHash: true,
        enableTracing: false
      })
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }

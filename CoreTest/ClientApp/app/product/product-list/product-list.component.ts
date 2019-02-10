import { Product } from './../../shared/product';
import { DataService } from './../../shared/data.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];
  constructor(private data: DataService) {

  }

  ngOnInit() {
    this.data.loadProducts()
      .subscribe(success => {
        if (success) {
          this.products = this.data.products;
        }
      })
  }

  addProduct(product: Product) {
    this.data.AddToOrder(product);
  }

}

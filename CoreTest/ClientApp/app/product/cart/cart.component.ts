import { DataService } from './../../shared/data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private data: DataService, private router: Router) { }

  ngOnInit() {
  }

  onCheckout() {
    if(this.data.LoginRequired) {
       this.router.navigate(["login"]);
    }

    else {
      this.router.navigate(["checkout"]);
    }
  }

}

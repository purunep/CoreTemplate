import { DataService } from './../../shared/data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
 errorMessage: string = "";
  constructor(private data: DataService, private router: Router) { }

  ngOnInit() {
  }
  
  onCheckout() {
    this.data.checkout().subscribe(success => {
      if(success) {
        this.router.navigate([""]);
      }
    }, err => this.errorMessage = "Failed to checout.");
  }

}

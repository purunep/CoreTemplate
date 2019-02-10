import { DataService } from './../shared/data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  errorMessage: string = "";
  public creds = {
    username: "",
    password: ""
  };

  constructor(private data: DataService, private router: Router) { }

  ngOnInit() {
  }

  onLogin() {
    this.data.login(this.creds).subscribe(success => {
      if (success) {
        if (this.data.order.items.length == 0) {
          this.router.navigate([""]);
        }
        else {
          this.router.navigate(["checkout"]);
        }
      }
    },
      err =>
        this.errorMessage = "Failed to login");
  }

}

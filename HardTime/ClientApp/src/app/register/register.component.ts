import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterLoginDto } from '../models/register-login-dto.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegisterDto = new RegisterLoginDto();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }
  sendRequestToBackend() {
    this.http.post("https://localhost:44333/" + "account/" + "register",
      this.userRegisterDto).subscribe(response => { },
        error => { });
    this.router.navigate(["/login"]);
      
  };
     

  
}

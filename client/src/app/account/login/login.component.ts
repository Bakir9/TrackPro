import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ParseSourceFile } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  returnUrl: string;
  errorMessage: string;
  showError: boolean;
  loginForm = this.formBuilder.group({
    email: '',
    password: ''
  })

  constructor(
    private accountService: AccountService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute, 
    private formBuilder:FormBuilder) {}

  ngOnInit(): void {
   
  }

  hasError(){

  }

  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl(this.returnUrl);
    }, error => {
      this.showError = true;
      this.errorMessage = "Something wrong ! Try again !"
    })
  }

}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AccountRoutingModule } from './account-routing.module';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import {  FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ ResetPasswordComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
   
  ]
})
export class AccountModule { }

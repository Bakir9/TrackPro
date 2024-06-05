import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { AccountService } from './account/account.service';
import { Router } from '@angular/router';
import { IUser } from './shared/models/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  currentUser$: Observable<IUser>;
  currentToken: string;
  constructor
  ( private accountService: AccountService,private router: Router){}

  ngOnInit(): void {
    this.loadCurrentUser();
  }

  loadCurrentUser(){
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log("User loaded");
    },
  error => {
    console.log("Something wrong");
  })
  }
}

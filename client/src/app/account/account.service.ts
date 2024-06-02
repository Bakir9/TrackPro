import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { ReplaySubject, map } from 'rxjs';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = enviroment.apiUrl;
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient, private router: Router) { }

  login(values: any){
    return this.http.post<IUser>(this.baseUrl + 'account/login', values).pipe(
      map((user: IUser) => {
        console.log("Trenutni korisnik: " +user.appUserId);
        this.currentUserSource.next(user);
      })
    );
  }

  loadCurrentUser(token:string){
    if(token === null) {
      this.currentUserSource.next(null);
      return null;
    }
  }
  
  register(values: any){}
  logout(){
    localStorage.removeItem('token');
  }
  
}

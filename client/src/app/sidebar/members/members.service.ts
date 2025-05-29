import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { IActivity } from 'src/app/shared/models/activity';
import { IMember } from 'src/app/shared/models/member';
import { IPayment } from 'src/app/shared/models/payment';

@Injectable({
  providedIn: 'root'
})

export class MembersService {
  apiUrl = 'https://localhost:5001/api/';
  members: IMember[] = [];
  activity: IActivity[] = [];
  constructor(private http: HttpClient) { }

  getSidebarActivity(){
    return this.http.get<IActivity[]>(this.apiUrl + 'home').pipe(
      map(response => {
        this.activity = response;
        return this.activity;
      })
    )
  }

  getMembers() {
    return this.http.get<IMember[]>(this.apiUrl + 'users').pipe(
      map(response => {
        this.members = response;
        return this.members;
      })
    )
  }

  getMemberDetail(id:number) {
    return this.http.get(this.apiUrl + 'users/' + id);
  }
  
  createMember(values: any) {
    return this.http.post(this.apiUrl +'users/create', values);
  }

  editMember(member:IMember){
    return this.http.put<IMember>(this.apiUrl + 'users/' + member.id, member);
  }
  
  deleteMember(id: number) {
    return this.http.delete(this.apiUrl + 'users/' + id);
  }

  createPayment(payment: IPayment){
    return this.http.post<IPayment>(this.apiUrl + 'payments/create',payment);
  }

  activitiyMembers(id: number) {
    return this.http.get(this.apiUrl + 'activitys/' + id)
  }

  logout(member: IMember){
    return this.http.post(this.apiUrl + 'accounts/logout', member)
  }
}



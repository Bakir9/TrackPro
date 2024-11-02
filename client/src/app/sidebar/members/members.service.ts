import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs';
import { IActivity } from 'src/app/shared/models/activity';
import { IMember } from 'src/app/shared/models/member';

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
    return this.http.put<IMember>(this.apiUrl + 'users/' + member.id, member)
    .pipe(
      
    );
  }
  
  deleteMember(id: number) {
    return this.http.get(this.apiUrl + 'users/' + id);
  }

  createPayment(values: any){
    return this.http.post(this.apiUrl + 'payments/create',values);
  }

  updatePayment(id: number){

  }

  activitiyMembers(id: number) {
    return this.http.get(this.apiUrl + 'activitys/' + id)
  }
}



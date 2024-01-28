import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IMember } from 'src/app/shared/models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  apiUrl = 'https://localhost:5001/api/';
  members: IMember[] = [];
  constructor(private http: HttpClient) { }

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

  editMember(id: number){

  }
  
  deleteMember(id: number) {
    return this.http.get(this.apiUrl + 'users/' + id);
  }

  createPayment(values: any){
    return this.http.post(this.apiUrl + 'payments/create',values);
  }

  deletePayment(id:number) {

  }
  updatePayment(id: number){

  }
}



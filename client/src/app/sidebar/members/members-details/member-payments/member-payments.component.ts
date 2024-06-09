import { Component, Input } from '@angular/core';
import { IMember, IMemberPayments } from 'src/app/shared/models/member';

@Component({
  selector: 'app-member-payments',
  templateUrl: './member-payments.component.html',
  styleUrls: ['./member-payments.component.scss']
})

export class MemberPaymentsComponent {
  currentMemberTest: IMember;
  payments: IMemberPayments[] = [];
  
  setCurrentData(currentMember: IMember){
    this.currentMemberTest = currentMember;
    
    for(let i=0; i < this.currentMemberTest.payments.length; i++){
      this.payments.push(this.currentMemberTest.payments[i]);
      console.log("Godina  " + this.payments[i].year);
    }

    
    
  }
}

import { group } from '@angular/animations';
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
  groupedPayment: any = {};
  isChecked: boolean = true;

  setCurrentData(currentMember: IMember){
    this.currentMemberTest = currentMember;
    
    for(let i=0; i < this.currentMemberTest.payments.length; i++){
      this.payments.push(this.currentMemberTest.payments[i]);
    }
   
    this.groupByYearAndActivity(this.payments,'year','purpose');
    for(let k=0; k<this.groupedPayment.length; k++){
     
    }
    
  }

  groupByYearAndActivity(array: any[], column1: string, column2: string){
    this.groupedPayment = array.reduce((result, currentValue) => {
      const groupKey = `${currentValue[column1]} ${currentValue[column2]}`;
      if(!result[groupKey]){
        result[groupKey] = [];
      }
      //push the current value to the group
      result[groupKey].push(currentValue);

      return result;
    }, {});
  }

  getGroupedKeys(){
    return Object.keys(this.groupedPayment);
  }
}

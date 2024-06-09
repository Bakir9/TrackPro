import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMember, IMemberPayments } from 'src/app/shared/models/member';
import { MembersService } from '../../members.service';
import { FormBuilder } from '@angular/forms';
import { formatDate } from '@angular/common';
import { MemberPaymentsComponent } from '../member-payments/member-payments.component';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})

export class MemberDetailComponent implements AfterViewInit {
  @ViewChild(MemberPaymentsComponent) membersPaymentRef!: MemberPaymentsComponent;
  checked = false;
  user: IMember;
  memberDetail = this.formBuilder.group({
    id:0,
    firstName: '',
    lastName: '',
    adress:'',
    title: '',
    dateOfBirth: '',
    gender: '',
    plz: [{value: '', disabled:true}],
    ort: [{value: '', disabled:true}],
    email: '',
    phone: '',
    country: '',
    nationality: '',
    marriageStatus: ''
  });

  passwordChange = this.formBuilder.group({
    currentPassword: '',
    newPassword: ''
  })



  currentMember:IMember;
  membersPayment: IMemberPayments[];

  constructor(
    private router: Router, 
    private memberService: MembersService, 
    private route: ActivatedRoute,
    private formBuilder: FormBuilder) {}
 
    ngAfterViewInit(): void {
      this.setValueOnForm();
    }



    setValueOnForm() {
      this.memberService.getMemberIdDetail(1).subscribe((user:IMember) => {
        this.currentMember = user;
        this.membersPaymentRef.setCurrentData(this.currentMember);
      
        if(this.currentMember != null ){
          this.memberDetail.patchValue({
            id:0,
            firstName: this.currentMember.firstName,
            lastName: this.currentMember.lastName,
            adress:this.currentMember.adress,
            title: this.currentMember.title,
            dateOfBirth: this.currentMember.birthday,
            gender: this.currentMember.gender,
            plz: '',
            ort: '',
            email: this.currentMember.email,
            phone: this.currentMember.phone,
            country: this.currentMember.country,
            nationality: this.currentMember.nationality,
            marriageStatus: this.currentMember.marriageStatus
          })
        }
      })
    }

  groupPayments(){
  }
}

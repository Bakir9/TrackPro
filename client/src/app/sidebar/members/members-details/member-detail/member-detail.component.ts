import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMember, IMemberPayments } from 'src/app/shared/models/member';
import { MembersService } from '../../members.service';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { MemberPaymentsComponent } from '../member-payments/member-payments.component';
import { IUser } from 'src/app/shared/models/user';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})

export class MemberDetailComponent implements AfterViewInit {
  
  @ViewChild(MemberPaymentsComponent) membersPaymentRef!: MemberPaymentsComponent;
  checked = false;
  currentMember:IMember;
  membersPayment: IMemberPayments[];
  user: IMember;
  currentUser$: Observable<IUser>;

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

  constructor(
    private router: Router, 
    private memberService: MembersService, 
    private route: ActivatedRoute,
    private accountService: AccountService,
    private formBuilder: FormBuilder) {}
 
    ngAfterViewInit(): void {
      this.currentUser$ = this.accountService.currentUser$;
      this.setValueOnForm();
    }



    setValueOnForm() {
      this.memberService.getMemberDetail(parseInt(localStorage.getItem('id'))).subscribe((user:IMember) => {
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

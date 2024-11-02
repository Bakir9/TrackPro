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
  memberUpdate: Partial<IMember> = {};
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
    marriageStatus: '',
    associationId: 0
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
            id:this.currentMember.id,
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
            marriageStatus: this.currentMember.marriageStatus,
            associationId: this.currentMember.associationId
          });
        }
      })
    }

    onClickSubmit(){
      this.memberUpdate.id = this.memberDetail.value.id,
      this.memberUpdate.firstName = this.memberDetail.value.firstName,
      this.memberUpdate.lastName = this.memberDetail.value.lastName,
      this.memberUpdate.adress = this.memberDetail.value.adress,
      this.memberUpdate.title = this.memberDetail.value.title,
      this.memberUpdate.birthday = this.memberDetail.value.dateOfBirth,
      this.memberUpdate.gender = this.memberDetail.value.gender,
      this.memberUpdate.email = this.memberDetail.value.email,
      this.memberUpdate.phone = this.memberDetail.value.phone,
      this.memberUpdate.country = this.memberDetail.value.country,
      this.memberUpdate.nationality = this.memberDetail.value.nationality,
      this.memberUpdate.marriageStatus = this.memberDetail.value.marriageStatus,
      this.memberUpdate.associationId = this.memberDetail.value.associationId
      this.memberService.editMember(this.memberUpdate as IMember).subscribe({
        next: (res: IMember) => {
          alert("User updated !");
        },
        error(res: any) {
          alert("Error on update !")
        }
      });
      
    }
}

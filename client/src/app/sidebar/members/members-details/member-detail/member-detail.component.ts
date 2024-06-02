import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMember } from 'src/app/shared/models/member';
import { MembersService } from '../../members.service';
import { FormBuilder } from '@angular/forms';
import { IUser } from 'src/app/shared/models/user';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})

export class MemberDetailComponent implements OnInit {
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

  actuelUser:IMember;

  constructor(
    private router: Router, 
    private memberService: MembersService, 
    private route: ActivatedRoute,
    private formBuilder: FormBuilder) {}
 
    ngOnInit(): void {
      this.setValueOnForm();
    }

    setValueOnForm() {
      this.memberService.getMemberIdDetail(1).subscribe((user:IMember) => {
        this.actuelUser = user;
        if(this.actuelUser != null ){
          this.memberDetail.patchValue({
            id:0,
            firstName: this.actuelUser.firstName,
            lastName: this.actuelUser.lastName,
            adress:this.actuelUser.adress,
            title: this.actuelUser.title,
            dateOfBirth: this.actuelUser.birthday,
            gender: this.actuelUser.gender,
            plz: '',
            ort: '',
            email: this.actuelUser.email,
            phone: this.actuelUser.phone,
            country: this.actuelUser.country,
            nationality: this.actuelUser.nationality,
            marriageStatus: this.actuelUser.marriageStatus
          })
        }
      })
    }
}

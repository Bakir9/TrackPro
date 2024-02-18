import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMember } from 'src/app/shared/models/member';
import { MembersService } from '../../members.service';
import { FormBuilder } from '@angular/forms';

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
    gender: '',
    plz: '',
    ort: '',
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
    private formBuilder: FormBuilder) {}
 
    ngOnInit(): void {
      
    }
}

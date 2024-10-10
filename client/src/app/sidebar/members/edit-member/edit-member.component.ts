import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MembersService } from '../members.service';
import { FormBuilder } from '@angular/forms';
import { IMember } from 'src/app/shared/models/member';



@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
  styleUrls: ['./edit-member.component.scss']
})

export class EditMemberComponent implements OnInit {
  selected = "emaneh";
  currentMember: IMember;

  editForm = this.formBuilder.group({
    id:0,
    firstName: '',
    lastName: '',
    gender: '',
    dateOfBirth: '',
    adress:'',
    country: '',
    nationality: '',
    memberFrom: '2023-09-21T00:00:00',
    active: 1,
    title: '',
    email: '',
    password: '',
    phone: '',
    marriageStatus: '',
    lastActive: '2023-09-21T00:00:00',
    payments: '',
    associationId: ''
   });

  constructor(
    private memberService: MembersService,
    private dialogRef: MatDialogRef<EditMemberComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder 
    ) {}

    ngOnInit(): void {
      this.memberService.getMemberDetail(parseInt(this.data.id)).subscribe((member:IMember) => {
        this.currentMember =  member;
        if(this.currentMember != null ){
          this.editForm.patchValue({
            id:0,
            firstName: this.currentMember.firstName,
            lastName: this.currentMember.lastName,
            adress:this.currentMember.adress,
            title: this.currentMember.title,
            dateOfBirth: this.currentMember.birthday,
            gender: this.currentMember.gender,
            email: this.currentMember.email,
            phone: this.currentMember.phone,
            country: this.currentMember.country,
            nationality: this.currentMember.nationality,
            marriageStatus: this.currentMember.marriageStatus
          })
        }
      });
    }
}

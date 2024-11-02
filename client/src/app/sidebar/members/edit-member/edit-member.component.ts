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
    associationId: 0
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
            id: this.currentMember.id,
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
            marriageStatus: this.currentMember.marriageStatus,
            associationId: this.currentMember.associationId
          })
        }
      });
    }

    closeDialog(){
      this.dialogRef.close();
    }

    onSubmit(){
     this.currentMember.id = this.editForm.value.id
     this.currentMember.firstName = this.editForm.value.firstName,
     this.currentMember.lastName = this.editForm.value.lastName,
     this.currentMember.adress = this.editForm.value.adress,
     this.currentMember.title = this.editForm.value.title,
     this.currentMember.birthday = this.editForm.value.dateOfBirth,
     this.currentMember.gender = this.editForm.value.gender,
     this.currentMember.email = this.editForm.value.email,
     this.currentMember.phone = this.editForm.value.phone,
     this.currentMember.country = this.editForm.value.country,
     this.currentMember.nationality = this.editForm.value.nationality,
     this.currentMember.marriageStatus = this.editForm.value.marriageStatus,
     this.currentMember.associationId = this.editForm.value.associationId

     this.memberService.editMember(this.currentMember as IMember).subscribe({
      next: (res:IMember) => {
        alert("User updated");
        this.dialogRef.close();
      },
      error(res: any){
        alert("Update failed");
        this.dialogRef.close();
      }
     })
    }
}

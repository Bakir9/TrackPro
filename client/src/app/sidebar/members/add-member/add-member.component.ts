import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MembersService } from '../members.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrls: ['./add-member.component.scss']
})
export class AddMemberComponent implements OnInit {
  selected = "emaneh";

  newMember = this.formBuilder.group({
    id:0,
    firstName: '',
    lastName: '',
    gender: '',
    birthday: '',
    adress:'',
    country: '',
    nationality: '',
    memberFrom: '',
    active: 1,
    title: '',
    email: '',
    password: '',
    phone: '',
    marriageStatus: '',
    lastActive: '',
    payments: '',
    associationId: ''
  });

  constructor(
    private memberService: MembersService, 
    private dialogRef: MatDialogRef<AddMemberComponent>, 
    private formBuilder:FormBuilder
    ){}

  ngOnInit(): void {}
  
  onFormSubmit(){

    if(this.newMember.valid) {
      console.log(this.newMember.value);
      this.memberService.createMember(this.newMember.value).subscribe({
        next: (val: any) => {
          alert("User created");
        },
        error: (err: any) => {
          console.log("User is not created");
        }
      })
    }
  }

  closeDialog():void{
    this.dialogRef.close();
  }
}

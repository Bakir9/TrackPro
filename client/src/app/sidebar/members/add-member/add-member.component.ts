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
    birthday: '2022-11-14',
    adress:'',
    country: '',
    nationality: 'BiH',
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
          console.log("Korisnik nazalost nije dodan");
        }
      })
    }
  }

  closeDialog():void{
    this.dialogRef.close();
  }
}

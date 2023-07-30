import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MembersService } from '../members.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrls: ['./add-member.component.scss']
})
export class AddMemberComponent implements OnInit {
  memberForm: FormGroup
  selected = "emaneh";
  constructor(
    private memberService: MembersService, 
    private dialogRef: MatDialogRef<AddMemberComponent>, 
    ){}

  ngOnInit(): void {}
  
  onFormSubmit(){
    console.log("Pokrenuto");
  }
}

import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MembersService } from '../members.service';
import { FormBuilder } from '@angular/forms';

type NewType = OnInit;

@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
  styleUrls: ['./edit-member.component.scss']
})
export class EditMemberComponent implements NewType {
  selected = "emaneh";

  editForm = this.formBuilder.group({
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
    private dialogRef: MatDialogRef<EditMemberComponent>,
    private formBuilder: FormBuilder 
    ) {}

    ngOnInit(): void {}
}

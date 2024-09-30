import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MembersService } from '../members.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.scss']
})
export class AssignmentComponent {
  selected = "emaneh";

  assignment = this.formBuilder.group({
    id:0,
    title: '',
    assignmentDescription: '',
   });

   constructor(
    private memberService: MembersService,
    private dialogRef: MatDialog,
    private formBuilder: FormBuilder 
    ) {}

}

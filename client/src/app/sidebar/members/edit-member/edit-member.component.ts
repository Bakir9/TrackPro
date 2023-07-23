import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MembersService } from '../members.service';

@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
  styleUrls: ['./edit-member.component.scss']
})
export class EditMemberComponent {
  constructor(
    private memberService: MembersService,
    private dialogRef: MatDialogRef<EditMemberComponent>, 
    )
    {}
}

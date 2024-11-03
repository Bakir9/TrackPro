import { Component, Inject } from '@angular/core';
import { MembersService } from '../members.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-deletedialog',
  templateUrl: './deletedialog.component.html',
  styleUrls: ['./deletedialog.component.scss']
})
export class DeletedialogComponent {

  constructor(
    private memberService: MembersService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<DeletedialogComponent>
  ){}

  closeDialog(){
    this.dialogRef.close();
  }

  deleteMember(){
    this.memberService.deleteMember(this.data.userId).subscribe({
      next: (res: any) => {
        alert("Delete successfuly");
        this.closeDialog();
      },
      error:(err: any) => {
        alert("Delete failed");
        this.closeDialog();
      }
    });
  }
}

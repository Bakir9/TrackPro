import { Component, OnInit } from '@angular/core';
import { AddMemberComponent } from '../../members/add-member/add-member.component';
import { MembersService } from '../../members/members.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss']
})
export class ActivityComponent implements OnInit{

  constructor (private memberService: MembersService,  private dialog: MatDialog){}
  
  ngOnInit(): void {
    
  }

  openDialog() {
    const dialogRef = this.dialog.open(AddMemberComponent);

    dialogRef.afterClosed().subscribe(result => {
       
    });
  }
}

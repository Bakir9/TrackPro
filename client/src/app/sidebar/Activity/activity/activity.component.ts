import { Component, OnInit } from '@angular/core';
import { AddMemberComponent } from '../../members/add-member/add-member.component';
import { MembersService } from '../../members/members.service';
import { MatDialog } from '@angular/material/dialog';
import { IActivity, IActivityMembers } from 'src/app/shared/models/activity';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss']
})
export class ActivityComponent implements OnInit{
  activity: IActivity;
  actMembers: IActivityMembers[];
  constructor (private memberService: MembersService,  private dialog: MatDialog, private route: ActivatedRoute){}
  
  ngOnInit(): void {
    const id =this.route.snapshot.paramMap.get('id');
    this.getActivityInfo(+this.route.snapshot.paramMap.get('id'));
    

  }

  openDialog() {
    const dialogRef = this.dialog.open(AddMemberComponent);
    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

  getActivityInfo(id: number){
    this.memberService.activitiyMembers(id).subscribe((activity: IActivity) => {
      this.activity = activity;
      // for(let i=0; i < this.activity.members.length; i++){
      //   this.actMembers.push(this.activity.members[i]);
      // }
      console.log(activity);
    }, error => {
      console.log(error);
    });
  }
}

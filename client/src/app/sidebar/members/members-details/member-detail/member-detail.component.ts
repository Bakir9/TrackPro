import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMember } from 'src/app/shared/models/member';
import { MembersService } from '../../members.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})

export class MemberDetailComponent implements OnInit {
  checked = false;
  user: IMember;
  constructor(private router: Router, private memberService: MembersService, private route: ActivatedRoute) {}
 
  ngOnInit(): void {
    
  }
  // ngOnInit(): void {
  //     this.memberService.getMemberDetail(2)
  //       .subscribe((user: IMember) => {
  //         this.user = user;
  //         console.log(this.user);
  //   },
  //   error => {
  //     console.log(error);
  //   });
  // }
   
}

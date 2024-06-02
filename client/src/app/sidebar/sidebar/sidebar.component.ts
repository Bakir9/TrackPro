import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatDialog } from '@angular/material/dialog';
import { AddMemberComponent } from '../members/add-member/add-member.component';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTreeModule } from '@angular/material/tree';
import { IActivity, IActivityChildren } from 'src/app/shared/models/activity';
import { MembersService } from '../members/members.service';
import { AccountService } from 'src/app/account/account.service';
import { Observable, subscribeOn } from 'rxjs';
import { IUser } from 'src/app/shared/models/user';
import { Router } from '@angular/router';
import { IMember } from 'src/app/shared/models/member';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})


export class SidebarComponent implements OnInit {
  @ViewChild(MatSidenav) sidenav!:MatSidenav;
  menuitems = ['dashboard','sales', 'orders', 'customers', 'products'];
  loading = true;
  activity: IActivity[];
  treeControl = new NestedTreeControl<IActivity>(node => node.children);
  dataSource = new MatTreeNestedDataSource<IActivity>();
  currentUser$: Observable<IUser>;
  currentToken: string;
  actuelUser:IMember;

  constructor(
    private observer: BreakpointObserver, 
    private dialog: MatDialog, 
    private memberService: MembersService,
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.currentToken = localStorage.getItem('token')
    console.log("Token: " + this.currentToken);
    if(this.currentToken === null){
      this.router.navigate(['/login']); 
    }
    this.getUserById(1);
    this.getSidebarActivity();
  }

  hasChild = (_:number, node: IActivity) => !!node.children && node.children.length > 0;
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if(res.matches){
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(AddMemberComponent);
    dialogRef.afterClosed().subscribe(result => {
        console.log("Test");
    });
  }

  getSidebarActivity() {
    this.memberService.getSidebarActivity().subscribe((activity: IActivity[]) => {
      this.activity = activity;
      this.dataSource.data = this.activity;
      console.log(this.treeControl);
    }, error => {
      console.log(error);
    })
  }

  getUserById(id: number){
    this.memberService.getMemberIdDetail(1).subscribe((user: IMember) => {
      this.actuelUser = user;
    })
  }
}
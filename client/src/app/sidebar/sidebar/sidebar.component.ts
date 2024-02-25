import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatDialog } from '@angular/material/dialog';
import { AddMemberComponent } from '../members/add-member/add-member.component';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTreeModule } from '@angular/material/tree';
import { IActivity, IActivityChildren } from 'src/app/shared/models/activity';
import { MembersService } from '../members/members.service';

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

  constructor(private observer: BreakpointObserver, private dialog: MatDialog, private memberService: MembersService) 
  {
    
  }

  ngOnInit(): void {
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
}
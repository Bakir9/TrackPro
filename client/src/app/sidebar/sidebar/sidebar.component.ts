import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatDialog } from '@angular/material/dialog';
import { AddMemberComponent } from '../members/add-member/add-member.component';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTreeModule } from '@angular/material/tree';

const TREE_DATA_Activity: ActivityNode[] = 
[
  {
    id: 1,
    name: 'Aktivnost 1',
    children: [{id: 1, name: 'Grupa 1'}, {id: 2, name: 'Grupa 2'}, {id: 3, name: 'Grupa 3'}],
  },
  {
    id: 2,
    name: 'Aktivnost 2',
    children: [{id: 1, name: 'Napredni'}, {id: 2, name: 'Grupa 2'}, {id: 3, name: 'Napredni 3'}],
  },
  {
    id: 3,
    name: 'Aktivnost 3',
    children: [{id: 1, name: 'Napredni 2'}, {id: 2, name: 'Grupa 1'}, {id: 3, name: 'Grupa 2'}],
  }
];

interface ActivityNode {
  id: number;
  name: string;
  children?: ActivityNode[];
}

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})


export class SidebarComponent {
  @ViewChild(MatSidenav) sidenav!:MatSidenav;
  menuitems = ['dashboard','sales', 'orders', 'customers', 'products'];
  loading = true;
  treeControl = new NestedTreeControl<ActivityNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<ActivityNode>();

  constructor(private observer: BreakpointObserver, private dialog: MatDialog) 
  {
     
  }

  hasChild = (_:number, node: ActivityNode) => !!node.children && node.children.length > 0;
  ngAfterViewInit() {
    this.dataSource.data = TREE_DATA_Activity;
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
}
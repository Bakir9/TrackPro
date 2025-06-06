import { Component, OnInit, ViewChild } from '@angular/core';
import { MembersService } from '../members.service';
import {TooltipPosition, MatTooltipModule} from '@angular/material/tooltip';
import { IMember } from 'src/app/shared/models/member';
import { MatTableDataSource,  } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {  MatDialog } from '@angular/material/dialog';
import { EditMemberComponent } from '../edit-member/edit-member.component';
import { MemberPaymetComponent } from '../../payments/dialog/member-paymet/member-paymet.component';
import { DeletedialogComponent } from '../deletedialog/deletedialog.component';
import { AddMemberComponent } from '../add-member/add-member.component';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})

export class MembersComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator | null = null;
  dataSource: MatTableDataSource<IMember>;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'country', 'phone', 'nationality', 'action'];
  members: IMember[];
  currentMember: IMember;

  constructor (
    private memberService: MembersService,  
    private dialog: MatDialog
  ){}

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngOnInit() {
    this.getMembers();
  }

  openDialog(id:string) {
    const dialogRef = this.dialog.open(EditMemberComponent, {
      data: {id: id }
    });
    this.memberService.getMemberDetail(parseInt(id)).subscribe((member:IMember) => {
      this.currentMember =  member;
    });
    dialogRef.afterClosed().subscribe(result => {
   
    });
  }

  openDialogAddMember() {
    const dialogRef = this.dialog.open(AddMemberComponent);
    dialogRef.afterClosed().subscribe(result => {
    });
  }

  openPayment(userId:number) {
    const dialogRef = this.dialog.open(MemberPaymetComponent, {
      data:{userId: userId}
    });
  }

  openDeleteDialog(userId:number) {
    const dialogRef = this.dialog.open(DeletedialogComponent, {
      data: {userId: userId}
    });
    
    dialogRef.afterClosed().subscribe((result: any )=> { 
        console.log("ovo je result " + result); 
    });
  }

  getMembers() {
    this.memberService.getMembers().subscribe((members: IMember[]) => {
      this.dataSource = new MatTableDataSource(members);
      this.dataSource.paginator = this.paginator;
    }, error => {
      console.log(error)
    })
  }
}

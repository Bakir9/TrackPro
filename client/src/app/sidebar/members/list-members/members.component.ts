import { Component, OnInit, ViewChild } from '@angular/core';
import { MembersService } from '../members.service';
import { IMember } from 'src/app/shared/models/member';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { EditMemberComponent } from '../edit-member/edit-member.component';
import { MemberPaymetComponent } from '../../payments/dialog/member-paymet/member-paymet.component';
import { DeletedialogComponent } from '../deletedialog/deletedialog.component';
import { AddMemberComponent } from '../add-member/add-member.component';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss'],
  // standalone: true,
  // imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatPaginatorModule, MatIconModule, MatButtonModule],
})

export class MembersComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator | null = null;
  dataSource: MatTableDataSource<IMember>;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'country', 'phone', 'nationality', 'action'];
  members: IMember[];

  constructor (private memberService: MembersService,  private dialog: MatDialog){}

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

  openDialog() {
    const dialogRef = this.dialog.open(EditMemberComponent);

    dialogRef.afterClosed().subscribe(result => {
       
    });
  }

  openDialogAddMember() {
    const dialogRef = this.dialog.open(AddMemberComponent);
    dialogRef.afterClosed().subscribe(result => {

    });
  }

  openPayment() {
    const dialogRef = this.dialog.open(MemberPaymetComponent);
  }

  openDeleteDialog() {
    const dialogRef = this.dialog.open(DeletedialogComponent);
    
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

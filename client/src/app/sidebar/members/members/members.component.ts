import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MembersService } from '../members.service';
import { IMember } from 'src/app/shared/models/member';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';

/** Constants used to fill up our data base. */
const COUNTRY: string[] = [
  'bosnia-herzegowina',
  'österreich',
  'slovenien',
  'croatia',
  'deutschland',
  'france',
  'england',
];
const NAMES: string[] = [
  'Maia',
  'Asher',
  'Olivia',
  'Atticus',
  'Amelia',
  'Jack',
  'Charlotte',
  'Theodore',
  'Isla',
  'Oliver',
  'Isabella',
  'Jasper',
  'Cora',
  'Levi',
  'Violet',
  'Arthur',
  'Mia',
  'Thomas',
  'Elizabeth',
];

const LASTNAMES: string[] = [
  'Mujic',
  'Hasic',
  'Malkoc',
  'Müller',
  'Hodzic',
  'Smajic',
  'Charlotte',
  'Theodore',
  'King'
];

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatPaginatorModule],
})

export class MembersComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator | null = null;
  dataSource: MatTableDataSource<IMember>;
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'country', 'phone', 'nationality', 'action'];
  members: IMember[];

  constructor (private memberService: MembersService){
    // Create 100 member
    const member = Array.from({length: 100}, (_, k) => createNewUser(k + 1));

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(member);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getMembers();
  }

  getMembers() {
    this.memberService.getMembers().subscribe((members: IMember[]) => {
      this.members = members;
      console.log("Members:");
      console.log(this.members);
    }, error => {
      console.log(error)
    })
  }
}

/** Builds and returns a new User. */
function createNewUser(id: number): IMember {
  const name =
    NAMES[Math.round(Math.random() * (NAMES.length - 1))];
  const lastname = LASTNAMES[Math.round(Math.random() * (LASTNAMES.length - 1))];
  return {
    id: id,
    firstName: name,
    lastName: lastname,
    title: "Ing",
    gender: "Male",
    birthday: "1995-01-18",
    adress:" Grillweg",
    email: "test@gmail.com",
    password:"123",
    phone: "06645162656",
    country: COUNTRY[Math.round(Math.random() * (COUNTRY.length - 1))],
    nationality: COUNTRY[Math.round(Math.random() * (COUNTRY.length - 1))],
    marriageStatus: "No",
    memberFrom: "2023-03-14T00:00:00",
    active: 1,
    lastActive: "2023-03-14T00:00:00",
    userPayments: "null"
  };
}

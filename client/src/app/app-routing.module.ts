import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './sidebar/home/header/header.component';
import { MembersComponent } from './sidebar/members/list-members/members.component';
import { MemberDetailComponent } from './sidebar/members/members-details/member-detail/member-detail.component';

const routes: Routes = 
[
  {path: "dashboard", component: HeaderComponent},
  {path: "members", component: MembersComponent},
  {path: "member-details", component: MemberDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

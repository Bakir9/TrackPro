import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './sidebar/home/header/header.component';
import { MembersComponent } from './sidebar/members/list-members/members.component';
import { MemberDetailComponent } from './sidebar/members/members-details/member-detail/member-detail.component';

const routes: Routes = 
[
  {path: "home", component: HeaderComponent},
  {path: "users", component: MembersComponent},
  {path: "user-details", component: MemberDetailComponent},
  {path: '', redirectTo: '/home', pathMatch:'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

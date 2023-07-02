import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './sidebar/home/header/header.component';
import { MembersComponent } from './sidebar/members/members/members.component';

const routes: Routes = 
[
  {path: "dashboard", component: HeaderComponent},
  {path: "members", component: MembersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

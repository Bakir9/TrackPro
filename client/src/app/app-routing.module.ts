import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './sidebar/home/header/header.component';
import { MembersComponent } from './sidebar/members/list-members/members.component';
import { MemberDetailComponent } from './sidebar/members/members-details/member-detail/member-detail.component';
import { ActivityComponent } from './sidebar/Activity/activity/activity.component';
import { PaymentComponent } from './sidebar/payments/payment/payment.component';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { LoginComponent } from './account/login/login.component';

const routes: Routes = 
[
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {path: "home", component: HeaderComponent},
      {path: "users", component: MembersComponent},
      {path: "user-details/:id", component: MemberDetailComponent},
      {path: "payments", component: PaymentComponent},
      {path: "other-payments", component: ActivityComponent},
      {path: "activity/:id", component: ActivityComponent},
      {path: '', redirectTo: '/home', pathMatch:'full'}
    ]
  },
  {
    path: 'login',
    component: LoginLayoutComponent,
    children: [
      {path: "login", component: LoginComponent}
    ]
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

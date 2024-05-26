import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule} from '@angular/material/dialog';
import { AddMemberComponent } from './members/add-member/add-member.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatNativeDateModule} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { EditMemberComponent } from './members/edit-member/edit-member.component';
import { MemberDetailComponent } from './members/members-details/member-detail/member-detail.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatListModule} from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatMenuModule} from '@angular/material/menu';
import { MemberPaymetComponent } from './payments/dialog/member-paymet/member-paymet.component';
import {MatTreeNestedDataSource, MatTreeModule} from '@angular/material/tree';
import { ReactiveFormsModule } from '@angular/forms';
import { ActivityComponent } from './Activity/activity/activity.component';
import { PaymentComponent } from './payments/payment/payment.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    AddMemberComponent,
    EditMemberComponent,
    MemberDetailComponent,
    MemberPaymetComponent,
    ActivityComponent,
    PaymentComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatRadioModule,
    MatNativeDateModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatTabsModule,
    MatListModule,
    MatExpansionModule,
    MatCheckboxModule,
    MatMenuModule,
    MatTreeModule,
    ReactiveFormsModule,
    MatCardModule
  ],
  exports: [AddMemberComponent, MatMenuModule]
})
export class SidebarModule { }

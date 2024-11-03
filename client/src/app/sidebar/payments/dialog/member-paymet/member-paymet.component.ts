import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MembersService } from 'src/app/sidebar/members/members.service';
import { IPayment } from 'src/app/shared/models/payment';

@Component({
  selector: 'app-member-paymet',
  templateUrl: './member-paymet.component.html',
  styleUrls: ['./member-paymet.component.scss']
})

export class MemberPaymetComponent implements OnInit {
  selected = 'uplatnica';
  payment: Partial<IPayment>={}
  

  newPayment = this.formBuilder.group({
   id:0,
   userId: '',
   amount: 0,
   paymentMethod: '',
   month: '',
   year: '2024', 
   purpose: '',
   paymentDate: ''
  });

  constructor(
    private memberService: MembersService,
    private dialogRef: MatDialogRef<MemberPaymetComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data:any
  ){}

  ngOnInit(): void {}

  onPaymentSubmit() {
    this.payment.userId = this.data.userId
    this.payment.amount = this.newPayment.value.amount
    this.payment.paymentMethod = this.newPayment.value.paymentMethod
    this.payment.month = this.newPayment.value.month
    this.payment.purpose = this.newPayment.value.purpose
    this.payment.paymentDate = new Date()
    this.payment.year = new Date().getFullYear().toString()

    this.memberService.createPayment(this.payment as IPayment).subscribe({
    next: (val: any) => {
      alert("Payment created");
      this.closeDialog();
    },
    error: (err: any) => {
      console.log("Uplata nije izvrsena");
    }
  });
    
  }

  closeDialog(){
    this.dialogRef.close();
  }
}

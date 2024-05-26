import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MembersService } from 'src/app/sidebar/members/members.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-member-paymet',
  templateUrl: './member-paymet.component.html',
  styleUrls: ['./member-paymet.component.scss']
})

export class MemberPaymetComponent implements OnInit {
  selected = 'uplatnica';
  
  newPayment = this.formBuilder.group({
   id:0,
   userId: '2',
   amount: '',
   paymentMethod: '',
   month: '',
   year:'2023-09-21T00:00:00',
   purpose: 'Clanarina',
   //semestar: '',
   //annotations:'' 
   paymentDate: '2023-09-21T00:00:00'
  });

  constructor(
    private datePipe: DatePipe,
    private memberService: MembersService,
    private dialogRef: MatDialogRef<MemberPaymetComponent>,
    private formBuilder: FormBuilder
  ){}

  ngOnInit(): void {}

  onPaymentSubmit() {
    console.log("Unutar metode");
    if(this.newPayment.valid){
       this.memberService.createPayment(this.newPayment.value).subscribe({
        next: (val: any) => {
          alert("Payment created");
          this.closeDialog();
        },
        error: (err: any) => {
          console.log("Uplata nije izvrsena");
        }
      });
    }
  }

  closeDialog(){
    this.dialogRef.close();
  }
}

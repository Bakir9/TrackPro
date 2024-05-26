import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit{
  
  ngOnInit(): void {
    
  }

  checkForPayment(id:number) {
    console.log("Check for payments")
  }

}

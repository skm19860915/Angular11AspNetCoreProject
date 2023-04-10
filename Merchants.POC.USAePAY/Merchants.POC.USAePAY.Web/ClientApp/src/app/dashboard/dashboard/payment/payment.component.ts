import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../../core/services/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(public service: PaymentService) { }

  ngOnInit() {
    this.service.getCreateCreditCardResponse();
  }

}

import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../core/services/customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(public service: CustomersService) { }

  ngOnInit() {
    this.service.retrieveCustomerList();
  }

}

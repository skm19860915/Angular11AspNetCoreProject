import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.prod';
import { RetrieveCustomerList } from '../models/customers/retrieve-customer-list.interface';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  private readonly url = environment.apiURL + "customers";
  list: RetrieveCustomerList[];

  constructor(private http: HttpClient) {
  }

  retrieveCustomerList() {
    this.http.get(this.url).toPromise().then(response => {
      this.list = response[0] as RetrieveCustomerList[];
      console.log(this.list);
    });
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.prod';
import { CreateCreditCardResponse } from '../models/create-credit-card-response.interface';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private readonly url = environment.apiURL + "payment";
  creditCardData: CreateCreditCardResponse;

  constructor(private http: HttpClient) {
  }

  getCreateCreditCardResponse() {
    this.http.get(this.url).toPromise().then(response => {
      this.creditCardData = response[0] as CreateCreditCardResponse;
      console.log(this.creditCardData);
    });
  }
}

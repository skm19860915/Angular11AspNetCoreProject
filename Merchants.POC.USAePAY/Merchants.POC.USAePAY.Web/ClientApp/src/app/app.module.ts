import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PaymentComponent } from './dashboard/dashboard/payment/payment.component';
import { CreditCardFormComponent } from './dashboard/dashboard/payment/credit-card-form/credit-card-form.component';
import { CustomersComponent } from './dashboard/dashboard/customers/customers.component';
import { CreateCustomerComponent } from './dashboard/dashboard/customers/create-customer/create-customer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PaymentComponent,
    CreditCardFormComponent,
    CustomersComponent,
    CreateCustomerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'dashboard/payment', component: PaymentComponent },
      { path: 'dashboard/payment/create', component: CreditCardFormComponent },
      { path: 'dashboard/customers', component: CustomersComponent },
      { path: 'dashboard/customers/create', component: CreateCustomerComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

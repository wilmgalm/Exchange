import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'quote.component',
  templateUrl: './quote.component.html'
})
export class QuoteComponent {
  public currencies: Array<Currency> ;

  constructor(http: HttpClient, @Inject('BASE_API') baseUrl: string) {
    this.currencies = new Array<Currency>();

    http.post<Currency>(baseUrl + 'GetExchangeRate', { "Currency": "USD" }).subscribe(result => {
      this.currencies.push(result);
    }, error => console.error(error));


    http.post<Currency>(baseUrl + 'GetExchangeRate', { "Currency": "BRL" }).subscribe(result => {
      this.currencies.push(result);
    }, error => console.error(error));
  }
}

interface Currency {
  Sold: number;
  Bought: number;
  Description: string;
  Currency_Code: string;
}

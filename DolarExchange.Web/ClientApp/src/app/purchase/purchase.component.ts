import { Component } from '@angular/core';

@Component({
  selector: 'app-purchase-component',
  templateUrl: './purchase.component.html'
})
export class PurchaseComponent {
  public currentCount = "";

  public sorryFunction() {
    this.currentCount="Sorry isn't finished";
  }
}

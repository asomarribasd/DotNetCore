import { Component } from '@angular/core';
import {FormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
    isSubmitted = false;
    infoProviders = [];
    form: FormGroup;

 constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      infoProviders: ['']
    });

    // async orders
    of(this.getInfoProviders()).subscribe(orders => {
      this.infoProviders = orders;
      this.form.controls.orders.patchValue(this.infoProviders[0].value);
    });

    // synchronous orders
    // this.orders = this.getOrders();
    // this.form.controls.orders.patchValue(this.orders[0].id);
  }

 // submitForm(form: NgForm) {
 //   this.isSubmitted = true;
 //   if(!form.valid) {
 //     return false;
 //   } else {
 //   alert(JSON.stringify(form.value))
 //   }
 // }

  getInfoProviders() {
    return [
      { id: '1', name: 'Sample 1' },
      { id: '2', name: 'Sample 2' },
      { id: '3', name: 'Sample 3' },
      { id: '4', name: 'Sample 4' }
    ];
  }

  /*########### Template Driven Form ###########*/
  templateForm(value: any) {
    alert(JSON.stringify(value));
  }
}

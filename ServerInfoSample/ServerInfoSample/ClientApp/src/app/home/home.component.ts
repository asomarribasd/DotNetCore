import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
    isSubmitted = false;
      constructor() {}

 // submitForm(form: NgForm) {
 //   this.isSubmitted = true;
 //   if(!form.valid) {
 //     return false;
 //   } else {
 //   alert(JSON.stringify(form.value))
 //   }
 // }

  /*########### Template Driven Form ###########*/
  templateForm(value: any) {
    alert(JSON.stringify(value));
  }
}

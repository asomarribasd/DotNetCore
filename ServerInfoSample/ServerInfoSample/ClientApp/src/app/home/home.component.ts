import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { ServerInformationService } from '../services/ServerInformationService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit{
    isSubmitted = false;
    form: FormGroup;
    providersData = [];
    

  constructor(private formBuilder: FormBuilder, private informationService: ServerInformationService) {
    this.form = this.formBuilder.group({
        providers: new FormArray([]),
        server: new FormControl()
    });

    this.providersData = this.informationService.getInformationProviders();
    
  }

  ngOnInit() {
    //this.providersData = this.informationService.getInformationProviders();
      console.log (this.providersData);
      this.addCheckboxes();
  }

  private addCheckboxes() {
    this.providersData.forEach((o, i) => {
      const control = new FormControl(i === 0); // if first item set to true, else false
      (this.form.controls.providers as FormArray).push(control);
    });
  }

  submit(jsonForm) {
    const selectedProvidersIds = this.form.value.orders
      .map((v, i) => v ? this.providersData[i].value : null)
      .filter(v => v !== null);
    console.log(selectedProvidersIds);
  }

  getInfoProviders() {
    return [
      { id: '1', name: 'Sample 1' },
      { id: '2', name: 'Sample 2' },
      { id: '3', name: 'Sample 3' },
      { id: '4', name: 'Sample 4' }
    ];
  }

}

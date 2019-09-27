import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})


export class ServerInformationService {
  providers = [];
 baseUrl = "";
  //constructor(
  //  private http: HttpClient
  //) {}

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
    http.get<ServerInformationProvider[]>(baseUrl + 'serverinformation').subscribe(result => {
      this.providers = result;
        console.log (result);
    }, error => console.error(error));
  }

  getProviderInformation(providerId) {
    this.http.get<ServerInformationProvider[]>(this.baseUrl + 'infoserverprovider').subscribe(result => {
      this.providers = result;
    }, error => console.error(error));
      return this.providers;
  }

  getInformationProviders() {
    return this.providers;
  }

}

interface ServerInformationProvider {
  value: string;
  name: string;
}
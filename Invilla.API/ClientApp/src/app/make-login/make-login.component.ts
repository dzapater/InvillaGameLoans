import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Roles } from '../input-roles/input-roles.component';

@Component({
  selector: 'app-make-login',
  templateUrl: './make-login.component.html'
})

export class MakeLoginComponent implements OnInit {
  public logins: Logins[];
  public roles: Roles[];
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

    this.loadRoles();
    this.loadUsers();
    
  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Id: null,
      IdRole: null,
      RegistrationDate: null,
      FullName: null,
      Password: null
    });



  }

  public loginAction() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNTM4NzcwLCJleHAiOjE2MTI1NDIzNzB9.KlqVEHloiFbGMFxAM55imODYT33ExflJW8GI6t2-CV4`);    
    console.log("JJ: " + JSONForm);
    this.http.post(this.baseUrl + 'logins/post', JSONForm, { headers: header, responseType: 'text',}  ).subscribe(data => {      
      console.log(data);
    })
  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);
    console.log("JJ: " + JSONForm);
    this.http.post(this.baseUrl + 'users/post', JSONForm, { headers: header, responseType: 'text', }).subscribe(data => {
      console.log(data);
    })
  }

  public loadUsers() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiI4Pz96P2hcdTAwMWY_Ols_Rz8_MVx1MDAwND9qP1k_P0ZDP31OTj8_Pz8iLCJSb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTI3MjU4NDMsImV4cCI6MTYxMjcyOTQ0M30.dC8ZagtUjyGv94GLL7IozB9qR6zvEdOQCAvXaoprdrs
`);

    this.http.get<Logins[]>(this.baseUrl + 'users/get', { headers: header }).subscribe(result => {
      this.logins = result;
    }, error => console.error(error));
  }

  public updateLogin(id: string) {
    let JSONForm = JSON.stringify(this.formulario.value);
    console.log("JSON: " + JSONForm);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiI4Pz96P2hcdTAwMWY_Ols_Rz8_MVx1MDAwND9qP1k_P0ZDP31OTj8_Pz8iLCJSb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTI3MjU4NDMsImV4cCI6MTYxMjcyOTQ0M30.dC8ZagtUjyGv94GLL7IozB9qR6zvEdOQCAvXaoprdrs`);

    this.http.put(this.baseUrl + 'users/update/' + id, JSONForm, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  public deleteLogin(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiI4Pz96P2hcdTAwMWY_Ols_Rz8_MVx1MDAwND9qP1k_P0ZDP31OTj8_Pz8iLCJSb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTI3MjU4NDMsImV4cCI6MTYxMjcyOTQ0M30.dC8ZagtUjyGv94GLL7IozB9qR6zvEdOQCAvXaoprdrs`);

    this.http.delete(this.baseUrl + 'users/delete/' + id, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  public loadRoles() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.get<Roles[]>(this.baseUrl + 'roles/get', { headers: header }).subscribe(result => {
      this.roles = result;
      console.log("Ci de: " + this.roles);
    }, error => console.error(error));
  }


}

export interface Logins {
  Id: number,
  RegistrationDate: string,
  IdRole : number,
  FullName: string,
  Password: string  
}

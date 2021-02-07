import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-input-roles',
  templateUrl: './input-roles.component.html'
})

export class InputRolesComponent implements OnInit {
  public roles: Roles[];
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

    this.loadRoles();

  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Id: null,
      RegistrationDate: null,
      Role: null      
    });

  }

  public login() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);    
    console.log("ffsdfs: " + JSONForm);
    this.http.post(this.baseUrl + 'roles/post', JSONForm, { headers: header, responseType: 'text' }, ).subscribe(data => {      
      console.log(data);
    })
  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);
    console.log("ffsdfs: " + JSONForm);
    this.http.post(this.baseUrl + 'roles/post', JSONForm, { headers: header, responseType: 'text' },).subscribe(data => {
      console.log(data);
    })
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

  public updateRole(id: string) {
    let JSONForm = JSON.stringify(this.formulario.value);
    console.log("JSON: " + JSONForm);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.put(this.baseUrl + 'roles/update/' + id, JSONForm, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  public deleteRole(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.delete(this.baseUrl + 'roles/delete/' + id, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

}

export interface Roles {
  Id: number,
  RegistrationDate: string,
  Role: string,
}

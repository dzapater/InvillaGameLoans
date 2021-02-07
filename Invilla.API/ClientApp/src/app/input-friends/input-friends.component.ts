import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-input-friends',
  templateUrl: './input-friends.component.html'
})

export class InputFriendsComponent implements OnInit {
  public friends: Friends[];
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

    this.loadFriends();

  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Id: null,
      RegistrationDate: null,
      FullName: null,
      Age: null
    });

  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);    
    console.log("ffsdfs: " + JSONForm);
    this.http.post(this.baseUrl + 'friends/post', JSONForm, { headers: header, responseType: 'text' }, ).subscribe(data => {      
      console.log(data);
    })
  }

  public loadFriends() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.get<Friends[]>(this.baseUrl + 'friends/get', { headers: header }).subscribe(result => {
      this.friends = result;
      console.log("Ci de: " + this.friends);
    }, error => console.error(error));
  }

  public updateFriend(id: string) {
    let JSONForm = JSON.stringify(this.formulario.value);
    console.log("JSON: " + JSONForm);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.put(this.baseUrl + 'friends/update/' + id, JSONForm, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  public deleteFriend(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.delete(this.baseUrl + 'friends/delete/' + id, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

}

export interface Friends {
  Id: number,
  RegistrationDate: string,
  FullName: string,
  Age: number
}

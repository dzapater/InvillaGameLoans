import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-input-games',
  templateUrl: './input-games.component.html'
})

export class InputGamesComponent implements OnInit {
  public games: Games[];
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

    this.loadGames();

  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Id: null,
      RegistrationDate: null,
      FullGameName: null      
    });

  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);
    
    this.http.post(this.baseUrl + 'games/post', JSONForm, { headers: header, responseType: 'text' }).subscribe(data => {      
      console.log(data);
    })
  }

  public loadGames() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.get<Games[]>(this.baseUrl + 'games/get', { headers: header }).subscribe(result => {
      this.games = result;
      console.log("Games:" + this.games);
      console.log(result);
    }, error => console.error(error));
  }

  public updateGame(id: string) {
    let JSONForm = JSON.stringify(this.formulario.value);
    console.log("JSON: " + JSONForm);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.put(this.baseUrl + 'games/update/' + id, JSONForm, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  public deleteGame(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.delete(this.baseUrl + 'games/delete/' + id, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

}

export interface Games {
  Id: number,
  RegistrationDate: string,
  FullGameName: string  
}

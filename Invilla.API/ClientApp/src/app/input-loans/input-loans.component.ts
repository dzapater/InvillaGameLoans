import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Friends } from '../input-friends/input-friends.component';
import { Games } from '../input-games/input-games.component';

@Component({
  selector: 'app-input-loans',
  templateUrl: './input-loans.component.html'
})

export class InputLoansComponent implements OnInit {
  public loans: Loans[];
  public friends: Friends[];
  public games: Games[];
  formulario: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {

    this.loadLoans();

  }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Id : null,
      LoanDateBegin: null,
      LoanDateEnd: null,
      IdGame: null,
      IdFriend: null      
    });

    this.loadFriend();
    this.loadGame();

  }

  public saveData() {
    let JSONForm = JSON.stringify(this.formulario.value);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);  
    
    console.log(JSONForm);
    this.http.post(this.baseUrl + 'loans/post', JSONForm, { headers: header, responseType: 'text', observe: 'response' }).subscribe((res) => {
      console.log(res.status);
    });
  }

  public loadFriend() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.get<Friends[]>(this.baseUrl + 'friends/get', { headers: header }).subscribe(result => {
      this.friends = result;
      console.log("Friends:" + this.friends);
      console.log(result);
    }, error => console.error(error));
  }

  public loadGame() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.get<Games[]>(this.baseUrl + 'games/get', { headers: header }).subscribe(result => {
      this.games = result;
      console.log("Games:" + this.games);
      console.log(result);
    }, error => console.error(error));
  }

  public loadLoans() {

    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);    
    this.http.get<Loans[]>(this.baseUrl + 'loans/get', { headers: header }).subscribe(result => {
      this.loans = result;
      console.log(result);
    }, error => console.error(error));
  }

  public updateLoans(id: string, dateLoan: string) {
    let JSONForm = JSON.stringify(this.formulario.value);
    console.log("JSON: " + JSONForm);
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);
    
    this.http.put(this.baseUrl + 'loans/update/' + id, JSONForm, { headers: header }).subscribe(result => {         
      console.log(result);
    }, error => console.error(error));
  }

  public renewLoans(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.put(this.baseUrl + 'loans/renew/' + id, id, { headers: header }).subscribe(result => {         
      console.log(result);
    }, error => console.error(error));
  }

  public deleteLoans(id: string) {
    const header = new HttpHeaders()
      .set('Content-type', 'application/json')
      .set('Authorization', `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNzIzNzMwLCJleHAiOjE2MTI3MjczMzB9.QLg2V1dbjLl-_RyRdTeh8LwtejG-bvw60RXNP1sPl4s`);

    this.http.put(this.baseUrl + 'loans/delete/' + id, id, { headers: header }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

}

interface Loans {
  Id: number,
  LoanDateBegin: string,
  LoanDateEnd: string,
  game: string,
  friend: string,
  IdGame: number,
  IdFriend: number 
}

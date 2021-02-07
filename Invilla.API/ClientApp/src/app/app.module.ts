import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { InputLoansComponent } from './input-loans/input-loans.component';
import { InputGamesComponent } from './input-games/input-games.component';
import { InputFriendsComponent } from './input-friends/input-friends.component';
import { MakeLoginComponent } from './make-login/make-login.component';
import { InputRolesComponent } from './input-roles/input-roles.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    InputFriendsComponent,
    InputGamesComponent,
    InputLoansComponent,
    MakeLoginComponent,
    InputRolesComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'input-friends', component: InputFriendsComponent },
      { path: 'input-games', component: InputGamesComponent },
      { path: 'input-loans', component: InputLoansComponent },
      { path: 'input-roles', component: InputRolesComponent },
      { path: 'make-login', component: MakeLoginComponent },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomepageComponent } from "./homepage/homepage.component";
import { ListsComponent } from "./homepage/lists/lists.component";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { SharedModule } from "./Shared/shared.module";
import { LoginComponent } from "./login/login.component";
import { AlertComponent } from "./alert/alert.component";
import { HomeComponent } from "./home/home.component";
import { RegisterComponent } from "./register/register.component";

import { JwtInterceptor } from "../app/Helpers/jwt.interceptor";
import { ErrorInterceptor } from "../app/Helpers/error.interceptor";

import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    ListsComponent,
    LoginComponent,
    AlertComponent,
    HomeComponent,
    RegisterComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

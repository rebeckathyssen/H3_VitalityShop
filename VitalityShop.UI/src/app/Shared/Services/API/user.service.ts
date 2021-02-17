import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { User } from "../../Models/user";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })
export class UserService {
  apiClass = "users";
  baseUrl: "https://localhost:44303/";
  constructor(private http: HttpClient) {}

  getAll() {
    //return this.http.get<User[]>(`${config.apiUrl}/users`);
    return this.http.get<User[]>(this.baseUrl + this.apiClass);
  }

  register(user: User) {
    //return this.http.post(`${config.apiUrl}/users/register`, user);
    //return this.http.post(this.baseUrl + this.apiClass + "/register/", user);
    return this.http.post("https://localhost:44303/users/register", user);
  }

  delete(id: number) {
    //return this.http.delete(`${config.apiUrl}/users/${id}`);
    return this.http.delete(this.baseUrl + this.apiClass + "/${id}");
  }
}

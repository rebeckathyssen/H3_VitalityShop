import { Component, OnInit } from "@angular/core";
import { first } from "rxjs/operators";

import { User } from "../Shared/Models/user";
import { UserService } from "../Shared/Services/API/user.service";
import { AuthenticationService } from "../Shared/Services/API/authentication.service";

/*
The home component contains logic for displaying the current user, a list of all users and enables the deletion of users.

The constructor() method assigns the currentUser property with the value authenticationService.currentUserValue so the current 
user can be displayed in the home component template.

The ngOnInit() method calls the this.loadAllUsers() method, which calls userService.getAll() and assigns the result to the this.users 
property so the users can be displayed in the home component template.

The deleteUser() method calls the userService.delete() method with the user id to delete. The user service returns an Observable that 
we .subscribe() to for the results of the deletion. On success the users list is refreshed by calling this.loadAllUsers(). The call to .pipe(first()) 
unsubscribes from the observable immediately after the first value is emitted. */

@Component({ templateUrl: "home.component.html" })
export class HomeComponent implements OnInit {
  currentUser: User;
  users = [];

  constructor(
    private authenticationService: AuthenticationService,
    private userService: UserService
  ) {
    this.currentUser = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
    this.loadAllUsers();
  }

  deleteUser(id: number) {
    this.userService
      .delete(id)
      .pipe(first())
      .subscribe(() => this.loadAllUsers());
  }

  private loadAllUsers() {
    this.userService
      .getAll()
      .pipe(first())
      .subscribe((users) => (this.users = users));
  }
}

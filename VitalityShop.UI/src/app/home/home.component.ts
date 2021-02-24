import { Component, OnInit } from "@angular/core";
import { first, subscribeOn } from "rxjs/operators";
import { ActivatedRoute } from "@angular/router";

import { User } from "../Shared/Models/user";
import { UserService } from "../Shared/Services/API/user.service";
import { AuthenticationService } from "../Shared/Services/API/authentication.service";
import { AlertService } from "../Shared/Services/alert.service";
import { Router } from "@angular/router";

/*
The home component contains logic for displaying the current user, a list of all users and enables the deletion of users.

The constructor() method assigns the currentUser property with the value authenticationService.currentUserValue so the current 
user can be displayed in the home component template.

The ngOnInit() method calls the this.loadAllUsers() method, which calls userService.getAll() and assigns the result to the this.users 
property so the users can be displayed in the home component template.

The deleteUser() method calls the userService.delete() method with the user id to delete. The user service returns an Observable that 
we .subscribe() to for the results of the deletion. On success the users list is refreshed by calling this.loadAllUsers(). The call to .pipe(first()) 
unsubscribes from the observable immediately after the first value is emitted. */

@Component({
  templateUrl: "home.component.html",
  styleUrls: ["home.component.scss"],
})
export class HomeComponent implements OnInit {
  userWithToken: User;
  currentUser: any;
  users = [];
  edit = false;

  constructor(
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private alertService: AlertService,
    private router: Router
  ) {
    this.userWithToken = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
    this.loadAllUsers();
    this.getUser();

    setTimeout(() => {
      // console.log("user with token " + this.userWithToken.housenumber);
      // console.log("any user? igen " + this.currentUser.email);
    }, 400);
  }

  getUser() {
    const id = this.userWithToken.userId;
    this.userService.getUser(id).subscribe((data) => {
      this.currentUser = data;
    });
  }

  deleteUser(id: string) {
    console.log(id);
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

  saveUser(user: User, userId: string) {
    this.userService.updateUser(user, user.userId).subscribe(
      (msg) => {
        console.log(msg);
        this.alertService.success("Kunde blev opdateret.", true);
      },
      (error) => console.log(error)
    );
    this.edit = false;
  }

  SetEditMode() {
    this.edit = true;
  }

  // to do: create endpoint to fetch the real zipids and cities
}

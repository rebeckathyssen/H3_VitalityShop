import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

import { AlertService } from "../Shared/Services/alert.service";

/* 
The alert component passes alert messages to the template whenever a message is 
received from the alert service. It does this by subscribing to the alert service's getMessage() method which returns an Observable.
*/
@Component({ selector: "alert", templateUrl: "alert.component.html" })
export class AlertComponent implements OnInit, OnDestroy {
  private subscription: Subscription;
  message: any;

  constructor(private alertService: AlertService) {}

  ngOnInit() {
    this.subscription = this.alertService.getAlert().subscribe((message) => {
      switch (message && message.type) {
        case "success":
          message.cssClass = "alert alert-success";
          break;
        case "error":
          message.cssClass = "alert alert-danger";
          break;
      }

      this.message = message;
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}

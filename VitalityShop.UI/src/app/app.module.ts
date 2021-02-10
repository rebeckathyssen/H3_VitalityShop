import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomepageComponent } from "./homepage/homepage.component";
import { ListsComponent } from "./homepage/lists/lists.component";
import { HttpClientModule } from "@angular/common/http";
import { SharedModule } from "./Shared/shared.module";

@NgModule({
  declarations: [AppComponent, HomepageComponent, ListsComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, SharedModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

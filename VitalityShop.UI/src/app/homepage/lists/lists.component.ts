import { Component, OnInit } from "@angular/core";
import { ProductService } from "src/app/Shared/Services/API/product.service";

@Component({
  selector: "app-lists",
  templateUrl: "./lists.component.html",
  styleUrls: ["./lists.component.scss"],
})
export class ListsComponent implements OnInit {
  // Inject our product service to call the API endpoints
  constructor(private productService: ProductService) {}

  // What needs to be shown on the page
  products: any[];

  ngOnInit() {
    // News-tab needs to be shown when page loads
    this.openCity(null, "News");

    // Subscribe to product-service on page-load so it's ready for show
    this.productService.GetAllProducts().subscribe((x) => {
      this.products = x;
      console.log(x);
    });
  }

  openCity(evt, cityName) {
    var i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    if (evt != null) {
      evt.currentTarget.className += " active";
    } else {
      document.getElementById("defaultOpen").click();
    }
  }
}

import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Product } from "../../Models/product.model";
import { environment } from "../../../../environments/environment";

@Injectable({ providedIn: "root" })
export class ProductService {
  apiClass = "product";
  constructor(public http: HttpClient) {}

  // Call endpoint to get all products
  public GetAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(
      environment.baseUrl + this.apiClass + "/GetAllProducts"
    );
  }

  public GetProduct(id: number): Observable<Product> {
    return this.http.get<Product>(
      environment.baseUrl + this.apiClass + "/GetProduct/" + id
    );
  }
}

import { Stock } from "./stock.model";
import { ProductCategory } from "./productcategory.model";

export class Product {
  productId: number;
  name: string;
  price: number;
  imgsrc: string;
  productCategory: ProductCategory;
  stock: Stock;
}

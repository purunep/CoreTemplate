import { Product } from './product';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators'
import { Observable } from 'rxjs';
import { Order, OrderItem } from './order';


@Injectable({
    providedIn: 'root'
})
export class DataService {
    private token: string = "";
    private tokenExpiration: Date;

    order: Order = new Order();
    products: Product[] = [];
    constructor(private http: HttpClient) { }

    loadProducts(): Observable<boolean> {
        return this.http.get('/api/products')
            .pipe(
                map((data: Product[]) => {
                    this.products = data;
                    return true;
                })
            );
    }


    public get LoginRequired(): boolean {
        return this.token.length <= 0 || this.tokenExpiration > new Date();
    }

    login(creds): Observable<boolean> {
        return this.http
            .post("/account/createtoken", creds)
            .pipe(
                map((data: any) => {
                    this.token = data.token;
                    this.tokenExpiration = data.expiration;
                    return true;
                })
            );
    }

    public checkout(): Observable<boolean> {
        if(!this.order.orderNumber) {
            this.order.orderNumber = 
            this.order.orderDate.getFullYear().toString() + this.order.orderDate.getTime().toString();
        }
        return this.http.post("/api/orders", this.order, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        })
            .pipe(
                map(response => {
                    this.order = new Order();
                    return true;
                })
            );
    }

    public AddToOrder(product: Product) {

        let item: OrderItem = this.order.items.find(i => i.productId == product.id);
        if (item) {
            item.quantity++;
        }
        else {
            item = new OrderItem();
            item.productId = product.id;
            item.productArtId = product.artId;
            item.productArtist = product.artist;
            item.productCategory = product.category;
            item.productSize = product.size;
            item.productTitle = product.title;
            item.unitPrice = product.price;
            item.quantity = 1;
            this.order.items.push(item);
        }


    }
}

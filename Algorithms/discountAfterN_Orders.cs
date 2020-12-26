/*
There is a sale in a supermarket, there will be a discount every n customer.
There are some products in the supermarket where the id of the i-th product is products[i] and the price per unit of this product is prices[i].
The system will count the number of customers and when the n-th customer arrive he/she will have a discount on the bill. (i.e if the cost is x the new cost is x - (discount * x) / 100). Then the system will start counting customers again.
The customer orders a certain amount of each product where product[i] is the id of the i-th product the customer ordered and amount[i] is the number of units the customer ordered of that product.

Implement the Cashier class:

Cashier(int n, int discount, int[] products, int[] prices) Initializes the object with n, the discount, the products and their prices.
double getBill(int[] product, int[] amount) returns the value of the bill and apply the discount if needed. Answers within 10^-5 of the actual value will be accepted as correct.
*/

using System;
using System.Collections.Generic;
// Time : init=> o(m)=> m is len of products, getbill=> o(k), k is len of product
// space o(m)
public class Cashier {
    int d,_n, count=0;
    Dictionary<int,int> map;
    

    public Cashier(int n, int discount, int[] products, int[] prices) {
        d= discount;
        _n=n;
        map = new Dictionary<int, int>();
        for(int i =0;i<products.Length;i++){
            map[products[i]] =prices[i];
        }
        
    }
    
    public double GetBill(int[] product, int[] amount) {
        double total = 0;
        for(int i=0; i<product.Length;i++){
            total+=map[product[i]]*amount[i];  
        }
        if(count+1==_n){
            count=0;
            total=total-(d*total)/100;
        }
        else{
            count++;
        }
        return total;
        
    }
}

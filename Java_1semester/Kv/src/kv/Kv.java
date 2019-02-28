/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package kv;

import java.util.Scanner;


public class Kv {

   static double a, b, c;
   static double d;
    public static void main(String[] args) {
        
        
     double a, b, c;
   double d;



System.out.println("Введите a, b и c:");

	
Scanner in = new Scanner(System.in);


a = in.nextDouble();
b = in.nextDouble();
c = in.nextDouble();


d = b * b - 4 * a * c;
if (d == 0) {
    double x;
    x = -b / (2 * a);
    System.out.println("Уравнение имеет единственный корень: x = " + x);
}
else {
    System.out.println("Дискриминант не равен 0");
}
    }
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package radius;

import java.util.Scanner;
public class Radius {

   static Scanner sc = new Scanner(System.in);
   
   public static void main(String args[])
   {
      System.out.print("Введите радиус(целое число): ");
    while (!sc.hasNextInt()) {
        
        System.out.println("Error!");
        sc.next(); 
    }
   double radius = sc.nextDouble();

      
      double area = Math.PI * (radius * radius);
      System.out.println("Площадь круга равна: " + area);
      
      
   }
    
}

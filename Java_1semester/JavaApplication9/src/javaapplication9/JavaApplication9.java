/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication9;
import java.util.Scanner;
/**
 *
 * @author student
 */
public class JavaApplication9 {
        static int page;
        static int news;
        static float n;
     
        
    public static void main(String[] args) {
         
        
        Scanner sc = new Scanner(System.in);

do {
  System.out.println("Введите количество новостей");
    while (!sc.hasNextInt()) {
        
        System.out.println("Error!");
        sc.next(); 
    }
    news = sc.nextInt();
} while (news <= 0);
System.out.println("Сегодня полученно  " + news );


        n = news % 10;
        
        calculation();
    }
    
    
    public static void calculation() {
     if (n == 0 ){
         
         page = news / 10;
     System.out.println("Количество страниц =  " +  page );
     }   
     
     else{
         
       
         page = (int)(news / 10) + 1;
      System.out.println("Количество страниц = " + page );
     }
       
}
}

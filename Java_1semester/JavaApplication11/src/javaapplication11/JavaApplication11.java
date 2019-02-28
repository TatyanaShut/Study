/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication11;


import java.util.Scanner;

/**
 *
 * @author student
 */
public class JavaApplication11 {
  
     

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int n;
        Scanner sc = new Scanner(System.in);

  System.out.println("Введите количество цифр в числе");
 

    while (!sc.hasNextInt()  )  {
        
        System.out.println("Error!");
        sc.next(); 
    }
    
    
    n = sc.nextInt();
    int [] array = new int[n];
    
    System.out.println(" ");
    String s = "Число: ";
    
    for (int i = 0; i < array.length; i++) {
        
    array[i] = (int) Math.round((Math.random() * 9));
    
    if (i!= array.length )
    s = s + array[i];
    
}
    System.out.println(s);
    System.out.print((s.length())-7);

   }

}
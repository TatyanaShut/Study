/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package laba2;
import java.util.Scanner;
/**
 *
 * @author tatyanashut
 */

public class Laba2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       Scanner in = new Scanner(System.in);
       System.out.print("Введите значение x = ");
       int x  = in.nextInt();
       System.out.print("Введите значение y = ");
       int y = in.nextInt();
       int sum = x+y;
       int pr = x*y;
       int ot = x-y;
       int del = x/y;
       int ost = x%y;
       System.out.println("Сумма: " +sum + "\n"+ "Произведение: " +pr+"\n" + 
               "Вычитание:" +ot+"\n" + "Деление: " +del+ "\n" + "Остаток от деления:" +ost+ "\n");
    }
    
}

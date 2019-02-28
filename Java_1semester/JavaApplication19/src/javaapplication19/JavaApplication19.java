/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication19;

import java.util.ArrayList;
import java.util.Scanner;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
/**
 *
 * @author tatyanashut
 */
public class JavaApplication19 {
 

    
     private static ArrayList<Gorod> strana = new ArrayList<>();  
    private static IndexGorod catalog [] = new IndexGorod[31];   
    private static final Scanner in = new Scanner(System.in);
    

    private static void fillStrana(String fileName) {
        String S = null;
        
         try(BufferedReader reader = new BufferedReader(new FileReader(new File(fileName)))) {
            while ((S = reader.readLine()) != null) {
                strana.add(new Gorod(S));
            }  // end while
        }  // end try
        catch (IOException e) {
            System.out.println(e);
        }  // end catch
        // strana.remove(0);
    } // end fillStrana
    

    private static void fillIndexCatalog() {
        char tempLitera = 'F';  // UTF-8, ANSI Windows. 'Ь' чтобы поймать начальный индекс 'А'
        int i = 0;
        int j = 0;
        
        for(Gorod gg: strana){
            if(gg.getFirstCharTitle() != tempLitera) {
                i = strana.indexOf(gg);                                // индекс Gorod в strana
                catalog[j]  = new IndexGorod(gg.getFirstCharTitle(), i);  // gg.getFirstCharTitle() первая буква наз. города
                tempLitera = gg.getFirstCharTitle();
                j++;
            } // end if
         } // end for
        
       for(i=0; i < catalog.length -1; i++) {
           catalog[i].setEndIndex( catalog[i+1].getBeginIndex() - 1);
           
       catalog[catalog.length - 1].setEndIndex(strana.size() - 1);
       } // end for
    } //  end  fillIndexCatalog
 

    private static String getAnswer(String quest) {
        int beginIndexGorod = 0, endIndexGorod = 1;
        String answer = "F";
        final char  tempChar = quest.toUpperCase().charAt(quest.length() -1);
        
        for(IndexGorod indG: catalog) {
            if(indG.getLitera() == tempChar) {
                beginIndexGorod = indG.getBeginIndex();
                endIndexGorod = indG.getEndIndex();
                break;
            } // end if
        } // end for
        
        for(int i = beginIndexGorod; i < endIndexGorod +1; i++) {
            if(!strana.get(i).getUsed()) {
                answer = strana.get(i).getTitle();
                strana.get(i).setUsed();    // компьютер использовал название города
                 break;
            } //  end if
        } // end for
        
        return answer;
    } 

    private static boolean getTrueGorod(String questGr) {
        int beginIndexGorod = 0, endIndexGorod = 1;
        boolean answer = false;
        final char  tempChar = questGr.toUpperCase().charAt(0);   // первая буква названия города
        
        questGr = questGr.replace(questGr.charAt(0), tempChar);   //если начало с мелкой буквы, замена ее большой
        
        for(IndexGorod indG: catalog) {
            if(indG.getLitera() == tempChar) {
                beginIndexGorod = indG.getBeginIndex();
                endIndexGorod = indG.getEndIndex();
                break;
            } // end if
        } // end for
        
        for(int i = beginIndexGorod; i < endIndexGorod +1; i++) {
            if((!strana.get(i).getUsed()) && (strana.get(i).getTitle().compareTo(questGr) == 0)) {
                answer = true;
                strana.get(i).setUsed();   // далее этот город не учавствует в игре
                 break;
            } //  end if
            
        } // end for
        
        return answer;
    } // end getTrueGorod
    

    public static void main(String[] args) {
        String ss;
        
        fillStrana("cities_ru.txt"); 
        fillIndexCatalog();
        
        System.out.print("Ваш первый ход! ");
        ss = in.nextLine();
                
        while(getTrueGorod(ss)) {
            System.out.println(getAnswer(ss));
            System.out.println("Вы?");
            ss = in.nextLine();
            
            if(!getTrueGorod(ss)){
            System.out.println("Error");
            ss = in.nextLine();
            
        
            
            }else{
                
                System.out.println(getAnswer(ss));
            System.out.println("Вы?");
            ss = in.nextLine();
            }
        } // end while
    } // end main  
}
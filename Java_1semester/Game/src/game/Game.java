/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package game;

import java.util.ArrayList;
import java.io.*;

public class Game {

   private static ArrayList<Gorod> strana = new ArrayList<>();  
    private static IndexGorod catalog [] = new IndexGorod[31];   
  //  private static final Scanner in = new Scanner(System.in);
    
// ##############################################################
     // strana заполняется объектами gorod из отсортированного списка наход. файле cities_ru.txt
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
    
// ##############################################################
    // заполняется catalog объектами IndexGorod,  буквами и  индексами объектов gorod из списка strana
    // например:  0 <-- 'A' --> 52, т.е. города на 'A' расположены в strana с 0 по 52 позицию
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
 
 // ##############################################################
    // дает верный ответ по правилам игры "Города"
    // например: даем "Москва", получаем "Абакан"
    // после выдачи, город считается использованным, т.е. больше не выдается
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
    } // end getAnsver
// ##############################################################
    // есть ли такой город (его название) в России
    // если есть, то второй раз его уже не используют (игрок применил его)
    private static boolean getTrueGorod(String questGr) {
        int beginIndexGorod = 0, endIndexGorod = 1;
        boolean answer = false;
        final char  tempChar;
        
        questGr = questGr.toUpperCase();   //если начало с мелкой буквы, замена ее большой
        tempChar = questGr.charAt(0);   // первая буква названия города
        
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
        
      if(!answer) {
          System.out.println("Такого города нет в России (города крыма не учитываются), либо он уже использован ранее");  
         } // end if         
        
        return answer;
    } // end getTrueGorod
    
// ##############################################################
    public static void main(String[] args) throws IOException {
        String enc = System.getProperty("file.encoding");
        System.out.println(enc);
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in, "windows-1251"));
        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out, enc));
        
        fillStrana("cities_ru.txt"); 
        fillIndexCatalog();
        
        System.out.print("Ваш первый ход! \nМожно использовать названия городов России (без крымских)\n");
        String ss = br.readLine();
       
                
        while(getTrueGorod(ss)) {
            System.out.println(getAnswer(ss));
            System.out.println("Ваш город?");
           ss = br.readLine();
        } // end while     
    } // end main
    
}
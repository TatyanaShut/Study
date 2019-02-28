/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication19;

/**
 *
 * @author tatyanashut
 */
public class Gorod {
    private final String title;
    private  char asLinkDw = '@';
    private boolean used = false;
    
    Gorod(String titl){
        
        title = titl;
        asLinkDw = title.toUpperCase().charAt(title.length() - 1);   
        
        // если последний символ "Ь" или "Ы", берем предпоследний
        if((asLinkDw == 'Ь')||(asLinkDw =='Ы')){
             asLinkDw = title.toUpperCase().charAt(title.length() - 2);
        } // end if
        
    } // end Gorod
 
    char getFirstCharTitle() {
        return title.charAt(0);
    } // end getFirstCharTitle   
    
    String getTitle() {
        return title;
    } // end getFirstCharTitle   
    
    boolean getUsed(){
        return used;
    } // end Used
    
    void setUsed(){
         used = true;
    } // end Used
   
} // end class

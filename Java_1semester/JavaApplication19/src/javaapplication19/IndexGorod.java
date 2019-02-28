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
public class IndexGorod {
  
    private final char litera;
    private final int beginIndex;
    private int endIndex;
    
    IndexGorod(char literaGorod, int beginIndexGorod) {
        litera = literaGorod;
        beginIndex = beginIndexGorod;
       
    } // end constructor
    
    char getLitera() { 
        return litera;
    }  // end getLitera
    
    int getBeginIndex() { 
        return beginIndex;
    }  // end getBeginIndex
    
    int getEndIndex() { 
        return endIndex;
    }  // end getEndIndex
    
    void setEndIndex(int endIndexGorod) { 
         endIndex = endIndexGorod;
    }  // end setEndIndex
} // end class


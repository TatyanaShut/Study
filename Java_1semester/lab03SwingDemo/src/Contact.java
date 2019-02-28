/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author tatyanashut
 */
public class Contact {
    String name;
    String cost;
    
    public Contact (String name, String cost) {
    this.name = name;
    this.cost = cost;
    
    }
    
    public String getName(){
    return name;
    }
     
   public void setName (String name){
   this.name = name;
   }
   
   public String getCost(){
       return cost;
   }
   public void setCost(String middlename){
       this.cost = cost;
   
   }
}   
    


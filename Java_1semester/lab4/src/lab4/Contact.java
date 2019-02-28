package lab4;

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
    String surname;
    
    public Contact (String name, String surname){
        this.name = name;
        this.surname = surname;
    
    }
    
    public String getName(){
    return name;
    
    }
    
    public void SetName(String name){
    this.name = name;
    }
    
    public String getSurname(){
    return surname;
    }
    
    public void setSurname(String middlename){
    this.surname = surname;
    }
    
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package lab4;

import java.io.*;

import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;
import java.io.File;


/**
 *
 * @author tatyanashut
 */
public class Lab4 {
    private static String filename;
    private static String fileText;
    private static Scanner scan = new Scanner(System.in);
    
   
    public static void main(String[] args) throws FileNotFoundException {
       System.out.println(" Укажите Имя файла \n");
      
       Contact contact = new Contact ("Tatyana "," Shut");
      // writeFile(contact);
       readFile();
    }
    
    private static void writeFile (Contact contact){
        
               try{

              filename = scan.nextLine();
              
           
              File newFile = new File(filename); 
              
           
             
              File testFile = new File(fileText);
             
              
              FileWriter writer = new FileWriter (filename);
              
                  
             
              
          
              
              
             String textForFile = (contact.getName()+ " " + contact.getSurname());
             writer.write(textForFile);
              boolean created = newFile.createNewFile();
              
              if(created)
              System.out.println("File has been created");
                writer.write(textForFile);
             
              //writer.flush();
              writer.close();
             
          
              System.out.println("Good \n");
              
        }
        
        catch (IOException  ex) {
        ex.printStackTrace();
        System.out.println("Error \n");
        }
    
    }
    
    
    private static void readFile() throws FileNotFoundException{
        String filePath = scan.nextLine();
        
        File fileToRead = new File(filePath);
        Scanner scanner = new Scanner(fileToRead);
        
        while(scanner.hasNextLine()){
        System.out.println(scanner.nextLine());}
        
    
    }
    
    
    
}

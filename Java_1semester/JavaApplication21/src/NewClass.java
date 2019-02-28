
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author tatyanashut
 */


import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
/**
 *
 * @author tatyanashut
 */
public class NewClass {

   static  ArrayList<String> list = new ArrayList<>();
 
    static {
        fillList();
    }
 
 
    private static void fillList() {
 
        try(BufferedReader reader = new BufferedReader(new FileReader(new File("cities.txt")))) {
 
            String S = null;
 
            while ((S = reader.readLine()) != null) {
                list.add(S);
            }
 
 
        } catch (IOException e) {
            e.printStackTrace();
        }
 
    }
 
     static String sendAnswer(String S) {
 
        char last = S.charAt(S.length() - 1);
 
        int lo = 0;
 
        int hi = list.size() - 1;
 
        while (lo <= hi) {
 
            int med = hi - (hi - lo) / 2;
 
            if (list.get(med).charAt(0) == Character.toUpperCase(last)) return list.get(med);
 
            else if (list.get(med).charAt(0) > Character.toUpperCase(last)) hi = med - 1;
 
            else lo = med + 1;
        }
 
        return null;
    }
 
    static boolean isContains(String city) {
 
        boolean flag = false;
 
        int lo = 0;
 
        int hi = list.size() - 1;
 
        while (lo <= hi) {
 
            int med = hi - (hi - lo) / 2;
 
            if (list.get(med).equalsIgnoreCase(city)) {flag = true;break;}
 
            else if (list.get(med).compareToIgnoreCase(city) > 0) hi = med - 1;
 
            else lo = med + 1;
        }
 
        return flag;
    }
 
}


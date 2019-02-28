/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package array;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;


public class Array {

    private int[][] massiv;
    File file = new File("Test.txt");
    public Array() throws IOException
    {
        file.createNewFile();
        massiv = new int[3][3];
        CreateArray();
    }
    private void CreateArray()
    {
        for (int i=0;i<3;++i)
            for (int j=0;j<3;++j)
                massiv[i][j] = 1;
    }
    public void WriteFile() throws IOException
    {
        CreateArray();
        FileWriter filewriter = new FileWriter(new File("Test.txt"));
 
        for (int i=0;i<3;++i)
            for (int j=0;j<3;++j)
                filewriter.write(massiv[i][j] + " ");
                filewriter.flush();
    }
    public void ReadFile() throws FileNotFoundException, IOException
    {
 
        Scanner scannerfile = new Scanner(file);
        for(int i=0;i<3;++i)
        {
            for (int j=0;j<3;++j)
            {
                if(scannerfile.hasNextInt())
                    massiv[i][j]=scannerfile.nextInt();
            }
 
        }
        System.out.print("Введенный массив\n");
        for(int i=0;i<3;++i)
        {
            for (int j=0;j<3;++j)
            {
                System.out.print(massiv[i][j] + " ");
            }
            System.out.print("\n");
        }
 
    }
    public static void main(String[] args) throws IOException
    {
        Array test = new Array();
 
 
        test.WriteFile();
    }
    
}

package com.company;

public class Furniture implements IntFurniture {

    protected String fName;
    protected int fSquare;


    public Furniture(String fName, int fSquare) {
        this.fName = fName;
        this.fSquare = fSquare;}

    public int furnitureSquare() {
        return fSquare;
    }
    public String furnitureName() {
        return fName;
    }

}

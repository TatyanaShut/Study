package com.company;


import java.util.ArrayList;
import java.util.List;

public class Room implements IntRoom{

    private int windowNum;
    private int square;
    private String roomName;
    static final int MAXLIGHT = 4000;
    static final int MAXSQUAREPERCENT = 70;
    static final int WINDOWLIGHT = 700;
    private List<Furniture> furnitures = new ArrayList<>();
    private List<Lamp> lamps = new ArrayList<>();

    public Room(String roomName, int square, int windowNum) {
        this.roomName = roomName;
        this.square = square;
        this.windowNum = windowNum;
    }

    public void add(Chair chair) {

        if(isSpaceUsageTooMuch(chair.furnitureSquare())==true){

            furnitures.add(chair);
        } else {
            try {
                throw new WrongSpaceException("Too little free space!");
            } catch (WrongSpaceException e) {
                e.printStackTrace();
            }catch (NullPointerException e){
                System.out.println("You can not add furniture to a non-existent room!");
            }
        }

    }

    public void add(Table table) {
        if(isSpaceUsageTooMuch(table.furnitureSquare())==true){

            furnitures.add(table);
        } else {
            try {
                throw new WrongSpaceException("Too little free space!");
            } catch (WrongSpaceException e) {
                e.printStackTrace();
            }catch (NullPointerException e){
                System.out.println("You can not add furniture to a non-existent room!");
            }
        }
    }


    public void add(Lamp lamp) {
        if(isIlluminanceTooMuch(lamp.getLampLight())==true) {
            lamps.add(lamp);
        } else{
            try {
                throw new WrongIlluminanceException("Lighting exceeds the maximum!");
            } catch (WrongIlluminanceException e) {
                e.printStackTrace();
            }catch (NullPointerException e){
                System.out.println("You can not add lightbulb to a non-existent room!");
            }
        }
    }


    public  String getRoomName(){
        return roomName;
    }

    public int getSquare() {
        return square;
    }

    public int getWindowNum() {
        return windowNum;
    }

    public List<Furniture> getFurnitures() {
        return furnitures;
    }

    public List<Lamp> getLamps() {
        return lamps;
    }

    public int getTotalLightOfLamps(){
        List<Lamp> lamps = getLamps();
        int totalLight = 0;
        for (Lamp l:lamps) {
            totalLight+=l.getLampLight();
        }
        return totalLight;
    }

    public int getOccupiedSpace(){
        List<Furniture> furnitures = getFurnitures();
        int totalSquare=0;
        for (Furniture f:furnitures) {
            totalSquare+=f.furnitureSquare();
        }
        return totalSquare;
    }

    private int getFreeSpace(){
        int notFree = getOccupiedSpace();
        int freeSpace = 0;
        int roomSquare = getSquare();
        freeSpace = roomSquare - notFree;
        return freeSpace;
    }

    private int freeSpacePercent() {
        int notFree = getOccupiedSpace();
        int freeSpace = getFreeSpace();
        int roomSquare = getSquare();
        int freeSpacePercent = 0;
        try {
            freeSpacePercent = (100 - ((100 * notFree) / roomSquare));
        }catch (ArithmeticException e){
            System.out.println("The area of the room can not be equal to 0");
        }
        return freeSpacePercent;
    }

    private String getLampsDesc(){
        List<Lamp> lamps = getLamps();
        StringBuilder out = new StringBuilder();
        if(!lamps.isEmpty()) {
            List<Integer> list = new ArrayList<>();
            int sq = 0;
            for (Lamp l : lamps) {
                sq = l.getLampLight();
                list.add(sq);
            }
            out.append(", lightbulb ");
            for (Object o : list) {
                out.append(o.toString() + "lk");
                int index = list.indexOf(o);
                if (index == (list.size() - 1)) {
                    out.append(")");
                } else {
                    out.append(" and ");
                }
            }
        }else{
            out.append(")");
        }
        return out.toString();
    }

    private String  getFurnituresDesc(){
        List<Furniture>  furnitures = getFurnitures();
        if(!furnitures.isEmpty()) {
            List<String> list = new ArrayList<>();
            String name = "";
            int sq = 0;
            int sq2 = 0;
            String stroka = "";
            for (Furniture f : furnitures) {
                name = f.furnitureName();
                sq = f.furnitureSquare();
                sq2 = f.furnitureSquare();
                stroka = name + " (square " + sq + "м^2)"/* + sq2 +"м^2)"*/;
                list.add(stroka);
            }
            StringBuilder out = new StringBuilder();
            for (Object o : list) {
                out.append(o.toString());
                out.append("\n");
            }

            return "furniture:"  + "\n" + out.toString();
        } else{
            return "no furniture";
        }
    }

    private boolean isSpaceUsageTooMuch(int square){
        int totalSquare=getOccupiedSpace() + square;
        int roomSquare = getSquare();
        try {
            int x = (100 * totalSquare) / roomSquare;
            if (x < MAXSQUAREPERCENT) {
                return true;
            }
        }catch (ArithmeticException e){
            System.out.println("The area of the room can not be equal to 0");
        }
        return false;
    }

    private boolean isIlluminanceTooMuch(int light){
        int totalLight = getTotalLightOfLamps() + light;
        int x = totalLight + (getWindowNum()*WINDOWLIGHT);
        if(x < MAXLIGHT){
            return true;
        }
        return false;
    }

    @Override
    public String toString(){
        return getRoomName() + " " +
                "\n" + "Illumination = " + (getTotalLightOfLamps()+ (getWindowNum()*WINDOWLIGHT)) + "(" + getWindowNum() + " 700 lux windows " + getLampsDesc() +
                "\n" + "squre = " + getSquare() + " м^2 (busy " + getOccupiedSpace() + " м^2, free" +
                + getFreeSpace() + " м^2 or " + freeSpacePercent() + " % squre)" +
                "\n" +  getFurnituresDesc()  ;
    }
}

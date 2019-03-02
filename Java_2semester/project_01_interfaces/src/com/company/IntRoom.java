package com.company;

public interface IntRoom {

   public String getRoomName();
   public int getSquare();
   public int getWindowNum();
   public int getTotalLightOfLamps();
   public int getOccupiedSpace();
   public String toString();

   public void add(Chair chair);
   public void add(Lamp lamp);
   public void add(Table table);
}

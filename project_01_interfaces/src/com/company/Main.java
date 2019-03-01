package com.company;

public class Main {

    public static void main(String[] args) {
	// create your room
        Building building = new Building("building 1");
        Room room1 = new Room("room 1", 100, 3);
        Room room2 = new Room("room 2", 50, 2);

        building.addRoom(room1);
        building.addRoom(room2);
        building.getRoom("room 1").add(new Table("table",50));
        building.getRoom("room 1").add(new Chair("soft and fluffy chair",1,2));
        building.getRoom("room 1").add(new Lamp("lightbulb",150));
        building.getRoom("room 1").add(new Lamp("lightbulb",250));

        building.getRoom("room 2").add(new Table("table",500));
        building.getRoom("room 2").add(new Chair("soft and fluffy chair",3,2));
        building.getRoom("room 2").add(new Lamp("lightbulb",150));
        building.getRoom("room 2").add(new Lamp("lightbulb",250));

        building.describe();


    }
}

package com.fitr.factory.method;


/**
 *
 * Паттерн Factory Method предназначен для создания объектов без явного указания класса создаваемого объекта.
 * Вместо прямого вызова конструктора вызывается метод, указаный в интерфейсе и реализованный в дочерних классах.
 * Как вариант, он может быть задан в суперклассе и переопределен в дочерних классах.
 *
 * Есть два кузнеца, которые умеют ковать оружие для своих персонажей: эльфийское копье отличается от оркского и т.д.
 *
 * В данном примере есть интерфейс Blacksmith с методом Blacksmith.manufactureWeapon для создания объектов.
 * Дочерние классы OrcBlacksmith и ElfBlacksmith переопределяют метод и создают собственные объекты.
 */
public class  App {

  private final Blacksmith blacksmith;

  /**
   * В данном классе создаются экземпляры оружия. При этом данный класс не знает, какая именно
   * реализация класса Blacksmith используется.
   */
  public App(Blacksmith blacksmith) {
    this.blacksmith = blacksmith;
  }

  public static void main(String[] args) {
    // Заказываем оркское оружие
    App app = new App(new OrcBlacksmith());
    app.manufactureWeapons();

    // Заказываем эльйийское оружие
    app = new App(new ElfBlacksmith());
    app.manufactureWeapons();

    // TODO: Реализовать заказ человеческого (human) оружия
  }

  private void manufactureWeapons() {
    Weapon weapon;
    weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
    System.out.println(weapon.toString());
    weapon = blacksmith.manufactureWeapon(WeaponType.AXE);
    System.out.println(weapon.toString());
  }
}

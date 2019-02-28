/**
 * The MIT License
 * Copyright (c) 2014-2016 Ilkka Seppälä
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
package com.fitr.factory.method;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;


public class FactoryMethodTest {

  /**
   * Проверяет производство оркского SPEAR.
   */
  @Test
  public void testOrcBlacksmithWithSpear() {
    Blacksmith blacksmith = new OrcBlacksmith();
    Weapon weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
    verifyWeapon(weapon, WeaponType.SPEAR, OrcWeapon.class);
  }

  /**
   * Проверяет производство оркского AXE
   */
  @Test
  public void testOrcBlacksmithWithAxe() {
    Blacksmith blacksmith = new OrcBlacksmith();
    Weapon weapon = blacksmith.manufactureWeapon(WeaponType.AXE);
    verifyWeapon(weapon, WeaponType.AXE, OrcWeapon.class);
  }

  /**
   * Проверяет производство эльфийского SHORT_SWORD
   */
  @Test
  public void testElfBlacksmithWithShortSword() {
    Blacksmith blacksmith = new ElfBlacksmith();
    Weapon weapon = blacksmith.manufactureWeapon(WeaponType.SHORT_SWORD);
    verifyWeapon(weapon, WeaponType.SHORT_SWORD, ElfWeapon.class);
  }

  /**
   * Проверяет производство эльфийского SPEAR
   */
  @Test
  public void testElfBlacksmithWithSpear() {
    Blacksmith blacksmith = new ElfBlacksmith();
    Weapon weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
    verifyWeapon(weapon, WeaponType.SPEAR, ElfWeapon.class);
  }

  /**
   * Проверяет класс и тип оружия.
   * 
   * @param weapon проверяемый объект
   * @param expectedWeaponType ожидаемый тип оружия
   * @param weaponClass ожидаемый класс оружия
   */
  private void verifyWeapon(Weapon weapon, WeaponType expectedWeaponType, Class<?> weaponClass) {
    assertTrue(weaponClass.isInstance(weapon), "Weapon must be an object of: " + weaponClass.getName());
    assertEquals(expectedWeaponType, weapon.getWeaponType(), "Weapon must be of weaponType: " + expectedWeaponType);
  }
}

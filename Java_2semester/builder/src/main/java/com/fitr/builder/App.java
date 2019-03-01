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
package com.fitr.builder;

/*
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
*/

import java.util.logging.Logger;

/**
 * Основное назначение паттерна Builder - избавиться от переусложненных конструкторов с большим количеством параметров,
 * в которых легко допустить ошибки, либо большого количества перегруженных конструкторов дл яразличных ситуаций.
 *
 * Смысл Builder в использовании для создания объекта другого объекта-билдера, который получает параметры инициализации
 * по одному, а затем возвращает итоговый сконструирвоанный объект.
 *
 * Builder хорошо подходит для обработки объектов, содержащих html-код, SQL-запросы и другие данные, которые не могут быть
 * заданы постепенно.
 *
 * ЗАДАНИЕ
 * Данное приложение создает объекты Hero, у которых много параметров.
 * Минимальный набор параметров задается в конструкторе Hero.
 * Реализуйте класс Hero.Builder. Дополнительные параметры Hero должны задаваться его методами.
 *
 * Просмотрите и реализуйте _все_ TODO-элементы в коде приложения,
 * опираясь на знание структуры паттерна Builder, аналогии в коде приложения и здравый смысл.
 * Добейтесь корректного вывода результатов в консоль.
 *
 */
public class App {

  //private static final Logger LOGGER = LoggerFactory.getLogger(App.class);

  /**
   * Основной класс приложения
   * 
   * @param args command line args
   */
  public static void main(String[] args) {

    Hero mage =
        new Hero.Builder(Profession.MAGE, "Гэндальф").withHairColor(HairColor.WHITE)
            .withWeapon(Weapon.DAGGER).build();
   // LOGGER.info(mage.toString());//system.out.println
    System.out.println(mage.toString());

    Hero warrior =
        new Hero.Builder(Profession.WARRIOR, "Конан").withHairColor(HairColor.BLACK)
            .withHairType(HairType.LONG_STRAIGHT).withWeapon(Weapon.SWORD).withArmor(Armor.PLATE_MAIL)
            .build();
    // TODO: вооружить Конана мечом и пластинчатым доспехом.//

    //LOGGER.info(warrior.toString());
    System.out.println(warrior.toString());

    // TODO: Создать вооруженного луком лысого вора по имени Болдрик и вывести информацию о нем в консоль.//
    Hero thief =
            new Hero.Builder(Profession.THIEF, "Болдрик").withHairColor(HairColor.BLACK)
                    .withHairType(HairType.BALD).withWeapon(Weapon.BOW).withArmor(Armor.PLATE_MAIL)
                    .build();

    //LOGGER.info(warrior.toString());
    System.out.println(thief.toString());


  }
}

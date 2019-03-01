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

/**
 * 
 * Hero, класс с большим количеством возможных параметров.
 * 
 */
public final class Hero {

  private final Profession profession;
  private final String name;
  private final Armor armor;
  private final Weapon weapon;
  private  final HairType hairType;
  private  final HairColor hairColor;

  // TODO: добавьте недостающий код //

  private Hero(Builder builder) {
    // TODO: добавьте недостающий код //
    this.profession = builder.profession;
    this.name = builder.name;
    this.weapon = builder.weapon;
    this.armor = builder.armor;
    this.hairType = builder.hairType;
    this.hairColor = builder.hairColor;
  }

  public Profession getProfession() {
    return profession;
  }

  public String getName() {
    return name;
  }

  public HairType getHairType() {
    return hairType;
  }

  public HairColor getHairColor() {
    return hairColor;
  }

  // TODO: добавьте недостающий код//

  public Armor getArmor() {
    return armor;
  }

  public Weapon getWeapon() {
    return weapon;
  }

  @Override
  public String toString() {

    StringBuilder sb = new StringBuilder();
    sb.append("Это ")
            .append(profession)
            .append(" по имени ")
            .append(name);
    if (hairColor != null || hairType != null) {
      sb.append(" с ");
      if (hairColor != null) {
        sb.append(hairColor).append(' ');
      }
      if (hairType != null) {
        sb.append(hairType).append(' ');
      }
      sb.append(hairType != HairType.BALD ? "волосами" : "головой");
    }
    if (armor != null) {
      sb.append(" носящий ").append(armor);
    }
    if (weapon != null) {
      sb.append(" и вооруженный ").append(weapon);
    }
    sb.append('.');
    return sb.toString();
  }

  /**
   * 
   * Внутренний класс-builder.
   * 
   */
  public static class Builder {

    private final Profession profession;
    private final String name;
    private HairType hairType;
    private HairColor hairColor;
    private Armor armor;
    private Weapon weapon;

    /**
     * Конструктор с обязательными параметрами
     */
    public Builder(Profession profession, String name) {
      if (profession == null || name == null) {
        throw new IllegalArgumentException("класс и имя не могут быть пустыми");
      }
      this.profession = profession;
      this.name = name;
    }
    // методы для добавления необязательных параметров

    public Builder withHairType(HairType hairType) {
      this.hairType = hairType;
      return this;
    }

    public Builder withHairColor(HairColor hairColor) {
      this.hairColor = hairColor;
      return this;
    }

    public Builder withArmor(Armor armor){
      this.armor = armor;
      return  this;
    }

    public Builder withWeapon(Weapon weapon){
      this.weapon = weapon;
      return this;
    }
    // TODO: добавьте недостающие методы builder-класса//


    public Hero build() {
      return new Hero(this);
      // TODO: добавьте недостающий код//
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lesson9_classes_part1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            Character monster = new Character();

            hero.Name = "Beowulf";
            hero.Health = 70;
            hero.DamageMaximum = 15;
            hero.AttackBonus = true;

            monster.Name = "Grendel";
            monster.Health = 100;
            monster.DamageMaximum = 20;
            monster.AttackBonus = false;

            // One attack each for hero and monster
            monster.Defend(hero.Attack());
            hero.Defend(monster.Attack());

            DisplayCharacter(hero);
            DisplayCharacter(monster);
        }

        public void DisplayCharacter(Character theCharacter)
        {
            displayLabel.Text += String.Format("Name: {0} <br />  Health: {1} <br /> DamageMaximum: {2} <br /> AttackBonus: {3} <br /><br />",
                                                theCharacter.Name,
                                                theCharacter.Health.ToString(),
                                                theCharacter.DamageMaximum.ToString(),
                                                theCharacter.AttackBonus.ToString());
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random randomNum = new Random();
            return randomNum.Next(1, this.DamageMaximum + 1);
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }
}
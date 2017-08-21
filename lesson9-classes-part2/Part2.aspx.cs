using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lesson9_classes_part2
{
    public partial class Part2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            Character monster = new Character();
            Dice dice = new Dice();

            hero.Name = "Beowulf";
            hero.Health = 70;
            hero.DamageMaximum = 15;
            hero.AttackBonus = true;

            monster.Name = "Grendel";
            monster.Health = 100;
            monster.DamageMaximum = 20;
            monster.AttackBonus = false;

            // Determine if either participant has a bonus attack; if so, resolve that attack now
            if (hero.AttackBonus)
                monster.Defend(hero.Attack(dice));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(dice));

            // While both characters have positive health, continue the battle...
            while (hero.Health > 0 && monster.Health > 0)
            {
                hero.Defend(monster.Attack(dice));
                monster.Defend(hero.Attack(dice));
            }

            displayResult(hero, monster);
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health > 0 && opponent2.Health <= 0)
                resultLabel.Text = String.Format("{0} has defeated {1}. All hail {2}", opponent1.Name, opponent2.Name, opponent1.Name);
            
            else if (opponent1.Health <= 0 && opponent2.Health > 0)
                resultLabel.Text = String.Format("{0} has defeated {1}. Boo...Hiss...You'll get yours soon enough, {2}!", opponent2.Name, opponent1.Name, opponent2.Name);
            
            else if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text = String.Format("Both {0} and {1} have died in glorious combat.", opponent1.Name, opponent2.Name);
            

        }

        /*  Not used in this part of the challenge
         *  
        private void displayCharacter(Character theCharacter)
        {
            resultLabel.Text += String.Format("Name: {0} <br />  Health: {1} <br /> DamageMaximum: {2} <br /> AttackBonus: {3} <br /><br />",
                                                theCharacter.Name,
                                                theCharacter.Health.ToString(),
                                                theCharacter.DamageMaximum.ToString(),
                                                theCharacter.AttackBonus.ToString());
        }
        */
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            dice.Sides = this.DamageMaximum;
            return dice.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    public class Dice
    {
        public int Sides { get; set; }

        Random randomNum = new Random();

        public int Roll()
        {
            int side = this.Sides;
            return randomNum.Next(1, side + 1);
        }
    }

}
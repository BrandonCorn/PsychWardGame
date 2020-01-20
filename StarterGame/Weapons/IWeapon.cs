using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon : I_Item
    {
        //The attack power of the weapon
        int Attack { get; set; }

        //The cost of repairing the weapon
        int RepairCost { get; }

        //Total number of times weapon can be used. This can be changed with upgrade of weapons. 
        int MaxUse { get; set; }

        /**Returns the total strength of the player
         * @params: (Player) uses the player to return total attack power of weapon attack and player attack
         * @return: (int) Total attack power of player including weapon
         **/
        int getStrength(Player player);

        /**
         * Method that must be used by items implementing I_Item interface. Lets the player know they cannot use the weapon as an
         * item. 
         * @params: (Player) player using the weapon
         * @returns: void
         **/
        new void useItem(Player player);

        /**
         * A unique prompt for the player that is using the weapon when in battle
         * @params: (Player) The player using the weapon
         * @returns: void
         **/
        void useWeaponDescription(Player player);

        /**
         * Notes and removes one use each time the player uses the weapon.
         * @params: (Player) player using the weapon
         * @returns: void
         **/
        void useWeapon(Player player);

    }
}

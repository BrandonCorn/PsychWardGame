using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarterGame
{
    public class FightCommand : Command
    {
        public FightCommand() : base()
        {
            this.name = "fight";
            
        }
        //If the player fights the enemy, if they kill the enemy then this returns false to exit the 
        //battle sequence in the GameWorld, otherwise it remains true. 
        public override bool execute(Player player)
        {
            Thread.Sleep(2000);
            IEnemy enemy = player.currentRoom.CurrentEnemy;
            //Here the player's speed is higher than the enemy so they swing first. 
            if (player.Speed >= enemy.Speed)
            {
                player.attackEnemy();
                if (player.defeatedEnemy(enemy))
                {
                    NotificationCenter.Instance.postNotification(new Notification("BattleOver", player));
                    player.outputMessage("You defeated the enemy!");

                    if (enemy.GetType() == typeof(FinalBoss))
                    {
                        player.outputMessage("You Beat the Game");
                        return true;
                    }
                    player.outputMessage("\n" + player.currentRoom.description());
                    return false;
                }
                else { enemy.currentStats(); }

                Thread.Sleep(3000);

                enemy.attackPlayer(player);
                if (player.playerDefeated())
                {
                    player.outputMessage("You died");
                    return true;
                }
                else { player.currentStats(); }
            }

            //In this circumstance the players speed is lower than that of the enemy. 
            else
            {
                enemy.attackPlayer(player); 
                if (player.playerDefeated())
                {
                    player.outputMessage("You died!");
                    return true;
                }
                else { player.currentStats(); }

                Thread.Sleep(3000);

                player.attackEnemy();
                if (player.defeatedEnemy(enemy))
                {
                    NotificationCenter.Instance.postNotification(new Notification("BattleOver", player));

                    if (enemy.GetType() == typeof(FinalBoss))
                    {
                        player.outputMessage("You Beat the Game");
                        return true;
                    }
                    player.outputMessage("\n" + player.currentRoom.description());
                    return false;
                }
                else { enemy.currentStats(); }

            }
            return false;
        }
    }
}

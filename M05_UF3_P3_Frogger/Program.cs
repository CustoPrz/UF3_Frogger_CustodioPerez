using System;
using System.Collections.Generic;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Utils.MAP_WIDTH, Utils.MAP_HEIGHT);
            Console.SetBufferSize(Utils.MAP_WIDTH, Utils.MAP_HEIGHT);

            Player player = new Player();
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, true, 0f, Utils.charLogs, new List<ConsoleColor> {ConsoleColor.Gray}));
            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, false, true, 0.35f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Gray }));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Gray }));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.5f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Gray }));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.5f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Gray }));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.45f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Gray }));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Gray }));

            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkCyan, ConsoleColor.Cyan }));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Gray, ConsoleColor.DarkGray }));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkCyan, ConsoleColor.Cyan }));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.15f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.Yellow }));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.13f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkCyan, ConsoleColor.Cyan }));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkCyan, ConsoleColor.Cyan }));
    

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                Console.Clear();
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                    lane.Draw();     
                }
                Vector2Int input = Utils.Input();
                gameState = player.Update(input, lanes);
                player.Draw(lanes);



                TimeManager.NextFrame();
            }

            Console.Clear();
            Console.SetCursorPosition(Utils.MAP_WIDTH / 2 - 4, Utils.MAP_HEIGHT / 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(gameState == Utils.GAME_STATE.WIN ? "You win!" : "You lose!");
            Console.ReadKey();
        }
    }
}
    

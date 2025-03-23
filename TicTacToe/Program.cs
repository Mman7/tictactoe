using Game;

class Program
{
    static void Main()
    {
        TicTacToe game = new TicTacToe();
        ConsoleKeyInfo input;

        for (game.gameRound = 0; game.gameRound < game.endRound; game.gameRound++)
        {
            do
            {
                game.renderTemplete();
                Console.WriteLine($"Round {game.gameRound + 1} Player {game.turn} turn!");
                Console.WriteLine("Select the number between 0-8 at empty grid");
                input = Console.ReadKey();
                Console.WriteLine("\n");
            } while (
                checkInput(input)
                || checkIsEmpty(game.gridList[int.Parse(input.KeyChar.ToString())].Shape)
            );
            int selected = int.Parse(input.KeyChar.ToString());
            game.changeGridShape(selected, game.turn);
            game.renderTemplete();
            if (game.checkWin())
            {
                Console.WriteLine("check win mF");
                break;
            }
            game.switchTurn();
        }
    }

    /// <summary>
    ///  [input] is not number or bigger than 8 return true
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static bool checkInput(ConsoleKeyInfo input)
    {
        return !int.TryParse(input.KeyChar.ToString(), out int result)
            || int.Parse(input.KeyChar.ToString()) > 8;
    }

    static bool checkIsEmpty(GridShape listItem) => listItem != GridShape.empty;
}

namespace Game
{
    public class TicTacToe
    {
        public int gameRound;
        public int endRound = 9;
        public GridShape turn = GridShape.O;

        public Grid[] gridList =
        {
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
            new Grid(GridShape.empty),
        };

        public void switchTurn()
        {
            turn = turn == GridShape.O ? GridShape.X : GridShape.O;
        }

        public void changeGridShape(int gridListIndex, GridShape shape)
        {
            gridList[gridListIndex].Shape = shape;
        }

        ///---------------------------------------------
        public void renderTemplete()
        {
            Console.Clear();
            Console.WriteLine(
                @$"{renderShape(gridList[0], 0)} | {renderShape(gridList[1], 1)} | {renderShape(gridList[2], 2)} 
----------
{renderShape(gridList[3], 3)} | {renderShape(gridList[4], 4)} | {renderShape(gridList[5], 5)}
----------
{renderShape(gridList[6], 6)} | {renderShape(gridList[7], 7)} | {renderShape(gridList[8], 8)}
"
            );
        }

        ///---------------------------------------------

        string renderShape(Grid grid, int idx)
        {
            if (grid.Shape == GridShape.empty)
                return $"{idx}";
            return grid.Shape.ToString();
        }

        public bool checkWin()
        {
            if (gameRound < 3)
                return false;
            if (allSame(gridList[0], gridList[1], gridList[2]))
                return true;
            if (allSame(gridList[3], gridList[4], gridList[5]))
                return true;
            if (allSame(gridList[6], gridList[7], gridList[8]))
                return true;
            if (allSame(gridList[0], gridList[3], gridList[6]))
                return true;
            if (allSame(gridList[1], gridList[4], gridList[7]))
                return true;
            if (allSame(gridList[2], gridList[5], gridList[8]))
                return true;
            if (allSame(gridList[0], gridList[4], gridList[8]))
                return true;
            if (allSame(gridList[2], gridList[4], gridList[6]))
                return true;

            return false;
        }

        bool allSame(Grid item1, Grid item2, Grid item3)
        {
            if (new[] { item1.Shape, item2.Shape, item3.Shape }.All(x => x == GridShape.empty))
                return false;

            return item1.Shape == item2.Shape && item2.Shape == item3.Shape;
        }
    }
}

public class Grid
{
    public GridShape Shape { get; set; }

    public Grid(GridShape shape)
    {
        Shape = shape;
    }
}

public enum GridShape
{
    X,
    O,
    empty,
}
